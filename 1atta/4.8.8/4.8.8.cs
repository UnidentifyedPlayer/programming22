using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._8._8
{
    class Program
    {
        static void ReadDoubleData(string message, ref double x, ref bool key)
        {
            double u;
            do
            {
                Console.WriteLine(message);
                bool result = double.TryParse(Console.ReadLine(), out u);
                if (result == true)
                    x = u;
                else
                    key = false;
            }
            while (!key);
        }
        static void ReadIntData(string message, ref int x, ref bool key)
        {
            int u;
            do
            {
                Console.WriteLine(message);
                bool result = int.TryParse(Console.ReadLine(), out u);
                if ((result == true)&(u>0))
                    x = u;
                else
                    key = false;
            }
            while (!key);
        }
        static void FirstSample( int n, double x)
        {
            double fact = 1;
            double s1 = 0;
            double s2 = 1;
            for (int i = 0; i < n; i++)
            {
                fact = fact * (i+1);
                s1 += (1 / fact + Math.Sqrt(Math.Abs(x)));
                s2 = s2 * (1 + (Math.Sin((i+1) * x) / fact));
            }
            Console.WriteLine("Резултат в первом примере равен {0}, \nа во втором - {1}", s1,s2);
        }
        static void Main(string[] args)
        {
            bool key = true;
            double x = 0;
            int n = 0;
                    ReadDoubleData("Введите значение x ", ref x, ref key);
                    ReadIntData("Введите значение n ", ref n, ref key);
        }
    }
}
