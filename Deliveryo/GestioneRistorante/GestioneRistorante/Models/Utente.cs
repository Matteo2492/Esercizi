using System;
using System.Collections.Generic;

namespace GestioneRistorante.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordUtente { get; set; } = null!;

    public virtual ICollection<Ordini> Ordinis { get; set; } = new List<Ordini>();
}
