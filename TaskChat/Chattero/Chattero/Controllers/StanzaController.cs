using Chattero.DTO;
using Chattero.Services;
using Chattero.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chattero.Controllers
{
    public class StanzaController : Controller
    {
        private readonly StanzaService _service;
        private readonly MessaggioService _serviceMsg;
        public StanzaController(StanzaService service, MessaggioService serviceMsg)
        {
            _service = service;
            _serviceMsg = serviceMsg;
        }

        [HttpPost("creastanza")]
        public IActionResult CreaStanza(StanzaDTO obj)
        {
            if (_service.Inserimento(obj))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Inserimento avvenuto"
                });
            return BadRequest();
        }

        [HttpPost("aggiungi_partecipante")]
        public IActionResult AggiungiPartecipante(string dto, string ute)
        {
            if (_service.AggiungiPartecipante(dto, ute))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });
            else
                return Ok(new Risposta()
                {
                    Status = "ERRROR"
                });
        }
        [HttpPost]
        public IActionResult InserisciMessaggio(StanzaDTO stanza, MessaggioDTO mex)
        {
            if (_service.InserisciMessaggio(stanza, mex))
                return Ok();
            else
                return Ok(new Risposta()
                {
                    Status = "ERROR"
                });
        }

        [HttpGet("{stanza}")]
        public IActionResult RecuperaPerStanza(StanzaDTO stanza)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RecuperaTuttiMsgPerStanza(stanza)
            });
        }
        [HttpGet("dettaglio/{codice}")]
        public IActionResult DettaglioGruppo(StanzaDTO sta)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestuisciStanza(sta)
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult EliminaStanza(StanzaDTO sta)
        {
            return Ok(_service.EliminaStanza(sta));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.GetAll()
            });
        }

        [HttpGet("global")]
        public IActionResult CreaGlobal()
        {
            _service.CreaGlobal();
            return Ok(new Risposta()
            {
                Status = "SUCCESS"
            });
        }
    }
}
