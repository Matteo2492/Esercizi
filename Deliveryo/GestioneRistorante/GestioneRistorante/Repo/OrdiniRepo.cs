using GestioneRistorante.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Repo
{
    public class OrdiniRepo
    {
        private readonly DeliveryoContext _context;
        public OrdiniRepo(DeliveryoContext ctx)
        {
            _context = ctx;
        }
        public bool Create(Ordini entity)
        {
            try
            {
                _context.Ordinis.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Delete(string email)
        {
            try
            {
                Ordini? temp = GetCode(email);
                if (temp is not null)
                {
                    _context.Ordinis.Remove(temp);
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

        public Ordini? GetID(int id)
        {
            return _context.Ordinis.Find(id);
        }
        public Ordini? GetCode(string code)
        {
            return _context.Ordinis.Include(s => s.PiattoRifs).FirstOrDefault(p => p.Codice == code);
        }

        public IEnumerable<Ordini> GetAll()
        {
            return _context.Ordinis.Include(s => s.PiattoRifs).ToList();
        }

        public bool Update(Ordini entity)
        {
            try
            {
                _context.Ordinis.Update(entity);
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
