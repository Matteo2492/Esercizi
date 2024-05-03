using System;
using System.Collections.Generic;

namespace GestioneRistorante.Models;

public partial class Piatto
{
    public int PiattoId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public decimal? Prezzo { get; set; }

    public int MenuRif { get; set; }

    public int? Quantita { get; set; }

    public virtual Menu MenuRifNavigation { get; set; } = null!;

    public virtual ICollection<Ordini> OrdineRifs { get; set; } = new List<Ordini>();
}
