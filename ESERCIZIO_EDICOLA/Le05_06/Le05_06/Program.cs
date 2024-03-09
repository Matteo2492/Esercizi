using Le05_06.Classes;

namespace Le05_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            Edicola edicola = new Edicola();
            Console.WriteLine($"Benvenuto nel programma gestisci Edicola\n{edicola.NomeEdicola}\nIndirizzo: {edicola.ViaEedicola}");
            
            do
            {
                
                Console.WriteLine("\nPremi 1 per gestire le pubblicazioni, 2 per vendere una pubblicazione, 3 per cercare una pubblicazione, 4 per gestire i clienti\naltro per uscire");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        edicola.GestisciPubb();
                        break;
                    case "2":
                        edicola.VendiPubb(); 
                        break;
                    case "3":
                        edicola.CercaPubb();
                        break;
                    case "4":
                        edicola.GestisciCliente();
                        break;
                    case "DRAGONBALL":
                        Task.Run(async () => await edicola.Spam());
                        break;
                    default:
                        continua = false;
                        break;
                }
               

            } while (continua);
            Console.WriteLine("Fine programma...");
        }
    }
}
