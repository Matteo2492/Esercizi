using System;
using System.Collections.Generic;

namespace GestioneImpiegati.Models;

public partial class Provincium
{
    public int ProvinciaId { get; set; }

    public string Sigla { get; set; } = null!;

    public virtual ICollection<Cittum> Citta { get; set; } = new List<Cittum>();
}
