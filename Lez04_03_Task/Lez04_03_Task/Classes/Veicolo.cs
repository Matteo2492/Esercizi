using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_Task.Classes
{
    internal abstract class Veicolo
    {
        public string? Marca { get; set; }

        public abstract void accensione();

        public abstract void accellera();

        public abstract void frena();
    }
}
