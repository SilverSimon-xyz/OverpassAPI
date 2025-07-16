using Microsoft.AspNetCore.Mvc;
using Overpass.Modelli.Models;
using Overpass.Modelli.Services;
using OverpassAPI.ViewModels;

namespace OverpassAPI.Controllers
{
    public class NodiOverpassController : Controller
    {
        [HttpGet]
        public IActionResult ElencoNodi()
        {
            
            NodoOverpass[] ElencoNodi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result;
            var tipi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result
                .SelectMany(n => new[] { n.tags.amenity, n.tags.tourism, n.tags.leisure })
                .Where(t => !string.IsNullOrEmpty(t))
                .Distinct()
                .OrderBy(t => t)
                .ToList();
            NodiOverpassElencoNodiViewModel vm = new()
            {
                ElencoNodi = ElencoNodi,
                TipiDisponibili = tipi
            };
            
            return View(vm);
        }

        [HttpGet]
        public IActionResult FiltraNodi(string filter)
        {
            NodoOverpass[] ElencoFiltrato = ServizioOverpassAncona.FiltraNodiAnconaOverpass(filter).Result;
            var tipi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result
                .SelectMany(n => new[] { n.tags.amenity, n.tags.tourism, n.tags.leisure })
                .Where(t => !string.IsNullOrEmpty(t))
                .Distinct()
                .OrderBy(t => t)
                .ToList();
            NodiOverpassElencoNodiViewModel vm = new()
            {
                ElencoNodi = ElencoFiltrato,
                TipiDisponibili = tipi,
                filter = filter
            };
            
            return View("ElencoNodi", vm);
        }
    }
}
