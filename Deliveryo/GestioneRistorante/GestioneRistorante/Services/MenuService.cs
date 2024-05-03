using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using GestioneRistorante.Repo;

namespace GestioneRistorante.Services
{
    public class MenuService
    {
        private readonly MenuRepo _repo;
        private readonly PiattoService _servicePiatto;
        public MenuService(MenuRepo repo,PiattoService pia)
        {
            _repo = repo;
            _servicePiatto = pia;
        }
        public IEnumerable<Menu> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<MenuDTO> RestituisciTutto()
        {
            List<MenuDTO> elenco = this.PrendiliTutti().Select(p => new MenuDTO()
            {
                Cod = p.Codice,
                Pia = p.Piattos.Select(m=>_servicePiatto.ConvertiPiattoDTO(m)).ToList(),
            }).ToList();

            return elenco;
        }
        public MenuDTO ConvertiMenuDTO(Menu men)
        {
            return new MenuDTO()
            {
                Cod = men.Codice,
                Pia = _servicePiatto.RestituisciTutto(men.Codice)
            };
        }
        
        public MenuDTO PerCodice(string cod)
        {
            Menu? temp = _repo.GetCode(cod);
            if (temp is not null)
            {
                MenuDTO prodto = new MenuDTO()
                {
                    Cod = temp.Codice,
                    Pia = temp.Piattos.Select(m => _servicePiatto.ConvertiPiattoDTO(m)).ToList()
                };
                if (prodto is not null)
                {
                    return prodto;
                }
            }
            return new MenuDTO();
        }
        public bool EliminaPerCodice(MenuDTO pro)
        {
            Menu? temp = _repo.GetAll().FirstOrDefault(p => p.Codice == pro.Cod);

            if (temp is not null)
                return _repo.Delete(temp.Codice);

            return false;
        }

        public bool AggiornaRistorante(MenuDTO pro)
        {
            if(pro is not null) {

                Menu? temp = _repo.GetCode(pro.Cod);

                if (temp is not null)
                {
                    return _repo.Update(temp);
                }
            }      
            return false;
        }
    }
}
