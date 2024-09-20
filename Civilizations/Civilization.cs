using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public abstract class Civilization
    {
        public string name;
        public Citizen citizen;

        public Civilization(string name,Citizen citizen)
        {
            this.name = name;
            this.citizen = citizen;
        }
    }
}
