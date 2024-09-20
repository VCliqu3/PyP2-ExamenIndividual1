using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class IncanCivilization : Civilization
    {
        public const string NAME = "Civilización Inca";

        public IncanCivilization() : base(NAME, new Inca()) { }

        public override Citizen GetOriginalCitizen() => new Inca();

    }
}
