using Chattero.DTO;
using Chattero.Models;
using Chattero.Repo;
using MongoDB.Bson;

namespace Chattero.Services
{
    public class StanzaService
    {
        private readonly StanzaRepo _repo;
        private readonly MessaggioService _serviceMsg;
        private readonly UtenteService _serviceUte;
        public StanzaService(StanzaRepo repo, MessaggioService msgrepo, UtenteService uterepo)
        {
            _repo = repo;
            _serviceMsg = msgrepo;
            _serviceUte = uterepo;
        }
        public bool Inserimento(StanzaDTO imp)
        {
            Stanza temp = new Stanza()
            {
                NomeStanza = imp.NomSta,
                Descrizione = imp.Desc,
                Creatore = imp.Cre,
                DataCreazione = DateOnly.FromDateTime(DateTime.Now),
                ListaUtente = new List<string>()
                {
                    new string (imp.Cre)
                },
            };
            return _repo.Insert(temp);
        }
        public bool AggiungiPartecipante(string room, string u)
        {
            Stanza? rom = _repo.GetCode(room);
            Utente? ute = _serviceUte.GetCodeModel(_serviceUte.PerEmail(u));

            if (rom is not null && ute is not null)
            {
                if (rom.ListaUtente.Contains(ute.Username))
                    return false;
                else
                    return _repo.AggiungiPartecipante(rom, ute);
            }

            return false;

        }
        public Stanza? GetByNome(string nome)
        {
            return _repo.GetCode(nome);
        }
        public Stanza? GetByObjectId(ObjectId id)
        {
            return _repo.GetByObjectId(id);
        }
        public bool UtenteContenuto(string room, string u)
        {
            Stanza? r = this.GetByNome(room);
            Utente? ute = _serviceUte.GetCodeModel(_serviceUte.PerEmail(u));

            if (r is not null && ute is not null && r.ListaUtente.Contains(ute.Username))
                return true;
            else
                return false;
        }
        public StanzaDTO? RestuisciStanza(StanzaDTO objdto)
        {
            Stanza? imp = _repo.GetCode(objdto.NomSta);
            if (imp is not null)
            {
                return new StanzaDTO()
                {
                    NomSta = imp.NomeStanza,
                    Desc = imp.Descrizione,
                    Datcre = imp.DataCreazione,
                    LisMsg = imp.ListaMessaggi,
                    LisUte = imp.ListaUtente,
                    Cre = imp.Creatore
                };
            }
            return null;
        }
        public bool ModificaRoom(StanzaDTO dto)
        {
            return _repo.Update(new Stanza()
            {
                NomeStanza = dto.NomSta,
                ListaMessaggi = dto.LisMsg
            });
        }
        public List<StanzaDTO> GetAll()
        {
            return _repo.GetAll().Select(r => new StanzaDTO()
            {
                NomSta = r.NomeStanza,
                Desc = r.Descrizione,
                Datcre = r.DataCreazione,
                Cre = r.Creatore,
                LisMsg = r.ListaMessaggi,
                LisUte = r.ListaUtente
            }).ToList();
        }
        public bool AssegnaCreatore(StanzaDTO dto)
        {
            if (dto is not null && dto.Cre is not null)
            {
                dto.LisUte.Add(dto.Cre);
                return this.ModificaRoom(dto);
            }
            return false;
        }
        public bool EliminaStanza(StanzaDTO objDto)
        {
            if(objDto.NomSta is not null)
                return _repo.Delete(objDto.NomSta);
            return false;
        }
        public bool ModificaStanza(StanzaDTO objdto)
        {
            return _repo.Update(new Stanza()
            {
                NomeStanza = objdto.NomSta,
                Descrizione = objdto.Desc
            });
        }
        public List<ObjectId> RecuperaTuttiMsgPerStanza(StanzaDTO s)
        {
            return s.LisMsg;
        }
        public bool InserisciMessaggio(StanzaDTO stanza, MessaggioDTO mex)
        {
            Stanza? temp = _repo.GetCode(stanza.NomSta);
            Messaggio? mesgtemp = _serviceMsg.GetCodeModel(mex);
            if(temp is not null && mesgtemp is not null)
            {
                temp.ListaMessaggi.Add(mesgtemp.MessaggioID);
                _repo.Update(temp);
                return _serviceMsg.Inserimento(new MessaggioDTO()
                {
                    NomUte = mex.NomUte,
                    Sta = temp.StanzaID,
                    Con = mex.Con,
                    Ora = DateTime.Now
                });
            }
            return false;
        }
        public bool CreaGlobal()
        {
            return _repo.CreateGlobal();
        }
    }
}
