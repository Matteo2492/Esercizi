using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le05_06.Classes
{
    internal class Giornale : Pubblicazioni
    {
        public string? Redazione { get; set; }
        public Giornale()
        {

        }
        public Giornale(string? redazione, string? titolo, DateTime datapubblicazione, DateTime? datavendita, int stock, float prezzo)
        {
            Redazione = redazione;
            Titolo = titolo;
            DataPubblicazione = datapubblicazione;
            DataVendita = datavendita;
            Stock = stock;
            Prezzo = prezzo;
        }
       
        public override void stampaDettaglio()
        {
            Console.WriteLine($"--[GIORNALE] Redazione: {Redazione}\nData pubblicaizone: {DataPubblicazione}\nStock: {Stock}\nPrezzo: {Prezzo}");
        }
    }
}
