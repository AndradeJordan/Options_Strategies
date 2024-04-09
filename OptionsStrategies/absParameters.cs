using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsStrategies
{
    public abstract class AbsParameter
    {
        public abstract string Description();
        public abstract void Simulation();
        public abstract double[] PriceSimulation();
    }
    
}
