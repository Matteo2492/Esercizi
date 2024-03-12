using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Le05_06.Classes
{
    internal class Edicola
    {
        public string NomeEdicola = "La mia bella edicola";
        public string ViaEedicola = "Via delle pietre condite 1";

        public List<Cliente> listaClienti { get; set; } = new List<Cliente>();
        public List<Pubblicazioni> listaPubblicazioni { get; set; } = new List<Pubblicazioni>();
        public void GestisciPubb()
        {
            bool continua = true;
            do
            {
                Console.WriteLine("\n1 per aggiungere una nuova pubblicazione\n2 per eliminare una pubblicazione\n3 per modificare uno stock\n4 per il recap\nAltro per uscire");
                string? input = Console.ReadLine();
                try
                {
                    switch (input)
                    {
                        case "1":
                            AggiungiPubb();
                            break;
                        case "2":
                            RimuoviPubb();
                            break;
                        case "3":
                            AggiornaStock();
                            break;
                        case "4":
                            RecapPubb();
                            break;
                        default:
                            continua = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (continua);

        }
        public void AggiungiPubb()
        {
            Console.WriteLine("\nAggiungiamo una nuova pubblicazione!");
            bool continua = true;
            do
            {
                Console.WriteLine("\nScegli:\n1 per aggiungere un' giornale\n2 per aggiungere una rivista\nAltro per tornare indietro");
                string? scelta = Console.ReadLine();
                if (scelta == "1")
                {
                    DateTime DataPubblicazione = DateTime.Now;
                    Console.WriteLine("\nScegli un titolo per il giornale");
                    string? Titolo = Console.ReadLine();
                    Console.WriteLine("\nScegli la redazione");
                    string? Redazione = Console.ReadLine();
                    Console.WriteLine("\nScrivi il numero di stock");
                    int Stock = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nScegli il prezzo");
                    double Prezzo = int.Parse(Console.ReadLine());
                    Giornale giornale = new Giornale(Redazione,Titolo,DataPubblicazione, Stock, Prezzo,0);
                    listaPubblicazioni.Add(giornale);
                    Console.WriteLine("\nGiornale inserito con successo");
                    giornale.stampaDettaglio();
                    inserisciGiornale(giornale);
                }
                else if (scelta == "2")
                {
                    DateTime DataPubblicazione = DateTime.Now;
                    Console.WriteLine("\nScegli un titolo per la rivista");
                    string? Titolo = Console.ReadLine();
                    Console.WriteLine("\nScegli la categoria");
                    string? Categoria = Console.ReadLine();
                    Console.WriteLine("\nScrivi il numero di stock");
                    int Stock = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nScegli il prezzo");
                    double Prezzo = int.Parse(Console.ReadLine());
                    Rivista rivista = new Rivista(Categoria, Titolo, DataPubblicazione, Stock, Prezzo,0);
                    listaPubblicazioni.Add(rivista);
                    Console.WriteLine("\nRivista inserita con successo");
                    rivista.stampaDettaglio();
                    inserisciRivista(rivista);
                }
                else
                {
                    continua = false;
                }
            } while (continua);

        }
        public void RimuoviPubb()
        {
            bool continua = true;
            do
            {
                Console.WriteLine("\nScegli una pubblicazione da eliminare");
                RecapPubb();
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine($"\n{listaPubblicazioni[input].Titolo} Eliminato");
                listaPubblicazioni.RemoveAt(input);
                Console.WriteLine("\n1 per rimuovere una pubblicazione, altro per tornare indietro");
                string? scelta = Console.ReadLine();
                if(scelta != "1")
                {
                    continua = false;
                }
            } while (continua);
        }
        public void AggiornaStock()
        {
            bool continua = true;
            do
            {
                Console.WriteLine("\nScegli una pubblicazione da modificare, scrivi il numero associato");
                RecapPubb();
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine($"{listaPubblicazioni[input].Titolo}<--- Scrivi il numero di stock da modificare");
                listaPubblicazioni[input].Stock = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nStock aggiornato per {listaPubblicazioni[input].Titolo}, nuova quantità {listaPubblicazioni[input].Stock} pezzi");
                Console.WriteLine("\n1 per modificare lo stock, altro per tornare indietro");
                string? scelta = Console.ReadLine();
                if(scelta != "1")
                {
                    continua = false;
                }
            } while (continua);
        }
      
        public void VendiPubb()
        {
            bool continua = true;
            do
            {
                
                Console.WriteLine("\nScegli 1 per vendere una pubblicazione, 2 per il recap delle vendite, altro per uscire");
                
                string? scelta = Console.ReadLine();
                if (scelta == "1")
                {
                    Console.WriteLine("Scegli una pubblicazione da vendere tramite il numero associato");
                    RecapPubb();
                    int input = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nPubblicazione scelta:");
                    Console.WriteLine(listaPubblicazioni[input].Titolo);
                    Console.WriteLine(listaPubblicazioni[input].Stock);
                    Console.WriteLine("\nScegli la quantità da vendere");
                    int numero = int.Parse(Console.ReadLine());
                    if (numero > listaPubblicazioni[input].Stock)
                    {
                        Console.WriteLine("Stock insufficiente...");
                        continua = false;
                    }
                    else
                    {
                        listaPubblicazioni[input].Stock -= numero;
                        listaPubblicazioni[input].NumeroVendite += numero;
                        Console.WriteLine($"\nVendute {numero} copie di {listaPubblicazioni[input].Titolo}");
                        inserisciVendite(listaPubblicazioni[input]);
                    }   
                }
                else if (scelta == "2")
                {
                    RecapVendite();
                }
                else
                {
                    continua = false;
                }
            } while (continua);
        }
        public void CercaPubb()
        {
            bool continua = true;
            do
            {
                Console.WriteLine("Per cercare una pubblicazione inserisci un titolo o categoria, digita f per filtrare in base alla disponibilità di stock, oppure digita una parola chiave");
                string? scelta = Console.ReadLine();
                if(scelta is not null && scelta != "f")
                {
                    foreach (Pubblicazioni item in listaPubblicazioni)
                    {
                        if (scelta is not null && item.Titolo == scelta)
                        {
                            item.stampaDettaglio();
                        }
                        else if (item.GetType() == typeof(Rivista))
                        {
                            Rivista temp = (Rivista)item;
                            if (temp.Categoria == scelta)
                            {
                                temp.stampaDettaglio();
                            }
                        }
                        else
                        {
                            foreach (Pubblicazioni item2 in listaPubblicazioni)
                            {
                                if (scelta is not null && item2.Titolo is not null && item2.Titolo.ToLower().Contains(scelta))
                                {
                                    item2.stampaDettaglio();
                                    
                                }
                                else if (scelta is not null && item2 is Rivista rivista && rivista.Categoria is not null && rivista.Categoria.ToLower().Contains(scelta))
                                {
                                    item2.stampaDettaglio();
                                    
                                }
                                else if (scelta is not null && item2 is Giornale giornale && giornale.Redazione is not null && giornale.Redazione.ToString().Contains(scelta))
                                {
                                    item2.stampaDettaglio();
                                }
                                else
                                {
                                    Console.WriteLine("\nNessuna pubblicazione trovata con la parola chiave inserita.");
                                }
                            }
                        }
                    }
                }
                else if (scelta is not null && scelta.ToLower() == "f")
                {
                    listaPubblicazioni.Sort((pub1, pub2) => pub1.Stock.CompareTo(pub2.Stock));
                    foreach (Pubblicazioni item in listaPubblicazioni)
                    {
                        item.stampaDettaglio();
                    }
                }
                else
                {
                    continua = false;
                }
            }
            while (continua);
        }
        public void GestisciCliente()
        {
            Console.WriteLine("\nBenvenuto nell'area gestisci clienti!");
            bool continua = true;
            do
            {
                Console.WriteLine("\nScegli:\n1 per aggiungere un cliente\n2 per programmare una consegna\n3 per il recap dei clienti\nAltro per tornare indietro");
                string? scelta = Console.ReadLine();
                if (scelta == "1")
                {
                    Console.WriteLine("\nInserisci il nominativo del cliente");
                    string? Nominativo = Console.ReadLine();
                    Console.WriteLine("\nInserisci l'indirizzo per la consegna");
                    string? Indirizzo = Console.ReadLine();
                    Console.WriteLine("\nInserisci il codice abbonamento");
                    string? Abbonamento = Console.ReadLine();
                    Cliente cliente = new Cliente(Nominativo, Indirizzo, Abbonamento);

                    listaClienti.Add(cliente);
                    Console.WriteLine("\nCliente inserito con successo");
                    inserisciClienti(cliente);
                    Console.WriteLine(cliente);
                }
                else if (scelta == "2")
                {
                    Console.WriteLine("\nScegli un cliente per la consegna");
                    RecapClienti();
                    Console.WriteLine("\nSeleziona il numero associato");
                    int input = int.Parse(Console.ReadLine());
                    Console.WriteLine(listaClienti[input].Nominativo);
                    Console.WriteLine("Scegli la pubblicazione");
                    RecapPubb();
                    Console.WriteLine("\nSeleziona il numero associato");
                    int input2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(listaPubblicazioni[input2].Titolo);
                    Console.WriteLine("\nScegli la quantità da vendere");
                    int numero = int.Parse(Console.ReadLine());
                    if(numero > listaPubblicazioni[input].Stock)
                    {
                        Console.WriteLine("Stock insufficiente...");
                        continua = false;
                    }
                    else
                    {
                        listaPubblicazioni[input].Stock -= numero;
                        listaPubblicazioni[input].NumeroVendite += numero;
                        Console.WriteLine($"\nVendute {numero} copie di {listaPubblicazioni[input].Titolo}, al cliente {listaClienti[input].Nominativo}\nIndirizzo di consegna{listaClienti[input].Indirizzo}");
                        inserisciVendite(listaPubblicazioni[input]);
                    }
                 
                }
                else if (scelta == "3") {
                    RecapClienti();
                }
                else
                {
                    continua = false;
                }
            } while (continua);

        }
        public void RecapPubb()
        {
            if (listaPubblicazioni.Count <= 0)
            {
                Console.WriteLine("\nNessuna pubblicazione inserita");
            }
            else
            {
                int number = 0;
                foreach (Pubblicazioni item in listaPubblicazioni)
                {
                    Console.WriteLine($"\n{number}<---selezionatore");
                    item.stampaDettaglio();
                    number++;
                }
            }
        }
        public void RecapVendite()
        {
            int number = 0;
            foreach (Pubblicazioni item in listaPubblicazioni)
            {
                if (item.NumeroVendite > 0)
                {
                        Console.WriteLine($"Pubblicazione: {item.Titolo}\nNumero vendite: {item.NumeroVendite}");
                    number++;
                }
            }
            if(number == 0)
            {
                Console.WriteLine("Nessuna vendita effettuata");
            }
        }
        public void inserisciRivista(Rivista item)
        {
            string path = "C:\\Users\\BS00000000\\Desktop\\Pubblicazioni\\riviste.txt";
            try
            {
                if (path is not null)
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(item.ToCSV());
                    }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void inserisciGiornale(Giornale item)
        {
            string path = "C:\\Users\\BS00000000\\Desktop\\Pubblicazioni\\giornali.txt";
            try
            {
                if (path is not null)
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(item.ToCSV());
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void inserisciVendite(Pubblicazioni item)
        {
            DateTime dataoggi = DateTime.Now;
            string formattedDate = dataoggi.ToString("yyyy_MM_dd");
            string path = $"C:\\Users\\BS00000000\\Desktop\\Vendite\\scontrini_{formattedDate}.csv";
            try
            {
                if (path is not null)
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(item.venditaCSV());
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void inserisciClienti(Cliente item)
        {
            string path = "C:\\Users\\BS00000000\\Desktop\\Clienti\\clienti.txt";
            try
            {
                if (path is not null)
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                            sw.WriteLine(item.ToCSV());
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                }
        }
        public void RecapClienti()
        {
            if (listaClienti.Count <= 0)
            {
                Console.WriteLine("\nNessun cliente inserito");
            }
            else
            {
                int number = 0;
                foreach (Cliente item in listaClienti)
                {
                    Console.WriteLine($"\n{number}<---selezionatore");
                    Console.WriteLine(item);
                    number++;
                }
            }    
        }
        public async Task Spam()
        {
            Console.WriteLine("\nE' FINITA PER TE FREEZER!!!!");
            await Task.Delay(1000);
            Console.Write("\nKAME...");
            await Task.Delay(2000);
            Console.Write("HAME...");
            await Task.Delay(6000);
            while (true) // Infinite loop to spam "A"
            {
                Console.Write("A");
            }
        }
    }
}
