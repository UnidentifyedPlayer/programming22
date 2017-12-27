using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        enum SimpleColor
        {
            White,
            Orange,
            Green,
            Blue,
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

        static bool IsPointInRectangle(double x, double y, double x0, double y0, double w, double h)
        {
            //Левый нижний угол
            return ((x >= x0) && (x < x0 + w) && (y >= y0) && (y < y0 + h));
        }
        static bool IsPointAboveLine(double x, double y, double x0, double y0, double a)
        {
            return y > a * (x - x0) + y0;
        }
        static bool IsPointLeftOfParabola(double x, double y, double x0, double y0, double a)
        {
            return x > a * (y - y0) * (y - y0) + x0;
        }
        
        static bool IsPointAboveHParabola(double x, double y, double x0, double y0, double a)
        {
            return y > (Math.Sqrt((x - x0) / a) + y0);
        }
        static bool IsPointBelowHParabola(double x, double y, double x0, double y0, double a)
        {
            return y <( -1 * Math.Sqrt((x - x0) / a) + y0);
        }
        static bool IsPointInRectangle1(double x, double y)
        {
            return IsPointInRectangle(x, y, -3, -4, 3, 4);
        }
        
        static bool IsPointAboveLine1(double x, double y)
        {
            return IsPointAboveLine(x, y, -2, 0, -2);
        }
        static bool IsPointLeftOfParabola1(double x, double y)
        {
            return IsPointLeftOfParabola(x, y, -4, 0, 1);
        }
        static bool IsPointAboveHParabola1(double x, double y)
        {
            if ((x >= 4) && (IsPointAboveHParabola(x, y, -4, 0, 1)))
            { return true; } 
            else 
             { return false; }
        }
        static bool IsPointBelowHParabola1(double x, double y)
        {
            if ((x >= - 4) && (IsPointBelowHParabola(x, y, -4, 0, 1)))
            { return true; }
            else
            { return false; }
        }
        static SimpleColor GetColor(double x, double y)
        {
            if ((IsPointLeftOfParabola1(x,y)) && (!(IsPointInRectangle1(x, y))))
                return SimpleColor.Blue;
            if ((IsPointInRectangle1(x, y)) && (IsPointBelowHParabola1(x, y)) && ((IsPointAboveLine1(x, y))))
                return SimpleColor.Orange;
            if ((IsPointLeftOfParabola1(x, y)) && ((!(IsPointAboveLine1(x, y))) && (IsPointInRectangle1(x, y))))
                return SimpleColor.White;
            if ((IsPointAboveHParabola1(x, y)) && (IsPointAboveLine1(x, y)))
                return SimpleColor.Blue;
            else
                return SimpleColor.Green;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetColor(-0.5,-2.5));
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
            while (count == 0) ;
        }
          
    }
}
