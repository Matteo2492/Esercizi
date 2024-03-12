using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le05_06.Classes
{
    internal class Cliente
    {
        public string? Nominativo;

        private string? indirizzo;
        public string? Indirizzo
        {
            get { return indirizzo; }
            set { indirizzo = value; }
        }

        private string? abbonamento;
        public string? Abbonamento
        {
            get { return abbonamento; }
            set { abbonamento = value; }
        }
        public Cliente(string? nominativo,string? via, string? abbonamento)
        {
            Nominativo = nominativo;
            Indirizzo = via;
            Abbonamento = abbonamento;
        }
        public override string ToString()
        {
            return$"[CLIENTE] Nominativo: {Nominativo}, Indirizzo consegna: {Indirizzo}, Codice Abbonamento: {Abbonamento}";
        }
        public string ToCSV()
        {
            return $"{Nominativo};{Indirizzo};{Abbonamento}";
        }
    }
}
