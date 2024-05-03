using GestioneImpiegati.Models;
using GestioneImpiegati.Repo;

namespace GestioneImpiegati.Services
{
    public class CittaService
    {
        private readonly CittaRepo _repository;

        public CittaService(CittaRepo repo)
        {
            _repository = repo;
        }

        public List<Cittum> ElencoCitta()
        {
            return _repository.GetAll();
        }
    }
}
