using Lez04_03_Task.Classes;

namespace Lez04_03_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Creare un sistema di gestione veicoli:
            *
            *All'inserimento di un nuovo veicolo mi sia permessa la scelta tra:
            * 1.Automobile
            * 2.Moto
            *
            *Alla fine dell'inserimento delle caratteristiche del veicolo, stampare i suoi dettagli.
            *
            *Libera scelta degli attributi
            */
            
            bool continua = true;
            void checkContinua(string? input)
            {
                Console.WriteLine("Premi c per crearne un'altro veicolo, altro per uscire");
                input = Console.ReadLine().ToLower().Trim();
                if (input != "c")
                {
                    continua = false;
                }
            }
            do
            { 
                try
                {
                    Console.WriteLine("Scegli il tipo di veicolo tra automobile o moto");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (input == "automobile")
                    {
                        Console.WriteLine("Scegli la marca");
                        string? marca = Console.ReadLine();
                        Console.WriteLine("Scegli il numero di porte");
                        string? numporte = Console.ReadLine();
                        int myInt = int.Parse(numporte);
                        Automobile macchina = new Automobile(marca, myInt);
                        Console.WriteLine($"Marca: {macchina.Marca}\nNumero porte: {macchina.NumPorte}");
                        checkContinua(input);
                    }
                    else if (input == "moto")
                    {
                        Console.WriteLine("Scegli la marca");
                        string? marca = Console.ReadLine();
                        Console.WriteLine("Scegli la cilindrata");
                        string? cilindrata = Console.ReadLine();
                        int myInt = int.Parse(cilindrata);
                        Moto moto = new Moto(marca, myInt);
                        Console.WriteLine($"Marca: {moto.Marca}\nNumero porte: {moto.Cilindrata}");
                        checkContinua(input);
                    }
                    else
                    {
                        Console.WriteLine("Scegli un modello valido");
                        checkContinua(input);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (continua == true);
            Console.WriteLine("Programma terminato...");

        }
    }
}
