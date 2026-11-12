using WebAPI_Carlos_Chica_20261112.Entity;
using WebAPI_Carlos_Chica_20261112.Repository;

namespace WebAPI_Carlos_Chica_20261112.Service
{
    public class ServiceVuelos
    {
        private readonly VuelosRepository _repository;
        public ServiceVuelos(VuelosRepository repovuelo)
        {
            _repository = repovuelo;
        }
        public async Task<int> CrearAsync(Vuelos vuelo)
        {
            return await _repository.CrearAsync(vuelo);
        }

        public async Task<IEnumerable<Vuelos>> Obtenertodosvuelos()
        {
            return await _repository.ObtenerTodasAsync();
        }

        public async Task<Vuelos> ObtenerPorIdAsync(int id)
        {
            var vuelo = await _repository.ObtenerPorIdAsync(id);
            if (vuelo == null)
            {
                throw new KeyNotFoundException($"El vuelo con ID {id} no fue encontrado.");
            }
            return vuelo;
        }

        public async Task ActualizarAsync(Vuelos vuelo)
        {
            var existe = await _repository.ObtenerPorIdAsync(vuelo.Id);
            if (existe == null)
            {
                throw new KeyNotFoundException($"No se puede actualizar. El vuelo con ID {vuelo.Id} no existe.");
            }

            await _repository.ActualizarAsync(vuelo);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var existe = await _repository.ObtenerPorIdAsync(id);
            if (existe == null)
            {
                throw new KeyNotFoundException($"No se puede eliminar. El vuelo con ID {id} no existe.");
            }

            return await _repository.EliminarAsync(id);
        }
    }

}
