using System;
using System.Collections.Generic;

namespace PURIFICAMI_SIGNORE.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nominativo { get; set; } = null!;

    public string Indirizzo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();
}
