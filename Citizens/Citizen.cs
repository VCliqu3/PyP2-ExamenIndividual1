using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public abstract class Citizen
    {
        public int farmingPoints;
        public int fishingPoints;
        public int harvestingPoints;
        public int miningPoints;

        public Citizen(int farmingPoints, int fishingPoints, int harvestingPoints, int miningPoints)
        {
            this.farmingPoints = farmingPoints;
            this.fishingPoints = fishingPoints;
            this.harvestingPoints = harvestingPoints;
            this.miningPoints = miningPoints;
        }
    }
}
