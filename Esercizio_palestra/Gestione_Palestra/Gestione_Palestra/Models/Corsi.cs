using System;
using System.Collections.Generic;

namespace Gestione_Palestra.Models;

public partial class Corsi
{
    public int CorsoId { get; set; }

    public string? Codice { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime DataInizioCorso { get; set; }

    public TimeOnly Durata { get; set; }

    public int Posti { get; set; }

    public virtual ICollection<Prenotazioni> Prenotazionis { get; set; } = new List<Prenotazioni>();

    public Corsi()
    {
        
    }
}
