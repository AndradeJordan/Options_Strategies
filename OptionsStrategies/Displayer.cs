using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OptionsStrategies
{
  
    public class DisplayerStrategie
    {
        public static List<int> DisplayOptions()
        {
            List<int> ParameterList = new List<int>();
            int user_choose1 = MyTools.Ask_number_between("What strategy do you want to price : \n" +
                "1 - Bullish Strategies \n" +
                "2 - Bearish Spreads \n" +
                "3 - Neutral Strategies \n", 1, 3);
            
            int user_choose2 = 0;
            if (user_choose1 == 1)
            {
                user_choose2 = MyTools.Ask_number_between("What Bullish Strategies do you want to price : \n" +
                "1 - Bull Call Spread \n" +
                "2 - Bull Put Spread\n" +
                "3 - Call Ratio Back Spread \n" +
                "4 - Bear Call Ladder\n" +
                "5 - Call Butterfly \n" +
                "6 - Synthetic Call\n" +
                "7 - Straps \n", 1, 7);
            }
            else if (user_choose1 == 2)
            {
                user_choose2 = MyTools.Ask_number_between("What Bearish Spreads do you want to price : \n" +
                "1 - Bear Call Spread \n" +
                "2 - Bear Put Spread\n" +
                "3 - Bull Put Ladder\n" +
                "4 - Put Ratio Back spread \n" +
                "5 - Strip\n" +
                "6 - Synthetic Put \n", 1, 6);
            }
            else
            {
                user_choose2 = MyTools.Ask_number_between("What Neutral Strategies do you want to price : \n" +
                "1 - Long & Short Straddles \n" +
                "2 - Long & Short Strangles \n" +
                "3 - Long & Short Iron Condor\n" +
                "4 - Long & Short Butterfly \n" +
                "5 - Box\n" , 1, 5);
            }
            ParameterList.Add(user_choose1);
            ParameterList.Add(user_choose2);

            return ParameterList;
        }
    }
    public class DisplayerBullCallSpread
    {
        public static List<Double> DisplayParameter()
        {
            List<double> ParameterList = new List<double>();
            List<string> displayParam = new List<string>();
            List<string> ParameterListTag = new List<string> { "interestRate", "spot", "sigma", "maturity", "strike1", "strike2",  "premium1", "premium2" };
            int cp = 0;
            while (true)
            {
                
                Console.Write("Enter your " + ParameterListTag[cp] + "'s Parameter : ");
                var param = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(param))
                {
                    Console.WriteLine("You need enter a double ");
                }
                else
                {
                    try
                    {
                        double param_conv = Double.Parse(param);
                        displayParam.Add(ParameterListTag[cp]+"="+param);
                        ParameterList.Add(param_conv);
                        Console.WriteLine(string.Join(", ", displayParam));
                        Console.WriteLine();
                        cp++;
                        if (ParameterListTag.Count == cp)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry you need to enter a double !!");
                    }
                    
                }

            }
            return ParameterList;
        }
        public static void DisplayPrice(double[] price)
        {
            Console.WriteLine($"Product :  Bull Call Spread : ");
            Console.WriteLine();
   
            Console.WriteLine($"Price of the Bull call spread by Simulation is {price[0]}");
            Console.WriteLine($"Price With Premium {price[1]}");
            Console.WriteLine($"On the confidence interval [ {price[0] - price[3]} {price[0] + price[3]} ]");
        }
    }
}
