using GestioneRistorante.Models;
using System.Text.Json.Serialization;

namespace GestioneRistorante.DTO
{
    public class RistoranteDTO
    {
        public string Cod { get; set; } = null!;

        public string Nom { get; set; } = null!;

        public string TipCuc { get; set; } = null!;

        public string Des { get; set; } = null!;

        public TimeOnly OraApe { get; set; }

        public TimeOnly OraChi { get; set; }
       
        public virtual ICollection<MenuDTO> Men { get; set; } = new List<MenuDTO>();
    }
}
