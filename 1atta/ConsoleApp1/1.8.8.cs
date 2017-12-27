using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void ReadData(string message, ref double u, ref bool key)
            {
          double x;
            do
            {
                Console.WriteLine(message);
                bool result = double.TryParse(Console.ReadLine(), out x);
                if (result == true)
                    u = x;
                else
                    key = false;
            }
            while (!key);
        }
    static double FindS(double u, double v, double t1, double t2)
        {
            return t1 * u + t2 * (u - v);
        }
        static void PrintS(double u, double v, double t1, double t2, bool key)
        {
            if (key == true)
                {
                if (u > v)
                {
                    Console.WriteLine("Путь, пройденный лодкой, равен " + FindS(u, v, t1, t2));
                }
                else
                {
                    Console.WriteLine("Недопустимая комбинация значений скоростей");
                }
            }
            else
            {
                Console.WriteLine("В качестве одного или нескольких параметров было(и) введены недопустимые значения");
                }
        }
        static void Main(string[] args)
        {
            int count = 0;
            do
            {

            bool key = true;
                  double u = 0;
                double v = 0;
                double t1 = 0;
                double t2 = 0;
                ReadData("Введите значение скорости лодки в стоячей воде: ", ref u, ref key);
                ReadData("Введите значение скорости течения: ", ref v, ref key);
                ReadData("Введите значение времени движения лодки по озеру: ", ref t1, ref key);
                ReadData("Введите значение времени движения лодки вверх по течению реки: ", ref t2, ref key);
                PrintS(u, v, t1, t2, key);


                Console.WriteLine("Для ввода новых данных нажмите 0, для выхода -любую клавишу");
                count = int.Parse(Console.ReadLine());
            }
            while (count == 0);
        }
    }
}
    

