using System;
using System.Collections.Generic;

namespace Ferramenta.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Username { get; set; } = null!;

    public string Nominativo { get; set; } = null!;

    public string PasswordUtente { get; set; } = null!;
}
