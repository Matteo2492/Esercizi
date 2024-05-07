using Chattero.DTO;
using Chattero.Services;
using Chattero.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        [HttpDelete("elimina_messaggio/{nome}/{ora}")]
        public IActionResult EliminaStanza(string nome, DateTime ora)
        {
            MessaggioDTO temp = new MessaggioDTO()
            {
                NomUte = nome,
                Ora = ora
            };
            if (_serviceMsg.EliminaMessaggio(temp))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                });
            }
            return BadRequest();
        }
    }
}
