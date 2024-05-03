using GestioneRistorante.DTO;
using GestioneRistorante.Services;
using GestioneRistorante.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestioneRistorante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RistoranteController : Controller
    {
        private readonly RistoranteService _service;
        private readonly PiattoService _servicePiatto;
        public RistoranteController(RistoranteService service, PiattoService servicep)
        {
            _service = service;
            _servicePiatto = servicep;
        }
        
        [HttpGet("ristoranti")]
        public ActionResult<Risposta> ElencoRistoranti()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCES",
                Data =  _service.RestituisciTutto()
            }); 
        }
        [HttpGet("lista-menu/{varCodice}")]
        public ActionResult<Risposta> ElencoPiatti(string varCodice)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCES",
                Data = _servicePiatto.RestituisciTutto(varCodice)
            });
        }
    }
}
