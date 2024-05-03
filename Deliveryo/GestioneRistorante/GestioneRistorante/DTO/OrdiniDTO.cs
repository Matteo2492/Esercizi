using GestioneRistorante.Models;

namespace GestioneRistorante.DTO
{
    public class OrdiniDTO
    {
        public string Cod { get; set; } = null!;

        public DateTime DatOrd { get; set; }

        public DateTime DatOraConPre { get; set; }

        public virtual ICollection<PiattoDTO> PiaRif { get; set; } = new List<PiattoDTO>();
    }
}
