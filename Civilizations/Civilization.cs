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

        public int money;

        private const int INITIAL_MONEY = 100;

        public Civilization(string name,Citizen originalCitizen, int farmingGoods, int fishingGoods, int harvestingGoods, int miningGoods)
        {
            this.name = name;
            this.originalCitizen = originalCitizen;
            citizens = new List<Citizen>();

            this.farmingGoods = farmingGoods;
            this.fishingGoods = fishingGoods;
            this.harvestingGoods = harvestingGoods;
            this.miningGoods = miningGoods;

            money = INITIAL_MONEY;
        }

        public abstract Citizen GetOriginalCitizen();

        public void AddOriginalCitizens(int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                citizens.Add(GetOriginalCitizen());
            }
        }

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
        public int IncreaseFishingGoods(int quantity) => fishingGoods += quantity;
        public int IncreaseHarvestinGoods(int quantity) => harvestingGoods += quantity;
        public int IncreaseMiningGoods(int quantity) => miningGoods += quantity;

        public int ReduceFarmingGoods(int quantity) => farmingGoods -= quantity;
        public int ReduceFishingGoods(int quantity) => fishingGoods -= quantity;
        public int ReduceHarvestingGoods(int quantity) => harvestingGoods -= quantity;
        public int ReduceMiningGoods(int quantity) => miningGoods -= quantity;

        public int GetFarmingGoodsEndOfTurn() => citizens.Count * GetFarmingPoints();
        public int GetFishingGoodsEndOfTurn() => citizens.Count * GetFishingPoints();
        public int GetHarvestingGoodsEndOfTurn() => citizens.Count * GetHarvestingPoints();
        public int GetMiningGoodsEndOfTurn() => citizens.Count * GetMiningPoints();

        public int GetMoney() => money;
        public void IncreaseMoney(int quantity) => money += quantity;
        public void ReduceMoney(int quantity) => money -= quantity;

    }
}
