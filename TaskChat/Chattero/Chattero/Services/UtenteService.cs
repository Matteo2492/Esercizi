using Chattero.DTO;
using Chattero.Models;
using Chattero.Repo;
using System.Security.Cryptography;
using System.Text;

namespace Chattero.Services
{
    public class UtenteService
    {
        private readonly UtenteRepo _repo;
        public UtenteService(UtenteRepo repo)
        {
            _repo = repo;
        }
        public List<Utente> PrendiliTutti()
        {
            return _repo.GetAll();
        }

        public List<UtenteDTO> RestituisciTutto()
        {
            List<UtenteDTO> elenco = this.PrendiliTutti().Select(p => new UtenteDTO()
            {
                CodUte = p.CodiceUtente,
                Use = p.Passw,
                Pas = p.Username,
                IsDel = p.IsDeleted
            }).ToList();

            return elenco;
        }

        public bool LoginUtente(UtenteDTO obj)
        {
            obj.Pas = CalculateMD5Hash(obj.Pas);

            return _repo.CheckLogin(obj) is not null ? true : false;
        }
        public bool RegistraUtente(UtenteDTO obj)
        {
            if (obj is not null)
            {
                try
                {
                    Utente temp = new Utente()
                    {
                        CodiceUtente = Guid.NewGuid().ToString().ToUpper(),
                        Username = obj.Use,
                        Passw = CalculateMD5Hash(obj.Pas),
                        IsDeleted = null
                    };
                    return _repo.Insert(temp);
                }
                catch (Exception ex)
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
                    CodUte = temp.CodiceUtente,
                    Use = temp.Username,
                    Pas = temp.Passw,
                    IsDel = temp.IsDeleted
                };
                if (prodto is not null)
                {
                    return prodto;
                }
            }
            return new UtenteDTO();
        }
        public Utente? GetCodeModel(UtenteDTO obj)
        {
            return _repo.GetCode(obj.Use);
        }
        public bool EliminaPerEmail(UtenteDTO pro)
        {
            Utente? temp = _repo.GetAll().FirstOrDefault(p => p.Username == pro.Use);

            if (temp is not null)
                return _repo.Delete(temp.Username);

            return false;
        }
        public bool AggiornaUtente(UtenteDTO obj)
        {
            if (obj is not null)
            {
                Utente temp = new Utente()
                {
                    CodiceUtente = obj.CodUte,
                    Username = obj.Use,
                    Passw = obj.Pas,
                    IsDeleted = obj.IsDel
                };
                return _repo.Update(temp);
            }
            return false;
        }
        public static string CalculateMD5Hash(string input)
        {

            // Creazione dell'oggetto MD5
            using (MD5 md5 = MD5.Create())
            {
                // Conversione della stringa in un array di byte
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);

                // Calcolo dell'hash MD5
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Converting the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
