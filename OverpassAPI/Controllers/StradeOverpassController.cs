using Microsoft.AspNetCore.Mvc;
using Overpass.Modelli.Models;
using Overpass.Modelli.Services;
using OverpassAPI.ViewModels;

namespace OverpassAPI.Controllers
{
    public class StradeOverpassController : Controller
    {
        [HttpGet]
        public IActionResult ElencoStrade()
        {
            StradeOverpassElencoStradeViewModel vm = new();
            StradaOverpass[] ElencoStrade = ServizioOverpassAncona.DaiElencoStradeAnconaOverpass().Result;
            vm.ElencoStrade = ElencoStrade;
            return View(vm);
        }
    }
}
