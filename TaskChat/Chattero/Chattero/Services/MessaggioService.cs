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
        public bool Inserimento(Messaggio imp)
        {
            return _repo.Insert(imp);
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
                    Ora = imp.Orario
                });
            }
            return lista;
        }
        public List<MessaggioDTO> RestituisciTuttiPerStanza(Stanza sta)
        {
            List<MessaggioDTO> lista = new List<MessaggioDTO>();
            foreach (Messaggio imp in _repo.GetAllByRoom(sta))
            {
                lista.Add(new MessaggioDTO()
                {
                    NomUte = imp.NomeUtente,
                    Con = imp.Contenuto,
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
                Ora = temp.Orario
            };
        }
        public Messaggio? GetCodeModel(MessaggioDTO obj)
        {
            return _repo.PrendiDaDatabase(obj);
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
