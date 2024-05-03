using System;
using System.Collections.Generic;

namespace GestioneImpiegati.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public string Matricola { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateTime DataNasc { get; set; }

    public string Ruolo { get; set; } = null!;

    public string Indirizzo { get; set; } = null!;

    public int RepartoRif { get; set; }

    public string CittaRif { get; set; } = null!;

    public string ProvinciaRif { get; set; } = null!;

    public virtual Reparto RepartoRifNavigation { get; set; } = null!;
}
