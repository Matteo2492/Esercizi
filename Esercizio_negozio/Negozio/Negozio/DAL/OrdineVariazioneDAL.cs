using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    class OrdineVariazioneDAL : IDal<OrdineVariazione>
    {
        private static OrdineVariazioneDAL? istanza;

        public static OrdineVariazioneDAL getIstanza()
        {
            if (istanza == null)
                istanza = new OrdineVariazioneDAL();

            return istanza;
        }

        private OrdineVariazioneDAL() { }

        public OrdineVariazione FindByID(int id)
        {
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    return ctx.OrdineVariaziones.Single(l => l.OrdineVariazioneId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new OrdineVariazione();
        }
        public bool Insert(OrdineVariazione t)
        {
            bool risultato = false;

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    ctx.OrdineVariaziones.Add(t);
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

        public List<OrdineVariazione> GetAll()
        {
            List<OrdineVariazione> risultato = new List<OrdineVariazione>();

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.OrdineVariaziones.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
        public bool Update(OrdineVariazione t)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Ordine? cat = ctx.Ordines.Find(t.OrdineVariazioneId);
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
                    OrdineVariazione? cat = ctx.OrdineVariaziones.Find(id);
                    if (cat != null)
                    {
                        ctx.OrdineVariaziones.Remove(cat);
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
