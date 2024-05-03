using Gestione_Palestra.Models;
using Gestione_Palestra.Repo;

namespace Gestione_Palestra.Services
{
    public class PrenotazioniUtentiService
    {
        private readonly PrenotazioniUtentiRepo repository;

        public PrenotazioniUtentiService(PrenotazioniUtentiRepo repo)
        {
            repository = repo;
        }


        public bool InserisciPrenotazioneUtente(PrenotazioniUtenti pro)
        {
            return repository.Insert(pro);
        }

        public bool EliminaPrenotazionePerId(int id)
        {
            PrenotazioniUtenti? temp = repository.Id(id);
            if (temp == null)
                return false;
            else
                return repository.Delete(temp.PrenotazioneUtenteId);
        }

        public List<PrenotazioniUtenti> RestituisciTutti()
        {
            return repository.All();
        }
    }
}
