using Chattero.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Chattero.DTO
{
    public class StanzaDTO
    {
        [Required]
        [StringLength(250)]
        public string? NomSta { get; set; }

        [Required]
        [StringLength(250)]
        public string? Desc { get; set; }

        public List<ObjectId> LisMsg = new List<ObjectId>();

        public List<string> LisUte { get; set; } = new List<string>() ;

        [Required]
        [StringLength(250)]
        public string? Cre { get; set; }

        public DateOnly? Datcre { get; set; }

        public DateTime? IsDel { get; set; } = null;
    }
}
