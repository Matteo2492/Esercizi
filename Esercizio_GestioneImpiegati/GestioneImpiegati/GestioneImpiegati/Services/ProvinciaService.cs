using GestioneImpiegati.Models;
using GestioneImpiegati.Repo;

namespace GestioneImpiegati.Services
{
    public class ProvinciaService
    {
        private readonly ProvinciaRepo _repository;

        public ProvinciaService(ProvinciaRepo repo)
        {
            _repository = repo;
        }

        public List<Provincium> ElencoProvince()
        {
            return _repository.GetAll();
        }

        public bool InserisciProvincia(Provincium pro)
        {
            return _repository.Insert(pro);
        }

        public bool EliminaProvinciaperID(int varID)
        {
            Provincium? temp = _repository.GetById(varID);
            if (temp == null)
                return false;

            return _repository.Delete(temp.ProvinciaId);
        }

        public bool ModificaProvincia(Provincium vecchio, Provincium nuovo)
        {
            vecchio.Sigla = nuovo.Sigla;
 
            return _repository.Update(vecchio);
        }
    }
}
