using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.Models
{
    internal class Prestito
    {
        public int ID { get; set; }
        public int UtenteID { get; set; }
        public int LibroID { get; set; }
        public DateTime DataPrestito { get; set; }
        public DateTime? DataRitorno { get; set; }

        public Prestito()
        {
            
        }
        public Prestito(Utente utente, Libro libro, DateTime dataprestito, DateTime? dataritorno)
        {
            UtenteID = utente.ID;
            LibroID = libro.ID;
            DataPrestito = DateTime.Now;
            DataRitorno = null;
        }

    }
}
