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

        #region AveragePoints

        public abstract Citizen GetOriginalCitizen();

        private int GetAverageFarmingPoints()
        {
            int citizenCount = citizens.Count;
            if (citizenCount == 0) return 0;

            int pointsAccumulator = 0;

            foreach(Citizen citizen in citizens)
            {
                pointsAccumulator += citizen.GetFarmingPoints();
            }

            return pointsAccumulator/citizenCount;
        }

        private int GetAverageFishingPoints()
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

        private int GetAverageHarvestingPoints()
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

        private int GetAverageMiningPoints()
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

        #endregion


        public int GetFarmingPoints() => GetAverageFarmingPoints();

        public int GetFishingPoints() => GetAverageFishingPoints();

        public int GetHarvestingPoints() => GetAverageHarvestingPoints();

        public int GetMiningPoints() => GetAverageMiningPoints();
    }
}
