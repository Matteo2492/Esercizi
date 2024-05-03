using Chattero.DTO;
using Chattero.Models;

namespace Chattero.Repo
{
    public class UtenteRepo : IRepo<Utente>
    {
        private readonly ChatteroContext _context;
        public UtenteRepo(ChatteroContext ctx)
        {
            _context = ctx;
        }
        public bool Insert(Utente entity)
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
                    temp.IsDeleted = DateTime.Now;
                    _context.Utentes.Update(temp);
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

        public Utente? GetId(int id)
        {
            Utente? temp = _context.Utentes.Find(id);
            if(temp is not null && temp.IsDeleted == null)
            {
                return temp;
            }
            return temp;
        }
        public Utente? GetCode(string code)
        {
            return _context.Utentes.FirstOrDefault(p => p.Username == code && p.IsDeleted == null);
        }

        public List<Utente> GetAll()
        {
            return _context.Utentes.Where(p => p.IsDeleted == null).ToList();
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
            Utente? temp = _context.Utentes.FirstOrDefault(p => p.Username == obj.Use && p.Passw == obj.Pas);
            if (temp is not null)
            {
                return temp;
            }
            return temp;
        }
    }
}
