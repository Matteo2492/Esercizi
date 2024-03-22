using System;
using System.Collections.Generic;

namespace EsercizioEventi.Models;

public partial class Eventi
{
    public int EventiId { get; set; }

    public int? PartecipanteRif { get; set; }

    public int RisorseRif { get; set; }

    public string NomeEvento { get; set; } = null!;

    public string? Descrizione { get; set; }

    public DateTime DataEvento { get; set; }

    public string Luogo { get; set; } = null!;

    public int Capacita { get; set; }

    public virtual Partecipanti? PartecipanteRifNavigation { get; set; }

    public virtual Risorse RisorseRifNavigation { get; set; } = null!;
}
