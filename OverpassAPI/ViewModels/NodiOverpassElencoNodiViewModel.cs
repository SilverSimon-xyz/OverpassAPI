using Overpass.Modelli.Models;

namespace OverpassAPI.ViewModels
{
    public class NodiOverpassElencoNodiViewModel
    {
        public NodoOverpass[] ElencoNodi { get; set; }
        public string filter { get; set; }
        public List<string> TipiDisponibili { get; set; }
    }
}
