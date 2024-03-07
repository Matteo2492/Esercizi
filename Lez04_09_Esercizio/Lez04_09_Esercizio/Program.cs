using Lez04_09_Esercizio.Classes;

namespace Lez04_09_Esercizio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
               * Creare un sistema che mantenga traccia degli oggetti contenuti nelle stanze 
               * della vostra casa.
               * Di ogni oggetto voglio conoscere:
               * - Nome
               * - Descrizione
               * - Valore dell'oggetto
               * 
               * Di ogni stanza voglio conoscere il nome
            */


            bool continua = true;
            Console.WriteLine("Benvenuto nel programma Crea Stanze ed Oggetti!!");
            List<Stanza> listaStanze = new List<Stanza>();
            do
            {

                Console.WriteLine("\nCrea una stanza inserendo un nome a piacere, oppure digita no per uscire");

                string? input = Console.ReadLine().ToLower().Trim();

                if (input is not null && input != "no")
                {
                    Stanza stanza = new Stanza();
                    stanza.NomeStanza = input;
                    listaStanze.Add(stanza);

                    bool continuaTwo = true;

                    do
                    {
                        Oggetto oggetto = new Oggetto();
                        oggetto.creaOggetto(oggetto,stanza);

                        Console.WriteLine("Digita 'si' per creare un'altro oggetto, 'stanza' per creare un'altra stanza, 'recap' per il recap di oggetti creati fino ad ora, altro per uscire");
                        input = Console.ReadLine().ToLower().Trim();

                        switch (input)
                        {
                            case "si":
                                continuaTwo = true;
                                break;
                            case "stanza":
                                continuaTwo = false;
                                break;
                            case "recap":
                                stanza.listaOggetti(input);
                                break;
                            default:
                                continuaTwo = false;
                                continua = false;
                                break;
                        }
                    } while (continuaTwo == true);
                }
                else
                {
                    continua = false;
                }
                
            } while (continua == true);

            Console.WriteLine("\nRecap delle stanze ed oggetti creati");
            foreach(Stanza item in  listaStanze)
            {
                item.listaOggetti();
            }
        }
    }
}
