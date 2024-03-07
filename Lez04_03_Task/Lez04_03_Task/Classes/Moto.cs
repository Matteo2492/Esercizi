using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_Task.Classes
{
    internal class Moto : Veicolo
    {
        public int Cilindrata { get; set; }

        public override void accensione()
        {
            Console.WriteLine("La moto si accende");
        }

        public override void accellera()
        {
            Console.WriteLine("La moto accellera");
        }

        public override void frena()
        {
            Console.WriteLine("La moto frena");
        }
        public Moto(string? marca, int cilindrata)
        {
            Marca = marca;
            Cilindrata = cilindrata;
        }
    }
}
