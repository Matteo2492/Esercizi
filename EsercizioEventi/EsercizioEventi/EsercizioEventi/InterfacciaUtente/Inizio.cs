using EsercizioEventi.DAL;
using EsercizioEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioEventi.InterfacciaUtente
{
    internal static class Inizio
    {
        public static void GestioneInput()
        {
            Console.WriteLine("Benvenuto nel programma gestione eventi");
            bool continua = true;
            do
            {
                Console.WriteLine("Scegli un'opzione\nDigita 1 : Gestisci un partecipante\nDigita 2 : Gestisci una risorsa\nDigita 3 : Gestisci un evento\nAltro per uscire");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        bool continuaTwo = true;
                        do
                        {
                            Console.WriteLine("Decidi che operazione effettuare\nDigita 1 : Crea partecipante\nDigita 2 : Visualizza tutti i partecipanti\nDigita 3 : Update di un'partecipante\nDigita 4 : Elimina partecipante\nAltro per uscire");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("Digita il nome del partecipante");
                                    input = Console.ReadLine();
                                    Console.WriteLine("Digita il contatto del partecipante");
                                    string? input2 = Console.ReadLine();
                                    if (input is not null && input2 is not null)
                                    {
                                        Partecipanti p = new Partecipanti()
                                        {
                                            Nome = input,
                                            Contatto = input2
                                        };
                                        Crud.Create(p);
                                        Console.WriteLine($"Partecipante: {p.Nome}, {p.Contatto}");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Ecco la lista dei partecipanti");
                                    List <Partecipanti> lista = Crud.ReadPartecipanti();
                                    foreach(Partecipanti e in lista)
                                    {
                                        Console.WriteLine($"ID: {e.PartecipanteId}, Nominativo: {e.Nome}, Contatto: {e.Contatto}");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Ecco la lista dei partecipanti");
                                    List<Partecipanti> lista2 = Crud.ReadPartecipanti();
                                    foreach (Partecipanti e in lista2)
                                    {
                                        Console.WriteLine($"ID: {e.PartecipanteId}, Nominativo: {e.Nome}, Contatto: {e.Contatto}");
                                    }
                                    Console.WriteLine("Scegli l'ID di riferimento");
                                    int inputID = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Scegli quale parametro cambiare tra\n1 : Nominativo\n2 : Contatto");
                                    input = Console.ReadLine();
                                    if(input == "1" && input is not null)
                                    {
                                        Console.WriteLine("Digita un nuovo nome");
                                        input = Console.ReadLine();
                                        if(input is not null)
                                        {
                                            Partecipanti p = new Partecipanti()
                                            {
                                                PartecipanteId = inputID,
                                                Nome = input,
                                                Contatto = ""
                                            };
                                            Crud.Update(p);
                                        }
                                    }
                                    else if (input == "2" && input is not null)
                                    {
                                        Console.WriteLine("Digita un nuovo contatto");
                                        input = Console.ReadLine();
                                        if (input is not null)
                                        {
                                            Partecipanti p = new Partecipanti()
                                            {
                                                PartecipanteId = inputID,
                                                Nome = "",
                                                Contatto = input
                                            };
                                            Crud.Update(p);
                                        }
                                    }
                                    break;
                                case "4":
                                    Console.WriteLine("Ecco la lista dei partecipanti");
                                    List<Partecipanti> lista3 = Crud.ReadPartecipanti();
                                    foreach (Partecipanti e in lista3)
                                    {
                                        Console.WriteLine($"ID: {e.PartecipanteId}, Nominativo: {e.Nome}, Contatto: {e.Contatto}");
                                    }
                                    Console.WriteLine("Scegli l'ID di riferimento da eliminare");
                                    int IDDelete = Convert.ToInt32(Console.ReadLine());
                                    if (input is not null)
                                    {
                                        Partecipanti p = new Partecipanti()
                                        {
                                            PartecipanteId = IDDelete,
                                            Nome = "",
                                            Contatto = ""
                                        };
                                        Crud.Delete(p);
                                    }
                                    break;
                                default:
                                    continuaTwo = false;
                                    break;
                            }
                        } while (continuaTwo);
                        break;
                    case "2":
                        Console.WriteLine("Decidi che operazione effettuare\nDigita 1 : Crea risorsa\nDigita 2 : Visualizza tutte le risorse\nDigita 3 : Update di una risorsa\nDigita 4 : Elimina risorsa\nAltro per uscire");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.WriteLine("");
                                break;
                            case "2":
                                Console.WriteLine("");
                                break;
                            case "3":
                                Console.WriteLine("");
                                break;
                            case "4":
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Decidi che operazione effettuare\nDigita 1 : Crea un evento\nDigita 2 : Visualizza tutti gli eventi\nDigita 3 : Update di un'evento\nDigita 4 : Elimina evento\nAltro per uscire");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.WriteLine("");
                                break;
                            case "2":
                                Console.WriteLine("");
                                break;
                            case "3":
                                Console.WriteLine("");
                                break;
                            case "4":
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Chiusura programma");
                        continua = false;
                        break;
                }
            } while(continua); 
        }
    }
}
