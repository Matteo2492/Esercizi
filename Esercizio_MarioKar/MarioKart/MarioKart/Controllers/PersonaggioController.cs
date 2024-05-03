using MarioKart.DTO;
using MarioKart.Services;
using MarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaggioController : Controller
    {
        private readonly PersonaggioService _service;

        public PersonaggioController(PersonaggioService service)
        {
            _service = service;
        }
        [HttpGet("personaggio/elenco")]
        public ActionResult<Risposta> ElencoPersonaggio()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }

        [HttpPost("personaggio/inserisci")]
        public ActionResult<Risposta> InserisciPersonaggio(PersonaggioDTO objProd)
        {
            List<string> listaErrori = new List<string>();

            if (objProd.Nom is null || objProd.Nom.Trim().Equals(""))
                listaErrori.Add("Nome vuoto");

            if (objProd.Cat is null || objProd.Cat.Trim().Equals(""))
                listaErrori.Add("Categoria vuota");

            if (objProd.Des is null || objProd.Des.Trim().Equals(""))
                listaErrori.Add("Descrizione vuota");

            if (objProd.Cos < 1 || objProd.Cos > 4)
                listaErrori.Add("Costo errato");

            if (_service.InserisciPersonaggio(objProd))
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
        [HttpPut("personaggio/aggiorna")]
        public ActionResult UpdateSquadra(PersonaggioDTO objSqu)
        {
            if (_service.AggiornaPersonaggio(objSqu))
                return Ok();

            return BadRequest();
        }
        [HttpDelete("personaggio/elimina/{varNom}")]
        public ActionResult Delete(string varNom)
        {
            if (_service.EliminaPersonaggio(new PersonaggioDTO() { Nom = varNom }))
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
