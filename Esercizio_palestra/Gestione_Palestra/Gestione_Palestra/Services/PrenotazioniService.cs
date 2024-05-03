using Gestione_Palestra.Models;
using Gestione_Palestra.Repo;

namespace Gestione_Palestra.Services
{
    public class PrenotazioniService
    {
        private readonly PrenotazioneRepo repository;
        public PrenotazioniService(PrenotazioneRepo repo)
        {
            this.repository = repo;
        }
        public Prenotazioni? RestituisciPerCodice(string cod)
        {
            return repository.PerCodice(cod);
        }
        public List<Prenotazioni> RestituisciPernotazioni()
        {
            return repository.All();
        }
    }
}
