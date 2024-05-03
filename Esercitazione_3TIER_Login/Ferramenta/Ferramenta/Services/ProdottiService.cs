using Ferramenta.DTO;
using Ferramenta.Models;
using Ferramenta.Repository;

namespace Ferramenta.Services
{
    public class ProdottiService
    {
        private readonly ProdottiRepo _repo;
        public ProdottiService(ProdottiRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Prodotti> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<ProdottiDTO> RestituisciTutto()
        {
            List<ProdottiDTO> elenco = this.PrendiliTutti().Select(p => new ProdottiDTO()
            {
                Cod = p.CodiceProdotto,
                Nom = p.Nome,
                Qua = p.Quantita,
                Pre = p.Prezzo,
                Des = p.Descrizione,
                Cat = p.Categoria
            }).ToList();
            return elenco;
        }

        public ProdottiDTO PerId(int id)
        {
            Prodotti? temp = _repo.Get(id);
            if(temp is not null)
            {
                ProdottiDTO prodto = new ProdottiDTO()
                {
                    Cod = temp.CodiceProdotto,
                    Nom = temp.Nome,
                    Qua = temp.Quantita,
                    Pre = temp.Prezzo,
                    Des = temp.Descrizione,
                    Cat = temp.Categoria
                };
                if (prodto is not null)
                {
                    return prodto;
                }  
            }
            return new ProdottiDTO();
        }

        public bool Inserimento(ProdottiDTO pro)
        {
            if(pro is not null)
            {
                Prodotti temp = new Prodotti()
                {
                    CodiceProdotto = pro.Cod,
                    Nome = pro.Nom,
                    Quantita = pro.Qua,
                    Prezzo = pro.Pre,
                    Descrizione = pro.Des,
                    Categoria = pro.Cat
                };
                return _repo.Create(temp);
            }
            return false;
        }

        public bool EliminaPerId(ProdottiDTO pro)
        {
            Prodotti? temp = _repo.GetAll().FirstOrDefault(p => p.CodiceProdotto == pro.Cod);

            if(temp is not null)
                return _repo.Delete(temp.ProdottoId);

            return false;
        }

        public bool AggiornaProdotto(ProdottiDTO pro)
        {
            if (pro is not null)
            {
                Prodotti temp = new Prodotti()
                {
                    CodiceProdotto = pro.Cod,
                    Nome = pro.Nom,
                    Quantita = pro.Qua,
                    Prezzo = pro.Pre,
                    Descrizione = pro.Des,
                    Categoria = pro.Cat
                };
                return _repo.Update(temp);
            }
            return false;
        }
    }
}
