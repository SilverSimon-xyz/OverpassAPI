using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overpass.Modelli.Models;
using Overpass.Modelli.Services;
using OverpassAPI.ViewModels;

namespace OverpassAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NodiOverpassController : ControllerBase
    {
        [HttpPost]
        public IActionResult ElencoNodi()
        {
            NodiOverpassElencoNodiViewModel vm = new();
            NodoOverpass[] ElencoNodi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result;
            vm.ElencoNodi = ElencoNodi;
            return Ok(vm);
        }
    }
}
