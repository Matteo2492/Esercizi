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
                    #region Gestione partecipante
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
                                    if (input is not null && input2 is not null && input != "" && input2 != "")
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
                    #endregion
                    #region Gestione Risorse
                    case "2":
                        bool continuaThree = true;
                        do
                        {
                            string? inputTipo;
                            int inputQuantita;
                            double inputCosto;
                            string? inputFornitore;
                            Console.WriteLine("Decidi che operazione effettuare\nDigita 1 : Crea risorsa\nDigita 2 : Visualizza tutte le risorse\nDigita 3 : Update di una risorsa\nDigita 4 : Elimina risorsa\nAltro per uscire");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("Digita il nome della risorsa");
                                    input = Console.ReadLine();
                                    Console.WriteLine("Digita il tipo della risorsa");
                                    inputTipo = Console.ReadLine();
                                    Console.WriteLine("Digita la quantità della risorsa");
                                    inputQuantita = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Digita il costo della risorsa");
                                    inputCosto = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Digita il nome del fornitore");
                                    inputFornitore = Console.ReadLine();
                                    if (input is not null && inputTipo is not null && input != "" && inputTipo != "" && inputFornitore is not null && inputFornitore != "")
                                    {
                                        Risorse p = new Risorse()
                                        {
                                            NomeRisorsa = input,
                                            Tipo = inputTipo,
                                            Quantita = inputQuantita,
                                            Costo = inputCosto,
                                            Fornitore = inputFornitore
                                        };
                                        Crud.Create(p);
                                        Console.WriteLine($"Risorsa inserita: {p.NomeRisorsa}, Tipo: {p.Tipo}, Quantita: {p.Quantita}, Costo: {p.Costo}, Fornitore: {p.Fornitore}");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Ecco la delle risorse");
                                    List<Risorse> lista = Crud.ReadRisorse();
                                    foreach (Risorse p in lista)
                                    {
                                        Console.WriteLine($"Risorsa: {p.NomeRisorsa}, Tipo: {p.Tipo}, Quantita: {p.Quantita}, Costo: {p.Costo}, Fornitore: {p.Fornitore}");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Ecco la lista delle risorse");
                                    List<Risorse> lista2 = Crud.ReadRisorse();
                                    foreach (Risorse p in lista2)
                                    {
                                        Console.WriteLine($"Risorsa: {p.NomeRisorsa}, Tipo: {p.Tipo}, Quantita: {p.Quantita}, Costo: {p.Costo}, Fornitore: {p.Fornitore}");
                                    }
                                    Console.WriteLine("Scegli l'ID di riferimento");
                                    int inputID = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Scegli quale parametro cambiare tra\n1 : Nome della risorsa\n2 : Tipo\n3 : Quantita\n4 : Costo\n5 : Fornitore");
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            if (input is not null)
                                            {
                                                Console.WriteLine("Digita un nuovo nome per la risorsa");
                                                input = Console.ReadLine();
                                                if (input is not null)
                                                {
                                                    Risorse p = new Risorse()
                                                    {
                                                        RisorsaId = inputID,
                                                        NomeRisorsa = input,
                                                    };
                                                    Crud.Update(p);
                                                }
                                            }
                                            break;
                                        case "2":
                                            if (input is not null)
                                            {
                                                Console.WriteLine("Digita un nuovo tipo per la risorsa");
                                                inputTipo = Console.ReadLine();
                                                if (inputTipo is not null)
                                                {
                                                    Risorse p = new Risorse()
                                                    {
                                                        RisorsaId = inputID,
                                                        Tipo = inputTipo,
                                                    };
                                                    Crud.Update(p);
                                                }
                                            }
                                            break;
                                        case "3":
                                            if (input is not null)
                                            {
                                                Console.WriteLine("Digita la nuova quantità per la risorsa");
                                                inputQuantita = Convert.ToInt32(Console.ReadLine());
                                                Risorse p = new Risorse()
                                                {
                                                    RisorsaId = inputID,
                                                    Quantita = inputQuantita
                                                };
                                                Crud.Update(p);
                                            }
                                            break;
                                        case "4":
                                            if (input is not null)
                                            {
                                                Console.WriteLine("Digita il nuovo costo per la risorsa");
                                                inputCosto = Convert.ToDouble(Console.ReadLine());
                                                Risorse p = new Risorse()
                                                {
                                                    RisorsaId = inputID,
                                                    Costo = inputCosto
                                                };
                                                Crud.Update(p);
                                            }
                                            break;
                                        case "5":
                                            if (input is not null)
                                            {
                                                Console.WriteLine("Digita un nuovo fornitore per la risorsa");
                                                inputFornitore = Console.ReadLine();
                                                if (inputFornitore is not null)
                                                {
                                                    Risorse p = new Risorse()
                                                    {
                                                        RisorsaId = inputID,
                                                        Fornitore = inputFornitore
                                                    };
                                                    Crud.Update(p);
                                                }
                                            }
                                            break;
                                    }


                                    break;
                                case "4":
                                    Console.WriteLine("Ecco la lista delle risorse");
                                    List<Risorse> lista3 = Crud.ReadRisorse();
                                    foreach (Risorse p in lista3)
                                    {
                                        Console.WriteLine($"Risorsa: {p.NomeRisorsa}, Tipo: {p.Tipo}, Quantita: {p.Quantita}, Costo: {p.Costo}, Fornitore: {p.Fornitore}");
                                    }
                                    Console.WriteLine("Scegli l'ID di riferimento da eliminare");
                                    int IDDelete = Convert.ToInt32(Console.ReadLine());
                                    if (input is not null)
                                    {
                                        Risorse p = new Risorse()
                                        {
                                            RisorsaId = IDDelete
                                        };
                                        Crud.Delete(p);
                                    }
                                    break;
                                default:
                                    continuaThree = false;
                                    break;
                            }
                        } while (continuaThree) ;
                        break;
                    #endregion
                    #region Gestione Eventi
                    case "3":
                        bool continuaFour = true;
                        do
                        {
                            string? inputDescrizione;
                        DateTime inputData;
                        string? inputLuogo;
                        int inputCapacita;
                        int inputIdRisorsa;
                        Console.WriteLine("Decidi che operazione effettuare\nDigita 1 : Crea un evento\nDigita 2 : Visualizza tutti gli eventi\nDigita 3 : Update di un'evento\nDigita 4 : Elimina evento\nAltro per uscire");
                        input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("Digita il nome dell'evento");
                                    input = Console.ReadLine();
                                    Console.WriteLine("Inserisci una descrizione");
                                    inputDescrizione = Console.ReadLine();
                                    Console.WriteLine("Digita la data dell'evento'");
                                    inputData = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Digita il luogo dell'evento");
                                    inputLuogo = Console.ReadLine();
                                    Console.WriteLine("Digita la capacità massima dell'evento");
                                    inputCapacita = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Scegli una risorsa da inserire, digita l'id di riferimento");
                                    List<Risorse> lista = Crud.ReadRisorse();
                                    foreach (Risorse p in lista)
                                    {
                                        Console.WriteLine($"Risorsa: {p.NomeRisorsa}, Tipo: {p.Tipo}, Quantita: {p.Quantita}, Costo: {p.Costo}, Fornitore: {p.Fornitore}");
                                    }
                                    inputIdRisorsa = Convert.ToInt32(Console.ReadLine());
                                    if (input is not null && inputDescrizione is not null && input != "" && inputDescrizione != "" && inputLuogo is not null && inputLuogo != "")
                                    {
                                        Eventi p = new Eventi()
                                        {
                                            NomeEvento = input,
                                            Descrizione = inputDescrizione,
                                            DataEvento = inputData,
                                            Luogo = inputLuogo,
                                            Capacita = inputCapacita,
                                            RisorseRif = inputIdRisorsa
                                        };

                                        Crud.Create(p);
                                        Console.WriteLine($"Evento inserito: {p.NomeEvento},  Data: {p.DataEvento}, Luogo: {p.Luogo}, Capacità massima: {p.Capacita}\nDescrizione: {p.Descrizione},");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Ecco la lista degli eventi");
                                    List<Eventi> lista2 = Crud.ReadEventi();
                                    foreach (Eventi p in lista2)
                                    {
                                        Console.WriteLine($"Evento inserito: {p.NomeEvento},  Data: {p.DataEvento}, Luogo: {p.Luogo}, Capacità massima: {p.Capacita}\nDescrizione: {p.Descrizione},");
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Modifica evento non implementata");
                                    break;
                                case "4":
                                    Console.WriteLine("Ecco la lista degli eventi");
                                    List<Eventi> lista3 = Crud.ReadEventi();
                                    foreach (Eventi p in lista3)
                                    {
                                        Console.WriteLine($"Evento inserito: {p.NomeEvento},  Data: {p.DataEvento}, Luogo: {p.Luogo}, Capacità massima: {p.Capacita}\nDescrizione: {p.Descrizione},");
                                    }
                                    Console.WriteLine("Scegli l'ID di riferimento da eliminare");
                                    int IDDelete = Convert.ToInt32(Console.ReadLine());
                                    if (input is not null)
                                    {
                                        Eventi p = new Eventi()
                                        {
                                            EventiId = IDDelete
                                        };
                                        Crud.Delete(p);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("");
                                    break;
                            }
                        }while (continuaFour) ;
                        break;
                    
                    #endregion
                    default:
                        Console.WriteLine("Chiusura programma");
                        continua = false;
                        break;
                }
            } while(continua); 
        }
    }
}
