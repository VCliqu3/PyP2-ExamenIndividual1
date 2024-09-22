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

        public const int STARTING_FARMING_GOODS = 20;
        public const int STARTING_FISHING_GOODS = 15;
        public const int STARTING_HARVESTING_GOODS = 5;
        public const int STARTING_MINING_GOODS = 10;
        public MayanCivilization() : base(NAME, new Mayan(), STARTING_FARMING_GOODS, STARTING_FISHING_GOODS, STARTING_HARVESTING_GOODS, STARTING_MINING_GOODS) { }

        public override Citizen GetOriginalCitizen() => new Mayan();

    }
}
