using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace OptionsStrategies
{
    class BullCallSpread : AbsParameter
    {
        public double interestRate, spot, siggma, maturity, strike1, strike2, timeValue, MCnumber, premium1, premium2;
        public double[,] Spaths ;


        public BullCallSpread(double interestRate, double spot, double siggma, double maturity, double strike1, double strike2, double timeValue, double MCnumber, double premium1, double premium2)
        {
            this.interestRate = interestRate;
            this.spot = spot;
            this.siggma = siggma;
            this.maturity = maturity;
            this.strike1 = strike1;
            this.strike2 = strike2;
            this.timeValue = timeValue;
            this.MCnumber = MCnumber;
            this.premium1 = premium1;
            this.premium2 = premium1;
            Spaths = new double[(int)MCnumber, (int)timeValue + 1];
        }

        public override string Description()
        {
            return $"Bull Call Spread with Black-Scholes model with r={interestRate}, S0={spot}, sigma={siggma}, T={maturity}, K1={strike1}, K2={strike2}, TimeValueNumber={timeValue}, MonteCarloNumber={MCnumber}";
        }

        public override void Simulation()
        {
            double delta = maturity / timeValue;
            Random rand = new Random();
            
            double[,] G = MyTools.MatrixNormal((int)MCnumber, (int)timeValue);
            

            double[,] LR = new double[(int)MCnumber, (int)timeValue + 1];
            for (int i = 0; i < MCnumber; i++)
            {
                LR[i, 0] = Math.Log(spot);//concatenate the np.log(S0)
                for (int j = 1; j <= timeValue; j++)
                {
                    LR[i, j] = (interestRate - 0.5 * siggma * siggma) * delta + Math.Sqrt(delta) * siggma * G[i, j - 1];
                }
            }

            //now we are going to do the cumulative sum to take the Sti
            for (int i = 0; i < MCnumber; i++)
            {
                double sum = 0;
                for (int j = 0; j <= timeValue; j++)
                {
                    sum += LR[i, j];
                    Spaths[i, j] = Math.Exp(sum);
                }
            }

            
        }

        public override double[] PriceSimulation()
        {
            
            Simulation();
            
            double[] parameter = new double[4];
            double[] premiumCompute1 = CallPrice(Spaths, interestRate, spot, siggma, maturity, strike1, MCnumber);
            double[] premiumCompute2 = CallPrice(Spaths, interestRate, spot, siggma, maturity, strike2, MCnumber);

            Console.WriteLine("Simulated Premium :");
            Console.WriteLine("Premium 1: " + premiumCompute1[0] + " Premium 2: " + premiumCompute2[0]);

            

            double[] payoff1 = new double[(int)MCnumber];
            double[] payoff2 = new double[(int)MCnumber];
            double[] payoffProduct = new double[(int)MCnumber];
            for (int i = 0; i < MCnumber; i++)
            {
                payoff1[i] = Math.Exp(-interestRate * maturity) * Math.Max(Spaths[i, Spaths.GetLength(1) - 1] - strike1, 0);
                payoff2[i] = Math.Exp(-interestRate * maturity) * Math.Max(Spaths[i, Spaths.GetLength(1) - 1] - strike2, 0);
                payoffProduct[i] = payoff1[i] - payoff2[i];

            }

            double price = MyTools.Mean(payoffProduct);
            double priceWithPremium = price - premium1 + premium2;

            double siggmaSimulated = MyTools.StandardDeviation(payoffProduct);
            double error = 1.96 * siggmaSimulated / Math.Sqrt(MCnumber);

            parameter[0] = price;
            parameter[1] = priceWithPremium;
            parameter[2] = siggmaSimulated;
            parameter[3] = error;

            return parameter;
        }

        public double[] CallPrice(double[,] St, double r, double s0, double sig, double T, double K, double N)
        {
            double[] parameter = new double[3];
            double[] payoff = new double[(int)N];
            
            for (int i = 0; i < N; i++)
            {
                payoff[i] = Math.Exp(-r * T) * Math.Max(St[i, St.GetLength(1) - 1] - K, 0);
            }
            //MyTools.PrintMatrix(payoff);
            double price = MyTools.Mean(payoff);
            double sigmaEstimate = MyTools.StandardDeviation(payoff);
            double error = 1.96 * sigmaEstimate / Math.Sqrt(N);

            parameter[0] = price;
            parameter[1] = sigmaEstimate;
            parameter[2] = error;
            

            return parameter;
        }


    }
}
