using GestioneRistorante.Models;

namespace GestioneRistorante.DTO
{
    public class PiattoDTO
    {
        public string Nom { get; set; } = null!;

        public string? Des { get; set; }

        public decimal? Pre { get; set; }

        public int? Qua { get; set; }

        public virtual MenuDTO MenRifNav { get; set; } = null!;

        public virtual ICollection<OrdiniDTO> OrdRif { get; set; } = new List<OrdiniDTO>();
    }
}
