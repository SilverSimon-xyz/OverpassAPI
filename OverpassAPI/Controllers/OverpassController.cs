using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overpass.Modelli.Models;
using Overpass.Modelli.Services;
using OverpassAPI.ViewModels;

namespace OverpassAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OverpassController : ControllerBase
    {
        [HttpGet]
        public IActionResult ElencoNodi()
        {
            NodoOverpass[] ElencoNodi = ServizioOverpassAncona.DaiElencoNodiAnconaOverpass().Result;
            return Ok(ElencoNodi);
        }

        [HttpGet]
        public IActionResult FiltraNodi(string filter)
        {
            NodoOverpass[] ElencoFIltrato = ServizioOverpassAncona.FiltraNodiAnconaOverpass(filter).Result;
            return Ok(ElencoFIltrato);
        }

        [HttpGet]
        public IActionResult ElencoStrade()
        {
            StradaOverpass[] ElencoStrade = ServizioOverpassAncona.DaiElencoStradeAnconaOverpass().Result;
            return Ok(ElencoStrade);
        }
    }
}
