using Chattero.DTO;
using Chattero.Models;
using Chattero.Repo;
using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;

namespace Chattero.Services
{
    public class MessaggioService
    {
        private readonly MessaggioRepo _repo;
        public MessaggioService(MessaggioRepo repo)
        {
            _repo = repo;
        }
        public bool Inserimento(MessaggioDTO imp)
        {
            Messaggio temp = new Messaggio()
            {
                NomeUtente = imp.NomUte,
                Contenuto = imp.Con,
                Stanza = imp.Sta,
                Orario = imp.Ora
            };
            return _repo.Insert(temp);
        }
     
        public List<MessaggioDTO> RestituisciTutti()
        {
            List<MessaggioDTO> lista = new List<MessaggioDTO>();
            foreach (Messaggio imp in _repo.GetAll())
            {
                lista.Add(new MessaggioDTO()
                {
                    NomUte = imp.NomeUtente,
                    Con = imp.Contenuto,
                    Sta = imp.Stanza,
                    Ora = imp.Orario
                });
            }
            return lista;
        }
        public MessaggioDTO ConvertiMsgDTO(Messaggio temp)
        {
            return new MessaggioDTO()
            {
                NomUte = temp.NomeUtente,
                Con = temp.Contenuto,
                Sta = temp.Stanza,
                Ora = temp.Orario
            };
        }
        public Messaggio? GetCodeModel(MessaggioDTO obj)
        {
            return _repo.TrovaMsg(obj);
        }
        public bool EliminaMessaggio(MessaggioDTO objDto)
        {
            return _repo.DeleteMessaggio(new Messaggio()
            {
                NomeUtente = objDto.NomUte,
                Orario = objDto.Ora
            });
        }
    }
}
