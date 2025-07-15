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
            NodiOverpassElencoNodiViewModel vm = new();
            NodoOverpass[] ElencoNodi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result;
            vm.ElencoNodi = ElencoNodi;
            return View(vm);
        }

        [HttpGet]
        public IActionResult FiltraNodi(string filter)
        {
            NodiOverpassFiltraNodiViewModel vm = new();
            NodoOverpass[] ElencoFiltrato = ServizioOverpassAncona.FiltraNodiAnconaOverpass(filter).Result;
            vm.ElencoFiltrato = ElencoFiltrato;
            return View(vm);
        }
    }
}
