using System;
using System.Collections.Generic;

namespace PURIFICAMI_SIGNORE.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public int CategoriaRif { get; set; }

    public virtual Categorium CategoriaRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
