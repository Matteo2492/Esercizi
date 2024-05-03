using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Le05_06.Classes
{
    public abstract class Pubblicazioni
    {
        public string? Titolo { get; protected set; }
        public DateTime DataPubblicazione {  get; protected set; }


        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public double Prezzo {  get; protected set; }

        public int NumeroVendite = 0;

        public abstract void stampaDettaglio();

        public abstract string ToCSV();
        public abstract string venditaCSV();
    }
}
