using Gestione_Palestra.Models;

namespace Gestione_Palestra.Repo
{
    public class PrenotazioneRepo : IRepo<Prenotazioni>
    {
        private readonly GestionePalestraContext context;

        public PrenotazioneRepo(GestionePalestraContext context)
        {
            this.context = context;
        }
        public List<Prenotazioni> All()
        {
            return context.Prenotazionis.ToList();
        }
        public Prenotazioni? PerCodice(string cod)
        {
            return context.Prenotazionis.FirstOrDefault(p => p.Codice == cod);
        }
        public Prenotazioni? Id(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Prenotazioni t)
        {
            throw new NotImplementedException();
        }

        public Prenotazioni? Nominativo(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
