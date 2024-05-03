using Gestione_Palestra.Models;
using Gestione_Palestra.Repo;

namespace Gestione_Palestra.Services
{
    public class CorsiService
    {
        private readonly CorsiRepo repository;
        public CorsiService(CorsiRepo repo)
        {
            this.repository = repo;
        }
        public List<Corsi> RestituisciCorsi()
        {
            return repository.All();
        }
        public Corsi? RestituisciCorsoId(int id)
        {
            return repository.Id(id);
        }
        public Corsi? NomeCorso(string nome)
        {
            return repository.Nominativo(nome);
        }
    }
}
