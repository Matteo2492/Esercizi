using GestioneRistorante.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Repo
{
    public class MenuRepo
    {
        private readonly DeliveryoContext _context;
        public MenuRepo(DeliveryoContext ctx)
        {
            _context = ctx;
        }
        public bool Create(Menu entity)
        {
            try
            {
                _context.Menus.Add(entity);
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
                Menu? temp = GetCode(email);
                if (temp is not null)
                {
                    _context.Menus.Remove(temp);
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

        public Menu? GetID(int id)
        {
            return _context.Menus.Find(id);
        }
        public Menu? GetCode(string code)
        {
            return _context.Menus.Include(s => s.Piattos).FirstOrDefault(p => p.Codice == code);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _context.Menus.Include(s => s.Piattos).ToList();
        }

        public bool Update(Menu entity)
        {
            try
            {
                _context.Menus.Update(entity);
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
