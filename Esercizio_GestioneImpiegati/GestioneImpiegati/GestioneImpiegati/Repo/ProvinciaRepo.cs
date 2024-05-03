using GestioneImpiegati.Models;

namespace GestioneImpiegati.Repo
{
    public class ProvinciaRepo : IRepo<Provincium>
    {
        private readonly AccLez35GestioneImpiegatiContext _context;

        public ProvinciaRepo(AccLez35GestioneImpiegatiContext ctx)
        {
            _context = ctx;
        }

        public bool Delete(int id)
        {
            try
            {
                Provincium temp = _context.Provincia.Single(p => p.ProvinciaId == id);
                _context.Provincia.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public List<Provincium> GetAll()
        {
            return _context.Provincia.ToList();
        }

        public Provincium? GetById(int id)
        {
            Provincium? tmp = null;
            try
            {
                tmp = _context.Provincia.FirstOrDefault(p => p.ProvinciaId == id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tmp;
        }

        public Provincium? GetByCodice(string varCodice)
        {
            return new Provincium();
        }

        public bool Insert(Provincium t)
        {
            try
            {
                _context.Provincia.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Update(Provincium t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
