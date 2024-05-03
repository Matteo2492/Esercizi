using System;
using System.Collections.Generic;

namespace GestioneRistorante.Models;

public partial class Ristorante
{
    public int RistoranteId { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string TipoCucina { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public TimeOnly OrarioApertura { get; set; }

    public TimeOnly OrarioChiusura { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
