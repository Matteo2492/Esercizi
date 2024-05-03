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
    public class AuthController : Controller
    {
        private readonly UtenteService _serviceutenti;

        public AuthController(UtenteService service)
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
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Use),
                    new Claim("UserType","USER"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      //Evito che due dispositivi abbiano lo stesso JWT TOken (rubato)
                    new Claim("Username", objLogin.Use)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "TeamPelati",
                    audience: "Utenti",
                    claims: claims,          //Body o Payload del JWT
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            return Unauthorized();
        }
        [HttpGet("profiloutente")]
        [AutorizzazioneUtente("USER")]
        public IActionResult DammiInformazioniUtente()
        {
            var email = User.Claims.FirstOrDefault(p => p.Type == "Username")?.Value;
            if (email is not null)
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = _serviceutenti.PerEmail(email)
                });
            }
            return Ok(new Risposta()
            {
                Status = "ERRORE"
            });
        }
    }
}
