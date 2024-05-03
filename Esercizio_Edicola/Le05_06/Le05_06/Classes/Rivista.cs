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
        public Rivista(string? titolo, string? categoria,  DateTime datapubblicazione, int stock, double prezzo, int numerovendite)
        {
            Categoria = categoria;
            Titolo = titolo;
            DataPubblicazione = datapubblicazione;
            Stock = stock;
            Prezzo = prezzo;
            NumeroVendite = numerovendite;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"--[RIVISTA] Titolo: {Titolo}\nData pubblicazione: {DataPubblicazione}\nCategoria: {Categoria}\nStock: {Stock}\nPrezzo: {Prezzo}");
        }
        public override string ToCSV()
        {
                return $"{Titolo};{Categoria};{DataPubblicazione};{Stock};{Prezzo};{NumeroVendite}";
        }
        public override string venditaCSV()
        {
            return $"{Titolo};{Categoria};{DataPubblicazione};{Stock};{Prezzo};{NumeroVendite}";
        }
    }
}
