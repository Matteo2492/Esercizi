using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using GestioneRistorante.Repo;

namespace GestioneRistorante.Services
{
    public class UtenteService
    {
        private readonly UtenteRepo _repo;
        private readonly OrdiniService _serviceOrdini;
        public UtenteService(UtenteRepo repo, OrdiniService serviceOrdini)
        {
            _repo = repo;
            _serviceOrdini = serviceOrdini;
        }
        public IEnumerable<Utente> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<UtenteDTO> RestituisciTutto()
        {
            List<UtenteDTO> elenco = this.PrendiliTutti().Select(p => new UtenteDTO()
            {
                Nom = p.Nome,
                Ema = p.Email,
                Pas = p.PasswordUtente,
                Ord = p.Ordinis.Select(m=>_serviceOrdini.ConvertiOrdineDTO(m)).ToList()
            }).ToList();

            return elenco;
        }
        public UtenteDTO ConvertiUtenteDTO(Utente temp)
        {
            return new UtenteDTO()
            {
                Nom = temp.Nome,
                Ema = temp.Email,
                Pas = temp.PasswordUtente
            };
        }
        public bool LoginUtente(UtenteDTO obj)
        {
            return _repo.CheckLogin(obj) is not null ? true : false;
        }
        public bool RegistraUtente(UtenteDTO obj)
        {
            if(obj is not null)
            {
                try
                {
                    Utente temp = new Utente()
                    {
                        Nome = obj.Nom,
                        Email = obj.Ema,
                        PasswordUtente = obj.Pas
                    };
                    return _repo.Create(temp);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return false;
        }
        public UtenteDTO PerEmail(string email)
        {
            Utente? temp = _repo.GetCode(email);
            if (temp is not null)
            {
                UtenteDTO prodto = new UtenteDTO()
                {
                    Nom = temp.Nome,
                    Ema = temp.Email,
                    Pas = temp.PasswordUtente
                };
                if (prodto is not null)
                {
                    return prodto;
                }
            }
            return new UtenteDTO();
        }
        public bool EliminaPerEmail(UtenteDTO pro)
        {
            Utente? temp = _repo.GetAll().FirstOrDefault(p => p.Email == pro.Ema);

            if (temp is not null)
                return _repo.Delete(temp.Email);

            return false;
        }

        public bool AggiornaUtente(UtenteDTO pro)
        {
            if (pro is not null)
            {
                Utente temp = new Utente()
                {
                    Nome = pro.Nom,
                    Email = pro.Ema,
                    PasswordUtente = pro.Pas,
                };
                return _repo.Update(temp);
            }
            return false;
        }
    }
}
