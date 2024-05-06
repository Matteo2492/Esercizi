using Ferramenta.DTO;
using Ferramenta.Models;
using Ferramenta.Repository;

namespace Ferramenta.Services
{
    public class UtenteService
    {
        private readonly UtenteRepo _repo;
        public UtenteService(UtenteRepo repo)
        {
            _repo = repo;
        }

        public bool PerId(UtenteDTO obj)
        {
            return _repo.CheckLogin(obj) is not null ? true : false;
        }
    }
}
