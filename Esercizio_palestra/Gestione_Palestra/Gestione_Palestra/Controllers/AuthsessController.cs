using Gestione_Palestra.Models;
using Gestione_Palestra.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Gestione_Palestra.Controllers
{
    public class AuthsessController : Controller
    {
        private readonly UtentiService service;
        private readonly CorsiService serviceCorsi;
        private readonly PrenotazioniService servicePrenotazione;
        private readonly PrenotazioniUtentiService servicePrenotazioneUtente;
        public AuthsessController(UtentiService service, CorsiService corsi,PrenotazioniService prenotazioni, PrenotazioniUtentiService prenota)
        {
            this.service = service;
            this.serviceCorsi = corsi;
            this.servicePrenotazione = prenotazioni;
            this.servicePrenotazioneUtente = prenota;
        }

        public IActionResult Login()
        {
            ViewBag.ListaCorsi = serviceCorsi.RestituisciCorsi();

            return View();

        }
        public IActionResult Registrati(Utenti obj)
        {
            if (obj.Nominativo is not null && obj.PasswordUtente is not null && obj.Codice is not null)
            {

                service.Inserisci(obj);

                return Redirect("/Authsess/Login");
            }
            return Redirect("/Authsess/Login");
        }
        public IActionResult VerificaCredenziali(Utenti obj)
        {
            if (obj.Nominativo is not null && obj.PasswordUtente is not null)
            {
                Utenti? tmp = service.RestituisciUtenteNome(obj.Nominativo);
                if (tmp is not null && tmp.PasswordUtente == obj.PasswordUtente)
                {
                    HttpContext.Session.SetString("userLogged", obj.Nominativo);
                    return Redirect("/Authsess/Profiloutente");
                }
            }
            return Redirect("/Authsess/Login");
        }

        public IActionResult Profiloutente()
        {
            string? nome = HttpContext.Session.GetString("userLogged");
            List<string>? listaPref = new List<string>();
            string? contenutoSessione = HttpContext.Session.GetString("preferiti");
            if (contenutoSessione != null)
                listaPref = JsonConvert.DeserializeObject<List<string>>(contenutoSessione);
            
            if (nome is not null)
            {
                Utenti? tmp = new Utenti();
                tmp = service.RestituisciUtenteNome(nome);
                ViewBag.ListaPref = listaPref;
                ViewBag.ListaCorsi = serviceCorsi.RestituisciCorsi();
                 
                return View(tmp);
            }
            return Redirect("/Authsess/Profiloutente");
        }
        public IActionResult Prenota(string? varCodice,string? varUtente)
        {
            try
            {
                if(varCodice is not null && varUtente is not null)
                {
                    List<Prenotazioni> listaprenotazioni = servicePrenotazione.RestituisciPernotazioni();
                    Corsi? corso = serviceCorsi.NomeCorso(varCodice);
                    Utenti? utente = service.RestituisciUtenteNome(varUtente);
                    if(corso is not null)
                    {
                        Prenotazioni? prenotazione = listaprenotazioni.FirstOrDefault(p => p.CorsoRif == corso.CorsoId);
                        if (utente is not null && prenotazione is not null)
                        {
                            PrenotazioniUtenti tmp = new PrenotazioniUtenti() { UtenteId = utente.UtenteId, PrenotazioneId = prenotazione.PrenotazioneId };
                            servicePrenotazioneUtente.InserisciPrenotazioneUtente(tmp);
                        }
                    }
                         
                }
                
                List<string>? lista = new List<string>();
                
                string? contenuto = HttpContext.Session.GetString("preferiti");

                if (contenuto is not null)
                {
                    lista = JsonConvert.DeserializeObject<List<string>>(contenuto);
                }
                if (lista is not null && varCodice is not null)
                {
                    lista.Add(varCodice);
                }
                HttpContext.Session.SetString("preferiti", JsonConvert.SerializeObject(lista));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Elimina(string? varCodice, string? varUtente)
        {
            try
            {
                if (varCodice is not null && varUtente is not null)
                {
                    List<Prenotazioni> listaprenotazioni = servicePrenotazione.RestituisciPernotazioni();
                    Corsi? corso = serviceCorsi.NomeCorso(varCodice);     
                    Utenti? utente = service.RestituisciUtenteNome(varUtente);
                    if (utente is not null && corso is not null)
                    {
                        Prenotazioni? prenotazione = listaprenotazioni.FirstOrDefault(p => p.CorsoRif == corso.CorsoId);
                        if (utente is not null && prenotazione is not null)
                        {
                            PrenotazioniUtenti? tmp = servicePrenotazioneUtente.RestituisciTutti().FirstOrDefault(p => p.UtenteId == utente.UtenteId && p.PrenotazioneId == prenotazione.PrenotazioneId);
                            if (tmp != null)
                            {
                                servicePrenotazioneUtente.EliminaPrenotazionePerId(tmp.PrenotazioneUtenteId);
                            }
                        }
                    }

                }
                List<string>? lista = new List<string>();

                string? contenuto = HttpContext.Session.GetString("preferiti");

                if (contenuto is not null)
                {
                    lista = JsonConvert.DeserializeObject<List<string>>(contenuto);
                }
                if (lista is not null && varCodice is not null)
                {
                    lista.Remove(varCodice);
                }
                HttpContext.Session.SetString("preferiti", JsonConvert.SerializeObject(lista));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
