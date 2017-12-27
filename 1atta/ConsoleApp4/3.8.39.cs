using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        enum SimpleColor
        {
            White,
            Gray,
            Green,
            Blue,
            Yellow,
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
        static bool IsPointInRectangle(double x, double y, double x0, double y0, double h, double w)
        {
            //Левый нижний угол
            return ((x > x0) && (x < x0 + w) && (y > y0) && (y < y0 + h));
        }
        static bool IsPointLeftOfHParabola(double x, double y, double x0, double y0, double a)
        {
            return x < a * (y - y0) * (y - y0) + x0;
        }
        static bool IsPointAboveLine(double x, double y, double x0, double y0, double a)
        {
            return y > a * (x - x0) + y0;
        }
        static bool IsPointBelowVParabola(double x, double y, double x0, double y0, double a)
        {
            return y < a * (x - x0) * (x - x0) + y0;
        }
        static bool IsPointBelowHParabola(double x, double y, double x0, double y0, double a)
        {
            return y < -1 * Math.Sqrt((x - x0) / a) + y0;
        }

        static bool IsPointAboveHParabola(double x, double y, double x0, double y0, double a)
        {
            return y > Math.Sqrt((x - x0) / a) + y0;
        }
        static bool IsPointLeftOfHParabola1(double x, double y)
        {
            return IsPointLeftOfHParabola(x, y, 3, -3, 1);
        }
        static bool IsPointInGrayRectangle(double x, double y)
        {
            return IsPointInRectangle(x, y, 1, -2, 2, 4);
        }
        static bool IsPointAboveLine1(double x, double y)
        {
            return IsPointAboveLine(x, y, -3, -3, 2.5);
        }
        static bool IsPointBelowParabola1(double x, double y)
        {
            return IsPointBelowHParabola(x, y, 0, 0, 0.125);
        }
        static bool IsPointAboveHParabola1(double x, double y)
        {
            if ((IsPointAboveHParabola(x, y, 1, 1, -1) == false) && (x < 1))
                return true;
            else return false;
        }
        static bool IsPointBelowHParabola1(double x, double y)
        {
            if ((IsPointBelowHParabola(x, y, 1, 1, -1) == false) && (x < 1))
                return true;
            else return false;
        }


        static SimpleColor GetColor(double x, double y)
        {
            if (IsPointAboveHParabola1(x, y) && IsPointAboveLine1(x, y))
                return SimpleColor.Orange;
            if (!(IsPointLeftOfHParabola1(x, y)) && IsPointAboveLine1(x, y))
                return SimpleColor.Yellow;
            if (IsPointBelowHParabola1(x, y) && IsPointAboveLine1(x, y))
                return SimpleColor.Blue;
            if (!(IsPointAboveLine1(x, y)) && (IsPointBelowParabola1(x, y)) && !(IsPointLeftOfHParabola1(x, y)) && !(IsPointInGrayRectangle(x, y)))
                return SimpleColor.Blue;
            if (IsPointLeftOfHParabola1(x, y) && IsPointBelowParabola1(x, y))
                return SimpleColor.Green;
            if (IsPointLeftOfHParabola1(x, y) && !(IsPointBelowParabola1(x, y)))
                return SimpleColor.Blue;
            if (!(IsPointBelowParabola1(x, y)) && !(IsPointAboveLine1(x, y)) && !(IsPointLeftOfHParabola1(x, y)))
                return SimpleColor.Green;

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
                    ReadData("x = ",ref x, ref key);
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
