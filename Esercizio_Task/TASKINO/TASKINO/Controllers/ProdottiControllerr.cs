using Microsoft.AspNetCore.Mvc;
using TASKINO.Models;
using TASKINO.Repo;

namespace TASKINO.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottiControllerr : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()
        {
            List<Prodotti> elenco = ProdottoRepo.GetIstance().GetAll();
            return Ok(elenco);
        }
        [HttpGet("{valCodice}")]
        public IActionResult DettaglioProdotto(string valCodice)
        {
            Prodotti? pro = ProdottoRepo.GetIstance().GetByCodice(valCodice);
            if (pro is not null)
            {
                return Ok(pro);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult InserisciProdotto(Prodotti objPro)
        {
            if (ProdottoRepo.GetIstance().insert(objPro))
                return Ok();
            return BadRequest();
        }

        private IActionResult EliminaProdotto(int valId)
        {
            if (ProdottoRepo.GetIstance().delete(valId))
                return Ok();

            return BadRequest(); 
        }

        [HttpDelete("codice/{valCodice}"), HttpPost("codice/{valCodice}")]
        public IActionResult EliminaProdottoCodice(string valCodice)
        {
            Prodotti? pro = ProdottoRepo.GetIstance().GetByCodice(valCodice);
            if (pro is null)
            {
                return BadRequest();
            }
            return EliminaProdotto(pro.ProdottoId);
        }
        [HttpPatch]
        public IActionResult ModificaProdotto(Prodotti objPro)
        {
            if (ProdottoRepo.GetIstance().update(objPro))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
