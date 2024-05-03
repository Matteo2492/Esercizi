using System;
using System.Collections.Generic;

namespace Gestione_Palestra.Models;

public partial class Prenotazioni
{
    public int PrenotazioneId { get; set; }

    public string? Codice { get; set; }

    public DateTime? DataPrenotazione { get; set; }

    public int CorsoRif { get; set; }

    public virtual Corsi CorsoRifNavigation { get; set; } = null!;

    public virtual ICollection<PrenotazioniUtenti> PrenotazioniUtentis { get; set; } = new List<PrenotazioniUtenti>();

    public Prenotazioni()
    {
        
    }
}
