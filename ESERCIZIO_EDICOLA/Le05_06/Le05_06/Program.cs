using Le05_06.Classes;
using System.IO;

namespace Le05_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edicola = new Edicola();

            string pathClienti = "C:\\Users\\BS00000000\\Desktop\\Clienti\\clienti.txt";
            string pathRiv = "C:\\Users\\BS00000000\\Desktop\\Pubblicazioni\\riviste.txt";
            string pathGio = "C:\\Users\\BS00000000\\Desktop\\Pubblicazioni\\giornali.txt";
            
            try
            {
                    using (StreamReader sr = new StreamReader(pathClienti))
                    {
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] array = line.Split(';');
                            Cliente cliente = new Cliente(array[0], array[1], array[2]);
                            edicola.listaClienti.Add(cliente);
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(pathRiv, true))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] array = line.Split(';');
                        Rivista rivista;
                        rivista = new Rivista(array[0], array[1], Convert.ToDateTime(array[2]), Convert.ToInt32(array[3]), Convert.ToDouble(array[4]), Convert.ToInt32(array[5]));
                        edicola.listaPubblicazioni.Add(rivista);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                using (StreamReader sr = new StreamReader(pathGio, true))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] array = line.Split(';');
                        Giornale giornale;
                        giornale = new Giornale(array[0], array[1], Convert.ToDateTime(array[2]), Convert.ToInt32(array[3]), Convert.ToDouble(array[4]), Convert.ToInt32(array[5]));
                        edicola.listaPubblicazioni.Add(giornale);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bool continua = true;
            
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
