using Gestione_Palestra.Models;
using Gestione_Palestra.Repo;

namespace Gestione_Palestra.Services
{
    public class UtentiService
    {
        private readonly UtentiRepo repository;

        public UtentiService(UtentiRepo repository)
        {
            this.repository = repository;
        }

        public List<Utenti> RestituisciUtenti()
        {
            return repository.All();
        }
        public Utenti? RestituisciUtenteId(int id)
        {
            return repository.Id(id);
        }
        public Utenti? RestituisciUtenteNome(string nome)
        {
            return repository.Nominativo(nome);
        }
        public bool Inserisci(Utenti utenti)
        {
            return repository.Insert(utenti);
        }
    }
}
