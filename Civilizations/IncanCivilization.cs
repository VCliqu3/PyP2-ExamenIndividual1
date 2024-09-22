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

        public const int STARTING_FARMING_GOODS = 10;
        public const int STARTING_FISHING_GOODS = 5;
        public const int STARTING_HARVESTING_GOODS = 15;
        public const int STARTING_MINING_GOODS = 20;
        public IncanCivilization() : base(NAME, new Inca(), STARTING_FARMING_GOODS, STARTING_FISHING_GOODS, STARTING_HARVESTING_GOODS, STARTING_MINING_GOODS) { }

        public override Citizen GetOriginalCitizen() => new Inca();

    }
}
