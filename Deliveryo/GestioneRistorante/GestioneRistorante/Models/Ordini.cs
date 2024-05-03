using System;
using System.Collections.Generic;

namespace GestioneRistorante.Models;

public partial class Ordini
{
    public int OrdineId { get; set; }

    public string Codice { get; set; } = null!;

    public DateTime DataOrdine { get; set; }

    public DateTime DataOraConsegnaPrevista { get; set; }

    public int UtenteRif { get; set; }

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public virtual ICollection<Piatto> PiattoRifs { get; set; } = new List<Piatto>();
}
