using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculator
{
    public class Calculator : ICalculator
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }
        public double Sum(double a, double b)
        {
            Logger.Event("Mini Calculator started the calculations");
            double sum = a + b;
            Logger.Event("Mini Calculator completed the calculations");
            return sum;
        }
    }
}
