using MarioKart.Models;

namespace MarioKart.DTO
{
    public class SquadraDTO
    {
        public string Use { get; set; } = null!;
        public int Cre { get; set; } = 10;
        public int? PersonaggioCinquantaRIFDTO { get; set; } = null!;
        public int? PersonaggioCentoRIFDTO { get; set; } = null!;
        public int? PersonaggioCentoCinquantaRIFDTO { get; set; } = null!;
        public PersonaggioDTO PersonaggioCinquantaRIFNavigation { get; set; } = null!;
        public PersonaggioDTO PersonaggioCentoRIFNavigation { get; set; } = null!;
        public PersonaggioDTO PersonaggioCentoCinquantaRIFNavigation { get; set; } = null!;
    }
}
