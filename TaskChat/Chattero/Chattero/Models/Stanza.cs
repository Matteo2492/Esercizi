using Chattero.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chattero.Models
{
    public class Stanza
    {
        [BsonId]
        public ObjectId StanzaID { get; set; }
        [BsonElement("nomsta")]
        public string? NomeStanza { get; set; }
        [BsonElement("desc")]
        public string? Descrizione { get; set; }
        [BsonElement("listMsg")]
        public List<ObjectId> ListaMessaggi { get; set; } = new List<ObjectId>();
        [BsonElement("lisUte")]
        public List<string> ListaUtente { get; set; } = new List<string>();
        [BsonElement("creatore")]
        public string? Creatore { get; set; }
        [BsonElement("datcre")]
        public DateOnly DataCreazione { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}
