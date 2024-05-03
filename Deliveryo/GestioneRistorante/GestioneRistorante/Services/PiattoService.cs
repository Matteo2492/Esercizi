using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using GestioneRistorante.Repo;

namespace GestioneRistorante.Services
{
    public class PiattoService
    {
        private readonly PiattoRepo _repo;


        public PiattoService(PiattoRepo rep)
        {
            _repo = rep;

        }
        public IEnumerable<Piatto> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<PiattoDTO> RestituisciTutto(string codice)
        {
            List<PiattoDTO> elenco = this.PrendiliTutti().Where(a=> a.MenuRifNavigation.Codice == codice).Select(p => new PiattoDTO()
            {
                Nom = p.Nome,
                Des = p.Descrizione,
                Pre = p.Prezzo,
                Qua = p.Quantita,
                MenRifNav = new MenuDTO()
                {
                    Cod = p.MenuRifNavigation.Codice
                }
            }).ToList();

            return elenco;
        }
        public PiattoDTO ConvertiPiattoDTO(Piatto temp)
        {
            return new PiattoDTO()
            {
                Nom = temp.Nome,
                Des = temp.Descrizione,
                Pre = temp.Prezzo,
                Qua = temp.Quantita,
 
            };
        }
    }
}
