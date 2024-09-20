using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public interface IHasFarmingPointsIndividual: IHasFarmingPoints
    {
        public void IncreaseFarmingPoints(int quantity);
    }
}
