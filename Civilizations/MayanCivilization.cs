using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class MayanCivilization : Civilization
    {
        public const string NAME = "Civilización Maya";

        public MayanCivilization() : base(NAME, new Mayan()) { }
    }
}
