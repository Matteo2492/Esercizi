using GestioneImpiegati.Models;
using GestioneImpiegati.Repo;

namespace GestioneImpiegati.Services
{
    public class RepartoService
    {
        private readonly RepartoRepo _repository;

        public RepartoService(RepartoRepo repository)
        {
            _repository = repository;
        }

        public List<Reparto> ElencoReparti()
        {
            return _repository.GetAll();
        }
    }
}
