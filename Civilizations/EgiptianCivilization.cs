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

        public const int STARTING_FARMING_GOODS = 50;
        public const int STARTING_FISHING_GOODS = 200;
        public const int STARTING_HARVESTING_GOODS = 100;
        public const int STARTING_MINING_GOODS = 150;
        public EgiptianCivilization() : base(NAME, new Egiptian(), STARTING_FARMING_GOODS,STARTING_FISHING_GOODS,STARTING_HARVESTING_GOODS,STARTING_MINING_GOODS) { }

        public override Citizen GetOriginalCitizen() => new Egiptian();
    }
}
