using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public abstract class Citizen : IHasFarmingPoints, IHasFishingPoints, IHasHarvestingPoints, IHasMiningPoints
    {
        public string name;

        public int farmingPoints;
        public int fishingPoints;
        public int harvestingPoints;
        public int miningPoints;

        public Citizen(string name, int farmingPoints, int fishingPoints, int harvestingPoints, int miningPoints)
        {
            this.name = name;
            this.farmingPoints = farmingPoints;
            this.fishingPoints = fishingPoints;
            this.harvestingPoints = harvestingPoints;
            this.miningPoints = miningPoints;
        }

        public int GetFarmingPoints() => farmingPoints;

        public void IncreaseFarmingPoints(int quantity) => farmingPoints += quantity;

        public int GetFishingPoints() => farmingPoints;

        public void IncreaseFishingPoints(int quantity) => farmingPoints += quantity;

        public int GetHarvestingPoints() => farmingPoints;

        public void IncreaseHarvestingPoints(int quantity) => farmingPoints += quantity;

        public int GetMiningPoints() => farmingPoints;

        public void IncreaseMiningPoints(int quantity) => farmingPoints += quantity;

    }
}
