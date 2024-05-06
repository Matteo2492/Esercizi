using System;
using System.Collections.Generic;

namespace Ferramenta.Models;

public partial class Prodotti
{
    public int ProdottoId { get; set; }

    public Guid? CodiceProdotto { get; set; }

    public string Nome { get; set; } = null!;

    public int? Quantita { get; set; }

    public decimal Prezzo { get; set; }

    public string? Descrizione { get; set; }

    public string? Categoria { get; set; }
}
