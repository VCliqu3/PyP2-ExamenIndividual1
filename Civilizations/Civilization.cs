using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public abstract class Civilization : IHasFarmingPoints, IHasFishingPoints, IHasHarvestingPoints, IHasMiningPoints
    {
        public string name;
        public Citizen originalCitizen;
        public List<Citizen> citizens;

        public int farmingGoods;
        public int fishingGoods;
        public int harvestingGoods;
        public int miningGoods;

        public Civilization(string name,Citizen originalCitizen, int farmingGoods, int fishingGoods, int harvestingGoods, int miningGoods)
        {
            this.name = name;
            this.originalCitizen = originalCitizen;
            citizens = new List<Citizen>();

            this.farmingGoods = farmingGoods;
            this.fishingGoods = fishingGoods;
            this.harvestingGoods = harvestingGoods;
            this.miningGoods = miningGoods;
        }

        public abstract Citizen GetOriginalCitizen();


        #region Interfaces
        public int GetFarmingPoints() 
        {
            int citizenCount = citizens.Count;
            if (citizenCount == 0) return 0;

            int pointsAccumulator = 0;

            foreach (Citizen citizen in citizens)
            {
                pointsAccumulator += citizen.GetFarmingPoints();
            }

            return pointsAccumulator / citizenCount;
        }

        public void IncreaseFarmingPoints(int quantity)
        {
            foreach(Citizen citizen in citizens)
            {
                citizen.IncreaseFarmingPoints(quantity);
            }
        }

        public int GetFishingPoints()
        {
            int citizenCount = citizens.Count;
            if (citizenCount == 0) return 0;

            int pointsAccumulator = 0;

            foreach (Citizen citizen in citizens)
            {
                pointsAccumulator += citizen.GetFishingPoints();
            }

            return pointsAccumulator / citizenCount;
        }

        public void IncreaseFishingPoints(int quantity)
        {
            foreach (Citizen citizen in citizens)
            {
                citizen.IncreaseFishingPoints(quantity);
            }
        }

        public int GetHarvestingPoints()
        {
            int citizenCount = citizens.Count;
            if (citizenCount == 0) return 0;

            int pointsAccumulator = 0;

            foreach (Citizen citizen in citizens)
            {
                pointsAccumulator += citizen.GetHarvestingPoints();
            }

            return pointsAccumulator / citizenCount;
        }

        public void IncreaseHarvestingPoints(int quantity)
        {
            foreach (Citizen citizen in citizens)
            {
                citizen.IncreaseHarvestingPoints(quantity);
            }
        }

        public int GetMiningPoints()
        {
            int citizenCount = citizens.Count;
            if (citizenCount == 0) return 0;

            int pointsAccumulator = 0;

            foreach (Citizen citizen in citizens)
            {
                pointsAccumulator += citizen.GetMiningPoints();
            }

            return pointsAccumulator / citizenCount;
        }

        public void IncreaseMiningPoints(int quantity)
        {
            foreach (Citizen citizen in citizens)
            {
                citizen.IncreaseMiningPoints(quantity);
            }
        }
        #endregion

        public int GetFarmingGoods() => farmingGoods;
        public int GetFishingGoods() => fishingGoods;
        public int GetHarvestingGoods() => harvestingGoods;
        public int GetMiningGoods() => miningGoods;

        public int IncreaseFarmingGoods(int quantity) => farmingGoods += quantity;
        public int IncreaseFishingGoods(int quantity) => farmingGoods += quantity;
        public int IncreaseHarvestinGoods(int quantity) => farmingGoods += quantity;
        public int IncreaseMiningGoods(int quantity) => farmingGoods += quantity;

        public int ReduceFarmingGoods(int quantity) => farmingGoods -= quantity;
        public int ReduceFishingGoods(int quantity) => farmingGoods -= quantity;
        public int ReduceHarvestinGoods(int quantity) => farmingGoods -= quantity;
        public int ReduceMiningGoods(int quantity) => farmingGoods -= quantity;

        public int GetFarmingGoodsEndOfTurn() => GetFarmingGoods() * GetFarmingPoints();
        public int GetFishingGoodsEndOfTurn() => GetFishingGoods() * GetFishingPoints();
        public int GetHarvestingGoodsEndOfTurn() => GetHarvestingGoods() * GetHarvestingPoints();
        public int GetMiningGoodsEndOfTurn() => GetMiningGoods() * GetMiningPoints();



    }
}
