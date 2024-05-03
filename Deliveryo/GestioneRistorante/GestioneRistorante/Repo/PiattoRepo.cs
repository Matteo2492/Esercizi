using GestioneRistorante.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Repo
{
    public class PiattoRepo
    {
        private readonly DeliveryoContext _context;
        public PiattoRepo(DeliveryoContext ctx)
        {
            _context = ctx;
        }
        public bool Create(Piatto entity)
        {
            try
            {
                _context.Piattos.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Delete(int email)
        {
            try
            {
                Piatto? temp = GetID(email);
                if (temp is not null)
                {
                    _context.Piattos.Remove(temp);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Piatto? GetID(int id)
        {
            return _context.Piattos.Include(s => s.OrdineRifs).FirstOrDefault(p => p.PiattoId == id);
        }
    

        public IEnumerable<Piatto> GetAll()
        {
            return _context.Piattos.Include(s => s.MenuRifNavigation).Include(s=>s.OrdineRifs).ToList();
        }

        public bool Update(Piatto entity)
        {
            try
            {
                _context.Piattos.Update(entity);
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
