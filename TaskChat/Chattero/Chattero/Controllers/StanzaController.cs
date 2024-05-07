using Chattero.DTO;
using Chattero.Services;
using Chattero.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chattero.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("aggiungipartecipante/{dto}/{ute}")]
        public IActionResult AggiungiPartecipante(string dto, string ute)
        {
            if (_service.AggiungiPartecipante(dto, ute))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = $"Inserimento avvenuto, nuovo partecipante --> {ute}"
                });
            else
                return BadRequest(new Risposta()
                {
                    Status = "ERRROR"
                });
        }
        [HttpPut("rimuovipartecipante/{dto}/{ute}")]
        public IActionResult RimuoviPartecipante(string dto, string ute)
        {
            if (_service.RimuoviParatecipantne(dto, ute))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = $"Rimozione avvenuta, addio --> {ute}"
                });
            else
                return Ok(new Risposta()
                {
                    Status = "ERRROR"
                });
        }
        [HttpPost("aggiungi_messaggio/")]
        public IActionResult InserisciMessaggio(MessaggioDTO mex)
        {
            if (_service.InserisciMessaggio(mex))
                return Ok(new Risposta()
                {
                    Status = "OK"
                });
            else
                return BadRequest(new Risposta()
                {
                    Status = "ERROR"
                });
        }
        [HttpGet("create_da/{nome}")]
        public IActionResult RecuperaPerStanzaPerUtente(string nome)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.GetAllByCreatore(nome)
            });
        }
        [HttpGet("stanze_di/{nome}")]
        public IActionResult RecuperaPerStanzaP(string nome)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.GetAllP(nome)
            });
        }
        [HttpGet("stanze_nuove/{nome}")]
        public IActionResult RecuperaPerStanzeNuove(string nome)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.NonAppartiene(nome)
            });
        }
        [HttpGet("messaggi/{stanza}")]
        public IActionResult RecuperaPerStanza(string stanza)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RecuperaTuttiMsgPerStanza(stanza )
            });
        }
        [HttpGet("dettaglio_stanza/{sta}")]
        public IActionResult DettaglioStanza(string sta)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RitornaDto(sta)
            });
        }

        [HttpDelete("elimina_stanza/{sta}")]
        public IActionResult EliminaStanza(string sta)
        {
            if (_service.EliminaSta(sta))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Eliminazione avvenuta"
                });
            }
            return BadRequest();
        }

        [HttpGet("lista_stanze")]
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
            if (_service.CreaGlobal())
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });
            }
            else
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = "Stanza gia creata"
                });
            }
        }
    }
}
