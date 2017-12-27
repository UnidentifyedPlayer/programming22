using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        enum SimpleColor
        {
            White,
            Gray,
            Blue,
            Orange
        }
        static void ReadData(string message, ref double x, ref bool key)
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
        static bool IsPointInCircle(double x, double y,
        double x0, double y0, double r)
        {
            return ((x - x0) * (x - x0) + (y - y0) * (y - y0)) < r * r;
        }
        static bool IsPointLeftOfHParabola(double x, double y, double x0, double y0, double a)
        {
            return x < a * (y - y0) * (y - y0) + x0;
        }
        static bool IsPointLeftOfHParabola1(double x, double y)
        {
            return IsPointLeftOfHParabola(x, y, 4, -3, 0.5);
        }
        static bool IsPointInCircle1(double x, double y)
        {
            return IsPointInCircle(x, y, 1, -3, 4);
        }
        static bool IsPointInCircle2(double x, double y)
        {
            return IsPointInCircle(x, y, -2, -5, 2);
        }
        static SimpleColor GetColor(double x, double y)
        {
            if (IsPointLeftOfHParabola1(x, y) && !IsPointInCircle1(x, y) && !IsPointInCircle2(x, y))
                return SimpleColor.White;
            if (IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y) && !IsPointInCircle2(x, y))
                return SimpleColor.Gray;
            if (IsPointLeftOfHParabola1(x, y) && !IsPointInCircle1(x, y) && IsPointInCircle2(x, y))
                return SimpleColor.Orange;
            if (IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y) && IsPointInCircle2(x, y))
                return SimpleColor.White;
            if (!IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y))
                return SimpleColor.Blue;
            else
                return SimpleColor.Gray;
        }
        static void Main(string[] args)
        {
            bool key = true;
            double x = 0;
            double y = 0;
            int count = 0;
            bool T;
            do
            {
                T = true;
                try
                {
                    ReadData("x = ", ref x, ref key);
                    if ((x < -10 || x > 10))
                    {
                        Console.WriteLine("Введенное значение x не принадлежит отрезку [-10;10]");
                        T = false;
                    }
                    ReadData("y = ", ref y, ref key);
                    if ((y < -10 || y > 10))
                    {
                        Console.WriteLine("Введенное значение y не принадлежит отрезку [-10;10]");
                        T = false;
                    }
                    if (T == true) { Console.WriteLine(GetColor(x, y)); };
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
