using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_Task.Classes
{
    internal class Automobile : Veicolo
    {
        public int NumPorte { get; set; }


        public override void accensione()
        {
            Console.WriteLine("La macchina accellera");
        }

        public override void accellera()
        {
            Console.WriteLine("La macchina accellera");
        }

        public override void frena()
        {
            Console.WriteLine("La macchina accellera");
        }

        public Automobile(string? marca, int numporte)
        {
            Marca = marca;
            NumPorte = numporte;
        }
    }
}
