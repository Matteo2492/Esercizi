using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Repo
{
    public class RistoranteRepo
    {
        private readonly DeliveryoContext _context;
        public RistoranteRepo(DeliveryoContext ctx)
        {
            _context = ctx;
        }
        public bool Create(Ristorante entity)
        {
            try
            {
                _context.Ristorantes.Add(entity);
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
                Ristorante? temp = GetCode(email);
                if (temp is not null)
                {
                    _context.Ristorantes.Remove(temp);
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

        public Ristorante? GetID(int id)
        {
            return _context.Ristorantes.Find(id);
        }
        public Ristorante? GetCode(string code)
        {
            return _context.Ristorantes.Include(s => s.Menus).FirstOrDefault(p => p.Codice == code);
        }

        public IEnumerable<Ristorante> GetAll()
        {
            return _context.Ristorantes.Include(s => s.Menus).ToList();
        }

        public bool Update(Ristorante entity)
        {
            try
            {
                _context.Ristorantes.Update(entity);
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
