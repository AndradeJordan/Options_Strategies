using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace OptionsStrategies
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //double r = 0.05, S0 = 7846, sig = 0.2, T = 1, K1 = 7800, K2 = 7900;
            int N = 100000, n = 252;
            //double premium1 = 79, premium2 = 25;
            
            List<int> user_choice_list = DisplayerStrategie.DisplayOptions();
            int choice1 = user_choice_list[0], choice2 = user_choice_list[1];
            if(choice1 == 1 & choice2 == 1)
            {
                List<Double> MyListParameter = DisplayerBullCallSpread.DisplayParameter();

                double r = MyListParameter[0], S0 = MyListParameter[1], sig = MyListParameter[2], T = MyListParameter[3], K1 = MyListParameter[4], K2 = MyListParameter[5];

                double premium1 = MyListParameter[6], premium2 = MyListParameter[7];

                Console.WriteLine("Launch Pricer with Monte Carlo Simulation ( N = " + N + " , n = " + n + "... )");
                var displayTask = MyTools.DisplayProgress();

                var myBullCallSpread = new BullCallSpread(r, S0, sig, T, K1, K2, N, n, premium1, premium2);
                //var res = myBullCallSpread.PriceSimulation();
                Task<double[]> task = myBullCallSpread.PriceSimulation();
                myBullCallSpread.CallPremiumByBlackSholes();
                var res = await task;
                DisplayerBullCallSpread.DisplayPrice(res);
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Sorry this options is not implemented yet !");
            }
            
        }

        
    }
}
