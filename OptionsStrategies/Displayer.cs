using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OptionsStrategies
{
  

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
