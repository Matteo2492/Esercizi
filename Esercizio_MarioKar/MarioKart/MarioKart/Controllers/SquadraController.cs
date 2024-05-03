using MarioKart.DTO;
using MarioKart.Repos;
using MarioKart.Services;
using MarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquadraController : Controller
    {
        private readonly SquadraService _service;

        public SquadraController(SquadraService service)
        {
            _service = service;
        }
        [HttpGet("squadra/elenco")]
        public ActionResult<Risposta> ElencoSquadra()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }

        [HttpPost("squadra/inserisci")]
        public ActionResult<Risposta> InserisciSquadra(SquadraDTO objProd)
        {
            List<string> listaErrori = new List<string>();

            if (objProd.Use is null || objProd.Use.Trim().Equals(""))
                listaErrori.Add("Nome vuoto");

            if (objProd.Cre < 0 || objProd.Cre > 10)
                listaErrori.Add("Prezzo errato");

            if (_service.InserisciSquadra(objProd))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });
            }
            else
            {
                listaErrori.Add("Inserimento fallito");
            }

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = listaErrori
            });
        }
        [HttpPut("squadra/aggiorna")]
        public ActionResult UpdateSquadra(SquadraDTO objSqu)
        {
            if (_service.AggiornaSquadra(objSqu))
                return Ok();

            return BadRequest();
        }
        [HttpDelete("squadra/elimina/{varUse}")]
        public ActionResult Delete(string varUse)
        {
            if (_service.EliminaSquadra(new SquadraDTO() { Use = varUse }))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Eliminazione non effettuata"
            });
        }
    }
}
