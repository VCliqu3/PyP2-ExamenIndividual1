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

        public int price;
        public int importPrice;

        public Citizen(string name, int farmingPoints, int fishingPoints, int harvestingPoints, int miningPoints, int price, int importPrice)
        {
            this.name = name;
            this.farmingPoints = farmingPoints;
            this.fishingPoints = fishingPoints;
            this.harvestingPoints = harvestingPoints;
            this.miningPoints = miningPoints;
            this.price = price;
            this.importPrice = importPrice; 
        }

        public int GetFarmingPoints() => farmingPoints;

        public void IncreaseFarmingPoints(int quantity) => farmingPoints += quantity;

        public int GetFishingPoints() => fishingPoints;

        public void IncreaseFishingPoints(int quantity) => fishingPoints += quantity;

        public int GetHarvestingPoints() => harvestingPoints;

        public void IncreaseHarvestingPoints(int quantity) => harvestingPoints += quantity;

        public int GetMiningPoints() => miningPoints;

        public void IncreaseMiningPoints(int quantity) => miningPoints += quantity;

    }
}
