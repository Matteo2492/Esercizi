using GestioneImpiegati.Models;
using GestioneImpiegati.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestioneImpiegati.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImpiegatoService _service_impiegato;
        private readonly CittaService _service_citta;
        private readonly ProvinciaService _service_provincia;
        private readonly RepartoService _service_reparto;

        public HomeController( ImpiegatoService imp,CittaService citt,ProvinciaService pro,RepartoService rep)
        {
            _service_impiegato = imp;
            _service_citta = citt;
            _service_provincia = pro;
            _service_reparto = rep;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inserimento()
        {
            ViewBag.ListaReparti = _service_reparto.ElencoReparti();
            ViewBag.ListaProvince = _service_provincia.ElencoProvince();
            ViewBag.ListaCitta = _service_citta.ElencoCitta();
            return View();
        }
        public IActionResult Lista()
        {
            List<Impiegato> elenco = _service_impiegato.ElencoImpiegati();
            return View(elenco);
        }
        public IActionResult Cerca(string matricola)
        {
            Impiegato? imp = _service_impiegato.ImpiegatiMatriolca(matricola);
            return View(imp);
        }

        [HttpPost]
        public RedirectResult Salvataggio(Impiegato obj)
        {
            if (_service_impiegato.InserisciImpiegato(obj))
                return Redirect("/Home/Inserimento");
            else
                return Redirect("/Prodotto/Errore");
        }

        [HttpDelete]
        public IActionResult Elimina(string varCodice)
        {
            Impiegato? temp = _service_impiegato.ImpiegatiMatriolca(varCodice);

            if (temp is not null)
            {
                _service_impiegato.EliminaImpiegatoperID(temp.ImpiegatoId);
                return Ok();
            }

            return BadRequest();
        }
    }
}
