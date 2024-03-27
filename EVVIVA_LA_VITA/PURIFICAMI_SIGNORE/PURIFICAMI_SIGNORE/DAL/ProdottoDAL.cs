using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    class ProdottoDAL : IDal<Prodotto>
    {
        private static ProdottoDAL? istanza;

        public static ProdottoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new ProdottoDAL();

            return istanza;
        }

        private ProdottoDAL() { }

        public Prodotto FindByID(int id)
        {
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    return ctx.Prodottos.Single(l => l.ProdottoId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new Prodotto();
        }
        public bool Insert(Prodotto t)
        {
            bool risultato = false;

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
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

        public List<Prodotto> GetAll()
        {
            List<Prodotto> risultato = new List<Prodotto>();

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.Prodottos.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
        public bool Update(Prodotto t)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Prodotto? cat = ctx.Prodottos.Find(t.ProdottoId);
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
                    Prodotto? cat = ctx.Prodottos.Find(id);
                    if (cat != null)
                    {
                        ctx.Prodottos.Remove(cat);
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
