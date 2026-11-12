namespace WebAPI_Carlos_Chica_20261112.Entity
{
    public class Vuelos
    {
        public int Id { get; set; }
        public string n_Vuelo { get; set; } = string.Empty;
        public int AerolineaID { get; set; }
        public int aeropuertoOrigenID { get; set; }
        public int aeropuertoDestinoID { get; set; }
        public DateTime fechaHorasalida { get; set; }
        public DateTime fechaHoraLlegadaEstimada { get; set; }
        public int capacidadPasajerosEco { get; set; }
        public int capacidadPasajerosEjecu { get; set; }
    }
}
