using System.ComponentModel.DataAnnotations;

namespace Chattero.DTO
{
    public class UtenteDTO
    {
        [StringLength(250)]
        public string? CodUte { get; set; }
        [Required]
        [StringLength(250)]
        public string Use { get; set; } = null!;
        [Required]
        [StringLength(250)]
        public string Pas { get; set; } = null!;
        public DateTime? IsDel { get; set; } = null;
    }
}
