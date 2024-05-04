using Chattero.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Chattero.Repo
{
    public class StanzaRepo : IRepo<Stanza>
    {
        private IMongoCollection<Stanza> stanza;
        private readonly ILogger _logger;
        public StanzaRepo(IConfiguration config, ILogger<StanzaRepo> logger)
        {
            this._logger = logger;
            string? connessioneLocale = config.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = config.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.stanza = _database.GetCollection<Stanza>("Stanze");
        }

        public bool DeleteStanza(Stanza item)
        {
            try
            {
                item.IsDeleted = DateTime.Now;
                Update(item);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public List<Stanza> GetAll()
        {
            return stanza.Find(p => true && p.IsDeleted == null).ToList();
        }
        public List<Stanza> GetAllUte(string nome)
        {
            return stanza.Find(p=> true && p.Creatore == nome).ToList();
        }
        public List<Stanza> GetAllP(string nome)
        {
            return GetAll().FindAll(p => p.ListaUtente.Contains(nome));
        }
        public bool Insert(Stanza item)
        {

            try
            {
                stanza.InsertOne(item);
                _logger.LogInformation("Inserimento effettuato");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public bool Update(Stanza item)
        {
            Stanza? temp = GetCode(item.NomeStanza);
            if (temp is not null)
            {
                temp.NomeStanza = item.NomeStanza != null ? item.NomeStanza : temp.NomeStanza;
                temp.Descrizione = item.Descrizione != null ? item.Descrizione : temp.Descrizione;
                temp.IsDeleted = item.IsDeleted != null ? item.IsDeleted : temp.IsDeleted;
                temp.ListaMessaggi = item.ListaMessaggi != null ? item.ListaMessaggi : temp.ListaMessaggi;
                foreach (string p in item.ListaUtente)
                {
                    if (!temp.ListaUtente.Contains(p))
                        temp.ListaUtente.Add(p);
                }
                var filter = Builders<Stanza>.Filter.Eq(i => i.StanzaID, temp.StanzaID);
                try
                {
                    stanza.ReplaceOne(filter, temp);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

            }
            return false;
        }
        public bool AggiungiPartecipante(Stanza r, Utente t)
        {
            try
            {
                Stanza? temp = this.GetCode(r.NomeStanza);
                if (temp is not null)
                {
                    temp.ListaUtente.Add(t.Username);
                    this.Update(temp);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public Stanza? GetCode(string? nome)
        {
            try
            {
                return stanza.Find(a => a.NomeStanza == nome && a.IsDeleted == null).ToList()[0];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
  
        public Stanza? GetByObjectId(ObjectId id)
        {
            return stanza.Find(r => r.StanzaID == id).ToList()[0];
        }
        public bool CreateGlobal()
        {
            return this.Insert(new Stanza()
            {
                NomeStanza = "Global",
                Descrizione = "Global chat.",
                Creatore = "JESUS",
                DataCreazione = DateOnly.MinValue,
                IsDeleted = null
            });
        }

        public bool InserisciMessagio(Stanza sta,Messaggio msg)
        {
            try
            {
                Stanza? temp = GetCode(sta.NomeStanza);
                var filter = Builders<Stanza>.Filter.Eq(s => s.StanzaID, temp.StanzaID);
                temp.ListaMessaggi.Add(msg.MessaggioID);
                stanza.ReplaceOne(filter, temp);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
        public bool Delete(string email)
        {
            throw new NotImplementedException();
        }

        public Stanza? GetId(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
