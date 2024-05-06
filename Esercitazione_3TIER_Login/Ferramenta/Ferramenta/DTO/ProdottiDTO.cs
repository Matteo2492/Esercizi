namespace Ferramenta.DTO
{
    public class ProdottiDTO
    {
        public Guid? Cod { get; set; }

        public string Nom { get; set; } = null!;

        public int? Qua { get; set; }

        public decimal Pre { get; set; }

        public string? Des { get; set; }

        public string? Cat { get; set; }
    }
}
