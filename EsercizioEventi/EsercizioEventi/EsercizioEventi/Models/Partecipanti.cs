using System;
using System.Collections.Generic;

namespace EsercizioEventi.Models;

public partial class Partecipanti
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Contatto { get; set; } = null!;

    public virtual ICollection<Eventi> Eventis { get; set; } = new List<Eventi>();

    public override string ToString()
    {
        return $"{PartecipanteId};{Nome};{Contatto}";
    }
}
