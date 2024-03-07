using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_09_Esercizio.Classes
{
    internal class Stanza
    {
        public string? NomeStanza { get; set; }

        private List<Oggetto> lista { get; set; } = new List<Oggetto>();

        public void aggiungiOggetto(Oggetto item)
        {
            lista.Add(item);
        }

        public void listaOggetti(string input)
        {
            foreach(Oggetto item in lista)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Digita 'si' per creare un'altro oggetto, 'stanza' per creare un'altra stanza, 'recap' per il recap di oggetti creati fino ad ora, altro per uscire");
            input = Console.ReadLine().ToLower().Trim();
        }
        public void listaOggetti()
        {
            foreach (Oggetto item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
