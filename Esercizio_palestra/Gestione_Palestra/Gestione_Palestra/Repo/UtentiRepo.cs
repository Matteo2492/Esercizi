using Gestione_Palestra.Models;

namespace Gestione_Palestra.Repo
{
    public class UtentiRepo : IRepo<Utenti>
    {
        private readonly GestionePalestraContext context;

        public UtentiRepo(GestionePalestraContext context)
        {
            this.context = context;
        }
        public List<Utenti> All()
        {
            return context.Utentis.ToList();
        }
        public Utenti? Id(int id)
        {
            return context.Utentis.FirstOrDefault(p => p.UtenteId == id);
        }
        public Utenti? Nominativo(string nome)
        {
            return context.Utentis.FirstOrDefault(p => p.Nominativo == nome);
        }

        public bool Insert(Utenti utenti)
        {
                try
                {
                    context.Utentis.Add(utenti);
                    context.SaveChanges();
                    return true; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'inserimento utente: {ex.Message}");
                }
            return false;
        }
    }
}
