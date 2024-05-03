using System;
using System.Collections.Generic;

namespace PURIFICAMI_SIGNORE.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public int Codice { get; set; }

    public decimal Prezzo { get; set; }

    public decimal? PrezzoOfferta { get; set; }

    public DateOnly? DataInizioOfferta { get; set; }

    public DateOnly? DataFineOfferta { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int Quantita { get; set; }

    public string? ImmagineLink { get; set; }

    public int ProdottoRif { get; set; }

    public virtual ICollection<OrdineVariazione> OrdineVariaziones { get; set; } = new List<OrdineVariazione>();

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
