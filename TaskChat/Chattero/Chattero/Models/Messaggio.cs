using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chattero.Models
{
    public class Messaggio
    {
        [BsonId]
        public ObjectId MessaggioID { get; set; }
        [BsonElement("nomi")]
        public string? NomeUtente { get; set; }
        [BsonElement("cont")]
        public string? Contenuto { get; set; }
        [BsonElement("stan")]
        public ObjectId? Stanza { get; set; }
        [BsonElement("ora")]
        public DateTime Orario { get; set; } = DateTime.Now;
    }
}
