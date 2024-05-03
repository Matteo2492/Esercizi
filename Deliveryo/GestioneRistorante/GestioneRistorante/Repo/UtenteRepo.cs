using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Repo
{
    public class UtenteRepo : IDal<Utente>
    {
        private readonly DeliveryoContext _context;
        public UtenteRepo(DeliveryoContext ctx)
        {
            _context = ctx;
        }
        public bool Create(Utente entity)
        {
            try
            {
                _context.Utentes.Add(entity);
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
                Utente? temp = GetCode(email);
                if (temp is not null)
                {
                    _context.Utentes.Remove(temp);
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

        public Utente? GetID(int id)
        {
            return _context.Utentes.Find(id);
        }
        public Utente? GetCode(string code)
        {
            return _context.Utentes.Include(s=>s.Ordinis).FirstOrDefault(p => p.Email == code);
        }
 
        public IEnumerable<Utente> GetAll()
        {
            return _context.Utentes.Include(s => s.Ordinis).ToList();
        }

        public bool Update(Utente entity)
        {
            try
            {
                _context.Utentes.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public Utente? CheckLogin(UtenteDTO obj)
        {
            Utente? temp = _context.Utentes.FirstOrDefault(p => p.Email == obj.Ema && p.PasswordUtente == obj.Pas);
            if (temp is not null)
            {
                return temp;
            }
            return temp;
        }
    }
}
