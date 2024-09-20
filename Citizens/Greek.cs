using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class Greek : Citizen
    {
        private const int FARMING_POINTS = 3;
        private const int FISHING_POINTS = 2;
        private const int HARVESTING_POINTS = 4;
        private const int MINING_POINTS = 1;

        public Greek() : base(FARMING_POINTS, FISHING_POINTS, HARVESTING_POINTS, MINING_POINTS) { }
    }
}
