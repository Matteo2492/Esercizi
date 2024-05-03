using Gestione_Palestra.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestione_Palestra.Repo
{
    public class PrenotazioniUtentiRepo:IRepo<PrenotazioniUtenti>
    {
        private readonly GestionePalestraContext context;
        public PrenotazioniUtentiRepo(GestionePalestraContext ctx)
        {
            context = ctx;
        }

        public List<PrenotazioniUtenti> All()
        {
            return context.PrenotazioniUtentis.ToList();
        }

        public PrenotazioniUtenti? Id(int id)
        {
            return context.PrenotazioniUtentis.FirstOrDefault(p => p.PrenotazioneUtenteId == id);
        }

        public bool Insert(PrenotazioniUtenti t)
        {
            try
            {
                context.PrenotazioniUtentis.Add(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'inserimento utente: {ex.Message}");
            }
            return false;
        }
        public bool Delete(int id)
        {
            try
            {
                PrenotazioniUtenti temp = context.PrenotazioniUtentis.Single(p => p.PrenotazioneUtenteId == id);
                context.PrenotazioniUtentis.Remove(temp);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public PrenotazioniUtenti? Nominativo(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
