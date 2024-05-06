using Ferramenta.DTO;
using Ferramenta.Models;

namespace Ferramenta.Repository
{
    public class UtenteRepo : IRepo<Utente>
    {
        private readonly FerramentaContext _context;
        public UtenteRepo(FerramentaContext ctx)
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

        public bool Delete(int id)
        {
            try
            {
                Utente? temp = _context.Utentes.FirstOrDefault(p => p.UtenteId == id);
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

        public Utente? Get(int id)
        {
            return _context.Utentes.Find(id);
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utentes.ToList();
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
            Utente? temp = _context.Utentes.FirstOrDefault(p => p.Username == obj.Username && p.PasswordUtente == obj.PasswordUtente);
            if (temp is not null)
            {
                return temp;
            }
            return temp;
        }
    }
}
