using System;
using System.Collections.Generic;

namespace Gestione_Palestra.Models;

public partial class PrenotazioniUtenti
{
    public int PrenotazioneUtenteId { get; set; }

    public int PrenotazioneId { get; set; }

    public int UtenteId { get; set; }

    public virtual Prenotazioni Prenotazione { get; set; } = null!;

    public virtual Utenti Utente { get; set; } = null!;

    public PrenotazioniUtenti()
    {
       
    }
}
