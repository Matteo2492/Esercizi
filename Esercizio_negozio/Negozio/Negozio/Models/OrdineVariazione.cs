using System;
using System.Collections.Generic;

namespace PURIFICAMI_SIGNORE.Models;

public partial class OrdineVariazione
{
    public int OrdineVariazioneId { get; set; }

    public int QuantitaVariazione { get; set; }

    public int VariazioneRif { get; set; }

    public int OrdineRif { get; set; }

    public virtual Ordine OrdineRifNavigation { get; set; } = null!;

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
