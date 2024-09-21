using System;
using System.Collections.Generic;
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

        public Civilization(string name,Citizen originalCitizen)
        {
            this.name = name;
            this.originalCitizen = originalCitizen;
            citizens = new List<Citizen>();
        }

        public abstract Citizen GetOriginalCitizen();


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
    }
}
