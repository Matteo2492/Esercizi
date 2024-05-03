using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Chattero.DTO
{
    public class MessaggioDTO
    {
        [Required]
        [StringLength(250)]
        public string? NomUte { get; set; }
        [StringLength(500)]
        public string? Con { get; set; }
        [Required]
        public ObjectId? Sta { get; set; }
        [Required]
        public DateTime Ora { get; set; } = DateTime.Now;
    }
}
