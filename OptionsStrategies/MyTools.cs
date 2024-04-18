using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsStrategies
{
    public static class MyTools
    {
        public static double Mean(double[] arr)
        {
            double sum = 0;
            foreach (double val in arr)
            {
                sum += val;
            }
            return sum / arr.Length;
        }

        public static double StandardDeviation(double[] arr)
        {
            double mean = Mean(arr);
            double sum = 0;
            foreach (double val in arr)
            {
                sum += Math.Pow(val - mean, 2);
            }
            double variance = sum / arr.Length;
            return Math.Sqrt(variance);
        }

        public static double GenerateNormal(double mu, double sigma)
        {
            Random random = new Random();
            double u1 = 1.0 - random.NextDouble(); // Pour éviter de diviser par zéro
            double u2 = 1.0 - random.NextDouble();
            double standardNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double normal = mu + sigma * standardNormal; 
            return normal;
        }

        public static double[,] MatrixNormal(int rows, int cols)
        {
            double[,] MyMatrix = new double[rows, cols];
            for(int i=0;i<rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    MyMatrix[i, j] = GenerateNormal(0, 1);
                }
            }
            return MyMatrix;
        }

            public static void PrintMatrix(double[,] matrixx)
        {
            int rows = matrixx.GetLength(0);
            int cols = matrixx.GetLength(1);

            for(int i=0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    Console.WriteLine(matrixx[i, j]);
                }
            }

        }
        public static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write('.');
            }
        }
        public static int Ask_number(string question)
        {
            int number = 0;
            while (number == 0)
            {
                Console.WriteLine(question);
                string number_string = Console.ReadLine();
                try
                {
                    number = int.Parse(number_string);
                }
                catch
                {
                    Console.WriteLine("You need to enter an integer !");
                    number = 0;
                }
            }
            return number;
        }
        public static int Ask_number_between(string question, int min, int max)
        {
            int result = Ask_number(question);
            if ((result < min) || (result > max))
            {
                Console.WriteLine("Sorry the number must to be between " + min + " and " + max);
                return Ask_number_between(question, min, max);
            }
            else
            {
                return result;
            }
        }
    }
}
