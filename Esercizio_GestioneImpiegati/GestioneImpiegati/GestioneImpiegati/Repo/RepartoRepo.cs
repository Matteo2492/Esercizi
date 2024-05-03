using GestioneImpiegati.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneImpiegati.Repo
{
    public class RepartoRepo : IRepo<Reparto>
    {
        private readonly AccLez35GestioneImpiegatiContext _context;

        public RepartoRepo(AccLez35GestioneImpiegatiContext ctx)
        {
            _context = ctx;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reparto> GetAll()
        {
            return _context.Repartos.ToList();
        }

        public Reparto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Reparto t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reparto t)
        {
            throw new NotImplementedException();
        }
    }
}
