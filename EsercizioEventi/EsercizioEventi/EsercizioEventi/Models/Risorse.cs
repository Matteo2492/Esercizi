using System;
using System.Collections.Generic;

namespace EsercizioEventi.Models;

public partial class Risorse
{
    public int RisorsaId { get; set; }

    public string NomeRisorsa { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int Quantita { get; set; }

    public double Costo { get; set; }

    public string Fornitore { get; set; } = null!;

    public virtual ICollection<Eventi> Eventis { get; set; } = new List<Eventi>();
}
