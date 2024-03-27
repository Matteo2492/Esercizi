using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    class VariazioneDAL : IDal<Variazione>
    {
        private static VariazioneDAL? istanza;

        public static VariazioneDAL getIstanza()
        {
            if (istanza == null)
                istanza = new VariazioneDAL();

            return istanza;
        }

        private VariazioneDAL() { }

        public Variazione FindByID(int id)
        {
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    return ctx.Variaziones.Single(l => l.VariazioneId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new Variazione();
        }
        public bool Insert(Variazione t)
        {
            bool risultato = false;

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    ctx.Variaziones.Add(t);
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

        public List<Variazione> GetAll()
        {
            List<Variazione> risultato = new List<Variazione>();

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.Variaziones.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
        public bool Update(Variazione t)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Variazione? cat = ctx.Variaziones.Find(t.VariazioneId);
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
                    Variazione? cat = ctx.Variaziones.Find(id);
                    if (cat != null)
                    {
                        ctx.Variaziones.Remove(cat);
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
