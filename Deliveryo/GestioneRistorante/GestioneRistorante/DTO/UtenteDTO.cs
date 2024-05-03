using GestioneRistorante.Models;
using System.Text.Json.Serialization;

namespace GestioneRistorante.DTO
{
    public class UtenteDTO
    {
        public string Nom { get; set; } = null!;

        public string Ema { get; set; } = null!;

        public string Pas { get; set; } = null!;
      
        public virtual ICollection<OrdiniDTO> Ord { get; set; } = new List<OrdiniDTO>();
    }
}
