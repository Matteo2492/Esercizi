using GestioneRistorante.DTO;
using GestioneRistorante.Filters;
using GestioneRistorante.Services;
using GestioneRistorante.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestioneRistorante.Controllers
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

        [HttpPost("login")]
        public IActionResult Loggati(UtenteDTO objLogin)
        {
            //TODO: Verifica accesso, emissione JWT
            if (_serviceutenti.LoginUtente(objLogin))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Ema),
                    new Claim("UserType","USER"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      //Evito che due dispositivi abbiano lo stesso JWT TOken (rubato)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "TeamFantastici",
                    audience: "Utenti",
                    claims: claims,          //Body o Payload del JWT
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            return Unauthorized();
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

        [HttpGet("profiloutente/{email}")]
        [AutorizzaUtentePerTipo("USER")]
        public IActionResult DammiInformazioniUtente(string email)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _serviceutenti.PerEmail(email).Nom
            }); ;
        }
    }
}
