using Ferramenta.DTO;
using Ferramenta.Models;
using Ferramenta.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferramenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdottiController : Controller
    {
        private readonly ProdottiService _serviceprodotti;

        public ProdottiController(ProdottiService service)
        {
            _serviceprodotti = service;
        }

        [HttpGet("tutti")]
        public ActionResult<List<ProdottiDTO>> ElencoProdotti()
        {
            return _serviceprodotti.RestituisciTutto();
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciProdotti(ProdottiDTO obj)
        {
            if(_serviceprodotti.Inserimento(obj))
                return Ok();
            return BadRequest();
        }
    }
}
