using DB_05_Biblioteca.DAL;
using DB_05_Biblioteca.Models;

namespace DB_05_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INSERIMENTO UTENTE
            Utente utente = new Utente("Matteo", "Cotza", "m@m.com");
            Console.WriteLine(UtenteDAL.getIstanza().Insert(utente) ? "Stappo!" : "Errore");

            //INSERIMENTO LIBRO
            Libro libro = new Libro("Il signore degli angelli", true);

            //LETTURA UTENTE 
            UtenteDAL utenteDAL = UtenteDAL.getIstanza();
            List<Utente> listaUtenti = utenteDAL.GetAll();
            Console.WriteLine(listaUtenti.Count());
            Utente utenteIDzero = listaUtenti[2];

            //UPDATE utente
            utenteIDzero.Nome = "Matteuccio";
            utenteDAL.Update(utenteIDzero);

            //DELETE utente
            //utenteDAL.Delete(utenteIDzero);



        }
    }
}
