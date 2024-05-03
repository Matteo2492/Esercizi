using System.ComponentModel.DataAnnotations.Schema;

namespace MarioKart.Models
{
    [Table("Personaggio")]
    public class Personaggio
    {
        public int PersonaggioID { get; set; }

        public string Nome { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public int Costo { get; set; }

        public string Descrizione { get; set; } = null!;
    }
}
