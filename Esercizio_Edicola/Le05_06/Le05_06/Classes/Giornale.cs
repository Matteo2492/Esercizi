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
        public Giornale(string? titolo, string? redazione,  DateTime datapubblicazione, int stock, double prezzo,int numerovendite)
        {
            Redazione = redazione;
            Titolo = titolo;
            DataPubblicazione = datapubblicazione;
            Stock = stock;
            Prezzo = prezzo;
            NumeroVendite = numerovendite;
        }
       
        public override void stampaDettaglio()
        {
            Console.WriteLine($"--[GIORNALE]Titolo: {Titolo}\nRedazione: {Redazione}\nData pubblicaizone: {DataPubblicazione}\nStock: {Stock}\nPrezzo: {Prezzo}");
        }
        public override string ToCSV()
        {
            return $"{Titolo};{Redazione};{DataPubblicazione};{Stock};{Prezzo};{NumeroVendite}";
        }
        public override string venditaCSV()
        {
            return $"{Titolo};{Redazione};{DataPubblicazione};{Stock};{Prezzo};{NumeroVendite}";
        }
    }
}
