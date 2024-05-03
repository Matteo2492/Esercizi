using System;
using System.Collections.Generic;

namespace GestioneRistorante.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Codice { get; set; } = null!;

    public int RistoranteRif { get; set; }

    public virtual ICollection<Piatto> Piattos { get; set; } = new List<Piatto>();

    public virtual Ristorante RistoranteRifNavigation { get; set; } = null!;
}
