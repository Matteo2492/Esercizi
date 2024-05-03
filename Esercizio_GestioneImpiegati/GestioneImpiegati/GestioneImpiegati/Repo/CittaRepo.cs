using GestioneImpiegati.Models;

namespace GestioneImpiegati.Repo
{
    public class CittaRepo : IRepo<Cittum>
    {
        private readonly AccLez35GestioneImpiegatiContext _context;

        public CittaRepo(AccLez35GestioneImpiegatiContext ctx)
        {
            _context = ctx;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cittum> GetAll()
        {
            return _context.Citta.ToList();
        }

        public Cittum? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Cittum t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cittum t)
        {
            throw new NotImplementedException();
        }
    }
}
