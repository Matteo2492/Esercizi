using GestioneRistorante.Models;

namespace GestioneRistorante.DTO
{
    public class MenuDTO
    {

        public string Cod { get; set; } = null!;

        public virtual ICollection<PiattoDTO> Pia { get; set; } = new List<PiattoDTO>();

    }
}
