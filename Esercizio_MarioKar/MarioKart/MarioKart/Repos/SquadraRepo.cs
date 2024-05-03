using MarioKart.Models;

namespace MarioKart.Repos
{
    public class SquadraRepo
    {
        private readonly MarioContext _context;

        public SquadraRepo(MarioContext context)
        {
            _context = context;
        }

        public bool Create(Squadra entity)
        { 
            try
            {

                int spesa = entity.PersonaggioCentoCinquantaRIFNavigation.Costo + entity.PersonaggioCentoRIFNavigation.Costo + entity.PersonaggioCinquantaRIFNavigation.Costo;
                if (entity.Crediti < spesa)
                {
                    return false;
                }

                int numeroSquadre = _context.Squadras.Count();
                if (numeroSquadre >= 3)
                {
                    return false;
                }
                _context.Squadras.Add(entity);
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
                Squadra? temp = Get(id);
                if (temp != null)
                {
                    _context.Squadras.Remove(temp);
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

        public Squadra? Get(int id)
        {
            return _context.Squadras.Find(id);
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadras.ToList();
        }

        public bool Update(Squadra entity)
        {
            try
            {
                int spesa = entity.PersonaggioCentoCinquantaRIFNavigation.Costo + entity.PersonaggioCentoRIFNavigation.Costo + entity.PersonaggioCinquantaRIFNavigation.Costo;
                if (entity.Crediti < spesa)
                {
                    return false;
                }

                var existingEntity = _context.Squadras.Local.FirstOrDefault(e => e.SquadraID == entity.SquadraID);
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

        public Squadra? GetByNome(string codice)
        {
            try
            {
                return _context.Squadras.FirstOrDefault(p => p.Username == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
