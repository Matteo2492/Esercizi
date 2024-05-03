using TASKINO.Models;

namespace TASKINO.Repo
{
    public class ProdottoRepo
    {
        private static ProdottoRepo? istance;
        public static ProdottoRepo GetIstance()
        {
            if (istance == null)
            {
                istance = new ProdottoRepo();
            }
            return istance;
        }
        private ProdottoRepo()
        {

        }
        public bool delete(int id)
        {
            bool risultato = false;
            try
            {
                using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
                {
                    Prodotti pro = ctx.Prodottis.Single(c => c.ProdottoId == id);
                    ctx.Prodottis.Remove(pro);
                    ctx.SaveChanges();
                    risultato = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public List<Prodotti> GetAll()
        {
            List<Prodotti> elenco = new List<Prodotti>();

            using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
            {
                return elenco = ctx.Prodottis.ToList();
            }
        }

        public Prodotti GetById(int id)
        {
            Prodotti? pro = null;

            using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
            {
                pro = ctx.Prodottis.FirstOrDefault(l => l.ProdottoId == id);
            }

            return pro;
        }

        public bool insert(Prodotti t)
        {
            bool risultato = false;
            using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
            {
                try
                {
                    ctx.Prodottis.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool update(Prodotti t)
        {
            bool risultato = false;
            try
            {
                using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
                {

                    Prodotti pro = ctx.Prodottis.Single(l => l.Codice == t.Codice);

                    t.ProdottoId = pro.ProdottoId;
                    t.Codice = t.Codice is not null ? t.Codice : pro.Codice;
                    t.Nome = t.Nome is not null ? t.Nome : pro.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : pro.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? pro.Prezzo : t.Prezzo;
                    t.Quantita = t.Quantita is null ? pro.Quantita : t.Quantita;
                    t.Categoria = t.Categoria is null ? pro.Categoria : t.Categoria;

                    ctx.Entry(pro).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public Prodotti? GetByCodice(string codice)
        {
            Prodotti? pro = null;

            using (AccLez32FerramentaContext ctx = new AccLez32FerramentaContext())
            {
                pro = ctx.Prodottis.FirstOrDefault(l => l.Codice == codice);
            }

            return pro;
        }
    }
}
