using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le05_06.Classes
{
    internal class Rivista : Pubblicazioni
    {
        public string? Categoria {  get; set; }
    
        public Rivista()
        {
            
        }
        public Rivista(string? categoria, string? titolo, DateTime datapubblicazione, DateTime? datavendita, int stock, float prezzo)
        {
            Categoria = categoria;
            Titolo = titolo;
            DataPubblicazione = datapubblicazione;
            DataVendita = datavendita;
            Stock = stock;
            Prezzo = prezzo;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"--[RIVISTA] Titolo: {Titolo}\nData pubblicazione: {DataPubblicazione}\nCategoria: {Categoria}\nStock: {Stock}\nPrezzo: {Prezzo}");
        }
    }
}
