using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class Egiptian : Citizen
    {
        private const string NAME = "Egipcio";

        private const int BASE_FARMING_POINTS = 1;
        private const int BASE_FISHING_POINTS = 4;
        private const int BASE_HARVESTING_POINTS = 2;
        private const int BASE_MINING_POINTS = 3;

        private const int PRICE = 10;
        private const int IMPORT_PRICE = 20;

        public Egiptian() : base(NAME, BASE_FARMING_POINTS, BASE_FISHING_POINTS, BASE_HARVESTING_POINTS, BASE_MINING_POINTS, PRICE, IMPORT_PRICE) { }
    }
}

