using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using GestioneRistorante.Repo;

namespace GestioneRistorante.Services
{
    public class RistoranteService
    {
        private readonly RistoranteRepo _repo;
        private readonly MenuService _serviceMenu;
        public RistoranteService(RistoranteRepo repo, MenuService servomenu)
        {
            _repo = repo;
            _serviceMenu = servomenu;
        }
        public IEnumerable<Ristorante> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<RistoranteDTO> RestituisciTutto()
        {
            List<RistoranteDTO> elenco = this.PrendiliTutti().Select(p => new RistoranteDTO()
            {
                Cod = p.Codice,
                Nom = p.Nome,
                TipCuc = p.TipoCucina,
                Des = p.Descrizione,
                OraApe = p.OrarioApertura,
                OraChi = p.OrarioChiusura,
                Men = p.Menus.Select(m => _serviceMenu.ConvertiMenuDTO(m)).ToList()
            }).ToList();

            return elenco;
        }
        public RistoranteDTO ConvertiRistoranteDTO(Ristorante ris)
        {
            return new RistoranteDTO()
            {
                Cod = ris.Codice,
                Nom = ris.Nome,
                TipCuc = ris.TipoCucina,
                Des = ris.Descrizione,
                OraApe = ris.OrarioApertura,
                OraChi = ris.OrarioChiusura,
            };
        }
        public RistoranteDTO PerCodice(string cod)
        {
            Ristorante? temp = _repo.GetCode(cod);
            if (temp is not null)
            {
                RistoranteDTO prodto = new RistoranteDTO()
                {
                    Cod = temp.Codice,
                    Nom = temp.Nome,
                    TipCuc = temp.TipoCucina,
                    Des = temp.Descrizione,
                    OraApe = temp.OrarioApertura,
                    OraChi = temp.OrarioChiusura
                };
                if (prodto is not null)
                {
                    return prodto;
                }
            }
            return new RistoranteDTO();
        }
        public bool EliminaPerCodice(RistoranteDTO pro)
        {
            Ristorante? temp = _repo.GetAll().FirstOrDefault(p => p.Codice == pro.Cod);

            if (temp is not null)
                return _repo.Delete(temp.Codice);

            return false;
        }

        public bool AggiornaRistorante(RistoranteDTO pro)
        {
            if (pro is not null)
            {
                Ristorante temp = new Ristorante()
                {
                    Codice = pro.Cod,
                    Nome = pro.Nom,
                    TipoCucina = pro.TipCuc,
                    Descrizione = pro.Des,
                    OrarioApertura = pro.OraApe,
                    OrarioChiusura = pro.OraChi
                };
                return _repo.Update(temp);
            }
            return false;
        }
    }
}
