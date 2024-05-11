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
        public bool RimuoviParatecipantne(string room, string u)
        {
            Stanza? rom = _repo.GetCode(room);
            Utente? ute = _serviceUte.GetCodeModel(_serviceUte.PerEmail(u));

            if (rom is not null && ute is not null)
            {
                if (rom.ListaUtente.Contains(ute.Username))
                    return _repo.Rimuovi(rom, ute);
                return false;                 
            }

            return false;

        }
        public Stanza? GetByNome(string nome)
        {
            return _repo.GetCode(nome);
        }
        public StanzaDTO? RitornaDto(string nome)
        {
            Stanza? stanza = _repo.GetCode(nome);
            if( stanza is not null)
            {
                StanzaDTO temp = new StanzaDTO()
                {
                    NomSta = stanza.NomeStanza,
                    Desc = stanza.Descrizione,
                    Cre = stanza.Creatore,
                    Datcre = stanza.DataCreazione,
                    LisMsg = stanza.ListaMessaggi,
                    LisUte = stanza.ListaUtente
                    
                };
                return temp;
            }
            return new StanzaDTO();      
        }
        public bool Modifica(StanzaDTO objdto)
        {
            return _repo.Update(new Stanza()
            {
                NomeStanza = objdto.NomSta,
                Descrizione = objdto.Desc
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
        public List<StanzaDTO> GetAllByCreatore(string nome)
        {
            if(nome is not null)
            {
                return _repo.GetAllUte(nome).Select(r => new StanzaDTO()
                {
                    NomSta = r.NomeStanza,
                    Desc = r.Descrizione,
                    Datcre = r.DataCreazione,
                    Cre = r.Creatore,
                    LisMsg = r.ListaMessaggi,
                    LisUte = r.ListaUtente,
                    IsDel = r.IsDeleted
                }).ToList();
            }
            return new List<StanzaDTO>();
        }
        public List<StanzaDTO> GetAllP(string nome)
        {
            if (nome is not null)
            {
                return _repo.GetAllP(nome).Select(r => new StanzaDTO()
                {
                    NomSta = r.NomeStanza,
                    Desc = r.Descrizione,
                    Datcre = r.DataCreazione,
                    Cre = r.Creatore,
                    LisMsg = r.ListaMessaggi,
                    LisUte = r.ListaUtente
                }).ToList();
            }
            return new List<StanzaDTO>();
        }
        public List<StanzaDTO>? NonAppartiene(string username)
        {
            List<Stanza> rooms = _repo.GetAll();

            List<StanzaDTO> dtos = new List<StanzaDTO>();

            foreach (Stanza r in rooms)
            {
                if (!r.ListaUtente.Contains(username))
                    dtos.Add(new StanzaDTO()
                    {
                        NomSta = r.NomeStanza,
                        Cre = r.Creatore,
                        Datcre = r.DataCreazione,
                        Desc = r.Descrizione,
                        LisMsg = r.ListaMessaggi,
                        LisUte = r.ListaUtente
                    });
            }
            return dtos;
        }
        public bool EliminaSta(string nome)
        {
            Stanza? temp = GetByNome(nome);
            if (temp is not null && temp.IsDeleted == null)
            {
                
                return _repo.DeleteStanza(temp);
            }
                
            return false;
        }
       
        public List<MessaggioDTO> RecuperaTuttiMsgPerStanza(string s)
        {
            Stanza? temp = GetByNome(s);
            if(temp is not null && temp.ListaMessaggi is not null)
                return _serviceMsg.RestituisciTuttiPerStanza(temp);
            return new List<MessaggioDTO>();
        }

        public bool InserisciMessaggio(MessaggioDTO mex)
        {
            Stanza? temp = _repo.GetCode(mex.Sta);
            if(temp is not null)
            {
                Messaggio? mesgtemp = new Messaggio()
                {
                    NomeUtente = mex.NomUte,
                    Contenuto = mex.Con,
                    Orario = mex.Ora,
                    Stanza = temp.StanzaID
                };
                if (temp is not null && mesgtemp is not null)
                {
                    if (_serviceMsg.Inserimento(mesgtemp))
                    {
                        if (_repo.InserisciMessagio(temp, mesgtemp))
                        {
                            return true;
                        }
                    }
                }
            }
           
            
            return false;
        }
        public bool CreaGlobal()
        {
            return _repo.CreateGlobal();
        }
    }
}
