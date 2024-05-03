using Gestione_Palestra.Models;

namespace Gestione_Palestra.Repo
{
    public class CorsiRepo : IRepo<Corsi>
    {
        private readonly GestionePalestraContext context;

        public CorsiRepo(GestionePalestraContext context)
        {
            this.context = context;
        }
        public List<Corsi> All()
        {
            return context.Corsis.ToList();
        }

     
        public Corsi? Id(int id)
        {
            return context.Corsis.FirstOrDefault(p => p.CorsoId == id);
        }
        public Corsi? Nominativo(string nome)
        {
            return context.Corsis.FirstOrDefault(p => p.Nome == nome);
        }
        public bool Insert(Corsi t)
        {
            throw new NotImplementedException();
        }

        public Corsi? NomeCorso(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
