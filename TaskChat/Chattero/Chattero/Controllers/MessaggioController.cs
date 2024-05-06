using Chattero.DTO;
using Chattero.Services;
using Chattero.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chattero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessaggioController : Controller
    {
        private readonly MessaggioService _serviceMsg;
        public MessaggioController(MessaggioService serviceMsg)
        {
            _serviceMsg = serviceMsg;
        }
        [HttpPost("elimina_messaggio")]
        public IActionResult EliminaStanza(MessaggioDTO msg)
        {
            if (_serviceMsg.EliminaMessaggio(msg))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Eliminazione avvenuta"
                });
            }
            return BadRequest();
        }
    }
}
