using Ferramenta.Models;

namespace Ferramenta.Repository
{
    public class ProdottiRepo : IRepo<Prodotti>
    {
        private readonly FerramentaContext _context;
        public ProdottiRepo(FerramentaContext ctx)
        { 
            _context = ctx;
        }
        public bool Create(Prodotti entity)
        {
            try
            {
                _context.Prodottis.Add(entity);
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
                Prodotti? temp = _context.Prodottis.FirstOrDefault(p => p.ProdottoId == id);
                if(temp is not null)
                {
                    _context.Prodottis.Remove(temp);
                    _context.SaveChanges();
                    return true;
                }   
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Prodotti? Get(int id)
        {
            return _context.Prodottis.Find(id);
        }

        public IEnumerable<Prodotti> GetAll()
        {
            return _context.Prodottis.ToList();
        }
       
        public bool Update(Prodotti entity)
        {
            try
            {
                _context.Prodottis.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
