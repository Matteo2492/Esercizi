using System.ComponentModel.DataAnnotations.Schema;

namespace MarioKart.Models
{
    [Table("Squadra")]
    public class Squadra
    {
        public int SquadraID { get; set; }
        public string Username { get; set; } = null!;
        public int Crediti { get; set; } = 10;
        public int? PersonaggioCinquantaRIF { get; set; } = null!;
        public int? PersonaggioCentoRIF { get; set; } = null!;
        public int? PersonaggioCentoCinquantaRIF { get; set; } = null!;
        public Personaggio PersonaggioCinquantaRIFNavigation { get; set; } = null!;
        public Personaggio PersonaggioCentoRIFNavigation { get; set; } = null!;
        public Personaggio PersonaggioCentoCinquantaRIFNavigation { get; set; } = null!;
    }
}
