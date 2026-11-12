using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI_Carlos_Chica_20261112.Entity
{
    public class Aeropuertos
    {
    int Id { get; } 
	string nombre { get; set; } = string.Empty;
	string IATA { get; set; } = string.Empty;
        string ciudad { get; set; } = string.Empty;
        string pais { get; set; } = string.Empty;
    }
}
