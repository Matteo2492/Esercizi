using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    class OrdineDAL : IDal<Ordine>
    {
        private static OrdineDAL? istanza;

        public static OrdineDAL getIstanza()
        {
            if (istanza == null)
                istanza = new OrdineDAL();

            return istanza;
        }

        private OrdineDAL() { }

        public Ordine FindByID(int id)
        {
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    return ctx.Ordines.Single(l => l.OrdineId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return new Ordine();
        }
        public bool Insert(Ordine t)
        {
            bool risultato = false;

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    ctx.Ordines.Add(t);
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

        public List<Ordine> GetAll()
        {
            List<Ordine> risultato = new List<Ordine>();

            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.Ordines.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
        public bool Update(Ordine t)
        {
            bool check = false;
            using (AccLez30AbbigliamentoContext ctx = new AccLez30AbbigliamentoContext())
            {
                try
                {
                    Ordine? cat = ctx.Ordines.Find(t.OrdineId);
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
                    Ordine? cat = ctx.Ordines.Find(id);
                    if (cat != null)
                    {
                        ctx.Ordines.Remove(cat);
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
