using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class GreekCivilization : Civilization
    {
        public const string NAME = "Civilización Griega";

        public GreekCivilization() : base(NAME, new Greek()) { }
    }
}
