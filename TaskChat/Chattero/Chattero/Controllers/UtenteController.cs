using Chattero.DTO;
using Chattero.Filters;
using Chattero.Services;
using Chattero.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chattero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : Controller
    {
        private readonly UtenteService _serviceutenti;

        public UtenteController(UtenteService service)
        {
            _serviceutenti = service;
        }


        [HttpPost("register")]
        public IActionResult Register(UtenteDTO obj)
        {
            if (_serviceutenti.RegistraUtente(obj))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Inserimento avvenuto"
                });
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(UtenteDTO obj)
        {
            if (_serviceutenti.EliminaPerEmail(obj))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Eliminazione avvenuta"
                });
            return BadRequest();
        }

        [HttpGet("listautenti")]
        public IActionResult ListaUtenti()
        {
            return Ok(_serviceutenti.RestituisciTutto());
        }
    }
}
