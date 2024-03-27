using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    internal class UtenteDAL: IDal<Utente>
    {
        private static UtenteDAL? istanza;

        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();

            return istanza;
        }

        private UtenteDAL() { }

        public Utente FindByID(int id)
        {
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    return ctx.Utentes.Single(l => l.UtenteId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new Utente();
        }
        public bool Insert(Utente t)
        {
            bool risultato = false;

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    ctx.Utentes.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }

        public List<Utente> GetAll()
        {
            List<Utente> risultato = new List<Utente>();

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.Utentes.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
        public bool Update(Utente t)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Utente? cat = ctx.Utentes.Find(t.UtenteId);
                    if (cat is not null)
                    {
                        ctx.Entry(cat).CurrentValues.SetValues(t);
                        ctx.SaveChanges();
                        check = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return check;
        }
        public bool DeleteByID(int id)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Utente? cat = ctx.Utentes.Find(id);
                    if (cat != null)
                    {
                        ctx.Utentes.Remove(cat);
                        ctx.SaveChanges();
                        check = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return check;
        }
    }
}
