using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_09_Esercizio.Classes
{
    internal class Oggetto
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public int Valore { get; set; }

        public Stanza? Stanza { get; set; }
        public override string ToString()
        {
            return $"\nNome: {Nome}\nDescrizione: {Descrizione}\nPrezzo: {Valore} Euri\nStanza: {Stanza.NomeStanza}\n";
        }
        public Oggetto()
        {
            
        }
        public Oggetto(string? nome, string? descrizione, int valore)
        {
            Nome = nome;
            Descrizione = descrizione;
            Valore = valore;
        }
        public void creaOggetto(Oggetto oggetto, Stanza stanza)
        {
            Console.WriteLine($"Crea un oggetto da inserire nella stanza ---> {stanza.NomeStanza}");
            Console.WriteLine("Inserisci il nome dell'oggetto");
            oggetto.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci una descrizione");
            oggetto.Descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo");
            oggetto.Valore = int.Parse(Console.ReadLine());
            oggetto.Stanza = stanza;
            stanza.aggiungiOggetto(oggetto);
            Console.WriteLine("\nRECAP:");
            Console.WriteLine(oggetto);
        }
    }
}
