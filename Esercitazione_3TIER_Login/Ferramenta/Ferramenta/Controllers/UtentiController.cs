using Ferramenta.DTO;
using Ferramenta.Filters;
using Ferramenta.Models;
using Ferramenta.Services;
using Ferramenta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ferramenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtentiController : Controller
    {
        private readonly UtenteService _serviceutenti;

        public UtentiController(UtenteService service)
        {
            _serviceutenti = service;
        }

        [HttpPost("login")]
        public IActionResult Loggati(UtenteDTO objLogin)
        {
            //TODO: Verifica accesso, emissione JWT
            if(_serviceutenti.PerId(objLogin))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Username),
                    new Claim("UserType","USER"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      //Evito che due dispositivi abbiano lo stesso JWT TOken (rubato)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "TeamDelleMeraviglie",
                    audience: "Utenti",
                    claims: claims,          //Body o Payload del JWT
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Unauthorized();
        }

        [HttpGet("utenteprofilo")]
        [AiutorizzaUtentePerTipo("USER")]
        public IActionResult DammiInformazioniUtente()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = "Dati sensibili USER"
            });
        }
    }
}
