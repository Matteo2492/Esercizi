using System;
using System.Collections.Generic;

namespace PURIFICAMI_SIGNORE.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public DateOnly? DataOrdine { get; set; }

    public string Stato { get; set; } = null!;

    public decimal PrezzoTotale { get; set; }

    public int UtenteRif { get; set; }

    public virtual ICollection<OrdineVariazione> OrdineVariaziones { get; set; } = new List<OrdineVariazione>();

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
