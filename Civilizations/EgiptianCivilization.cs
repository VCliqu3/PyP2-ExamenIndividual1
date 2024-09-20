using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1.Civilizations
{
    public class EgiptianCivilization : Civilization
    {
        public const string NAME = "Civilización Egipcia";

        public EgiptianCivilization() : base(NAME, new Egiptian()) { }
    }
}
