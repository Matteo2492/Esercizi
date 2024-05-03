using Chattero.DTO;
using Chattero.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Chattero.Repo
{
    public class MessaggioRepo : IRepo<Messaggio>
    {
        private IMongoCollection<Messaggio> messaggio;
        private readonly ILogger _logger;
        public MessaggioRepo(IConfiguration config, ILogger<MessaggioRepo> logger)
        {
            this._logger = logger;
            string? connessioneLocale = config.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = config.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.messaggio = _database.GetCollection<Messaggio>("Messaggios");
        }

        public bool DeleteMessaggio(Messaggio item)
        {
            try
            {
                this.messaggio.DeleteOne(i => i.MessaggioID == item.MessaggioID);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public List<Messaggio> GetAll()
        {
            return messaggio.Find(p => true).ToList();
        }
        public List<Messaggio> GetAllByRoom(Stanza t)
        {
            return messaggio.Find(p => true && p.Stanza == t.StanzaID).ToList();
        }
        public bool Insert(Messaggio item)
        {

            try
            {
                messaggio.InsertOne(item);
                _logger.LogInformation("Inserimento effettuato");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
        public Messaggio? TrovaMsg(MessaggioDTO msg)
        {
              return messaggio.Find(p => p.NomeUtente == msg.NomUte && p.Orario == msg.Ora).ToList()[0];  
        }

        public Messaggio? GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Messaggio? GetCode(string code)
        {
            throw new NotImplementedException();
        }

        public bool Update(Messaggio item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string email)
        {
            throw new NotImplementedException();
        }
    }
}
