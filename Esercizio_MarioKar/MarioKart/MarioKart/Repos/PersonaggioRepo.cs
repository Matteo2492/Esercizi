using MarioKart.Models;
using Microsoft.EntityFrameworkCore;

namespace MarioKart.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        private readonly MarioContext _context;

        public PersonaggioRepo(MarioContext context)
        {
            _context = context;
        }

        public bool Create(Personaggio entity)
        {
           
            try
            {
                _context.Persionaggios.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Personaggio? temp = Get(id);
                if (temp != null)
                {
                    _context.Persionaggios.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return false;
        }

        public Personaggio? Get(int id)
        {
            return _context.Persionaggios.Find(id);
        }

        public IEnumerable<Personaggio> GetAll()
        {
            return _context.Persionaggios.ToList();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                var existingEntity = _context.Persionaggios.Local.FirstOrDefault(e => e.PersonaggioID == entity.PersonaggioID);
                if (existingEntity == null)
                {
                    _context.Update(entity);
                }
                else
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Personaggio? GetByNome(string codice)
        {
            try
            {
                return _context.Persionaggios.FirstOrDefault(p => p.Nome == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public List<Squadra> GetAllPerGiocatori()
        {
            return _context.Squadras.Include(p => p.PersonaggioCentoCinquantaRIF).ToList();
        }
    }
}
