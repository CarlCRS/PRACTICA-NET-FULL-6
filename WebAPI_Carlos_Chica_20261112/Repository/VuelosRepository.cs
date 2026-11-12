using Dapper;
using System.Data;
using System.Data.Common;
using WebAPI_Carlos_Chica_20261112.Entity;

namespace WebAPI_Carlos_Chica_20261112.Repository
{
    public class VuelosRepository
    {
        private readonly IDbConnection _db;

        public VuelosRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Vuelos>> ObtenerTodasAsync()
        {
            var sql = @"SELECT * FROM Vuelos;";
            return await _db.QueryAsync<Vuelos>(sql);
        }

        public async Task<Vuelos?> ObtenerPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM dbo.Vuelos WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<Vuelos>(sql, new { Id = id });
        }

        public async Task<int> CrearAsync(Vuelos vuelos)
        {
            ReglasVuelos(vuelos);

            var sql = @"
            INSERT INTO Vuelos (n_Vuelo, AerolineaID, aeropuertoOrigenID, aeropuertoDestinoID, fechaHorasalida, fechaHoraLlegadaEstimada, capacidadPasajerosEco, capacidadPasajerosEjecu)
            VALUES (@n_Vuelo, @AerolineaID, @aeropuertoOrigenID, @aeropuertoDestinoID, @fechaHorasalida, @fechaHoraLlegadaEstimada, @capacidadPasajerosEco, @capacidadPasajerosEjecu);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            return await _db.ExecuteScalarAsync<int>(sql, vuelos);
        }

        public async Task ActualizarAsync(Vuelos vuelos)
        {
            ReglasVuelos(vuelos);
            var sql = @"UPDATE dbo.Vuelos 
                    SET n_Vuelo = @n_Vuelo, AerolineaID = @AerolineaID, aeropuertoOrigenID = @aeropuertoOrigenID, aeropuertoDestinoID = @aeropuertoDestinoID, fechaHorasalida = @fechaHorasalida, 
                        fechaHoraLlegadaEstimada = @fechaHoraLlegadaEstimada, capacidadPasajerosEco = @capacidadPasajerosEco, capacidadPasajerosEjecu = @capacidadPasajerosEjecu 
                    WHERE Id = @Id";

            await _db.ExecuteAsync(sql, vuelos);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var sql = "DELETE FROM dbo.Vuelos WHERE Id = @Id";
            var filasAfectadas = await _db.ExecuteAsync(sql, new { Id = id });
            return filasAfectadas > 0;
        }

        private void ReglasVuelos(Vuelos vuelo)
        {
            
            if (vuelo.aeropuertoOrigenID == vuelo.aeropuertoDestinoID)
            {
                throw new ArgumentException("El aeropuerto de origen y el aeropuerto destino no pueden ser el mismo.");
            }

            
            if (vuelo.fechaHorasalida >= vuelo.fechaHoraLlegadaEstimada)
            {
                throw new ArgumentException("La fecha y hora de salida debe ser estrictamente anterior a la fecha y hora estimada de llegada.");
            }
        }


    }
}
