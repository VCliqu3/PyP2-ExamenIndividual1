using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class Inca : Citizen
    {
        private const string NAME = "Inca";

        private const int FARMING_POINTS = 2;
        private const int FISHING_POINTS = 1;
        private const int HARVESTING_POINTS = 3;
        private const int MINING_POINTS = 4;

        public Inca() : base(NAME,FARMING_POINTS, FISHING_POINTS, HARVESTING_POINTS, MINING_POINTS) { }
    }
}
