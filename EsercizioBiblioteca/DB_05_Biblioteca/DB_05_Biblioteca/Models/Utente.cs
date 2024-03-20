using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.Models
{
    internal class Utente
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }

        public Utente()
        {
            
        }
        public Utente(string? nome, string cognome, string? email)
        {
            Nome = nome;
            Cognome = cognome;
            Email = email;  
        }
        public Utente(int id, string? nome, string cognome, string? email)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }
    }
}
