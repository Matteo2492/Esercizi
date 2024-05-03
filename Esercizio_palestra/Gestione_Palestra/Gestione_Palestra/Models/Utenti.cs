using System;
using System.Collections.Generic;

namespace Gestione_Palestra.Models;

public partial class Utenti
{
    public int UtenteId { get; set; }

    public string Codice { get; set; } = null!;

    public string Nominativo { get; set; } = null!;

    public string PasswordUtente { get; set; } = null!;

    public virtual ICollection<PrenotazioniUtenti> PrenotazioniUtentis { get; set; } = new List<PrenotazioniUtenti>();
    public Utenti()
    {
        
    }
}
