using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.Models
{
    internal class Libro
    {
        public int ID { get; set; }
        public string? Titolo { get; set; }
        public bool Disponibilita { get; set; }

        public Libro()
        {
            
        }
        public Libro(string? titolo, bool disponibilità)
        {
            Titolo = titolo;
            Disponibilita = true;
        }
        public Libro(int id, string? titolo, bool disponibilità)
        {
            ID = id;
            Titolo = titolo;
            Disponibilita = true;
        }
    }
}
