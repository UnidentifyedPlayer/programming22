using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void ReadData(string message,ref double x, ref bool key)
        {
            double u;
            do
            {
                Console.WriteLine(message);
                bool result = double.TryParse(Console.ReadLine(), out u);
                if (result == true)
                    x=u;
                else
                    key = false;
            }
            while (!key);
        }
        static double FindR(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        static double FindRadians(double x, double y)
        {
            return Math.Atan2(y, x);
                }
        static double TransferIntoDegrees(double x, double y, double radians)
        {
            radians = Math.Atan2(y, x);
            return radians * (180 / Math.PI);
        }
        static void Main(string[] args)
        {
            bool key = true;
            double x = 0;
            double y = 0;
            int count = 0;
            do
            {
                try
                {
                    ReadData("Значение ординаты: ", ref x, ref key);
                    ReadData("Значение абциссы: ",ref y, ref key);
                    double r, radians;
                    r = FindR(x, y);
                    Console.WriteLine("Полярный радиус равен {0}", r);
                    if (r == 0)
                    {
                        Console.WriteLine("Полярный угол - любое число");
                    }
                    else
                    {

                        if (x == 0)
                        {
                            if (y > 0)
                            {
                                Console.WriteLine("Полярный угол равен 90 градусам");
                            }
                            if (y < 0)
                            {
                                Console.WriteLine("Полярный угол равен -90 градусам");
                            }
                        }
                        else
                        {
                            if (y > 0)
                            {
                                radians = FindRadians(x, y);
                                Console.WriteLine("Полярный угол равен {0}", TransferIntoDegrees(x, y, radians));
                            }
                            if (y < 0)
                            {
                                radians = -FindRadians(x, y);
                                Console.WriteLine("Полярный угол равен {0}", TransferIntoDegrees(x, y, radians));
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите рациональные числа");
                }
                Console.WriteLine("Для ввода новых данных нажмите 0, для выхода -любую клавишу");
                count = int.Parse(Console.ReadLine());
            }
            while (count == 0);
        }
    }
}
