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
    }
}
