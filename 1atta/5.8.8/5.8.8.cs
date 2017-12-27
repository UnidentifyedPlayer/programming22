using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._8._8
{
    class Program
    {
        static void ReadIntData(string message, ref int x, ref bool key)
        {
            int u;
            do
            {
                Console.WriteLine(message);
                bool result = int.TryParse(Console.ReadLine(), out u);
                if ((result == true) & (u > 0))
                    x = u;
                else
                    key = false;
            }
            while (!key);
        }
        static void PrintPicture(int s)
        {
       
            for (int h=0;h < s;h++)
            {
                for( int w = 0; w < s; w++)
                {
                    char ch;
                    if (w == h)
                        ch = '*';
                    else
                    {
                        if (w < h)
                            ch = ' ';
                        else
                        {
                            if ((w > h) && (w < s - 1) && (h > 0))
                                ch = '$';
                            else
                                ch = '*';
                        }
                    } 
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            bool key = true;
            int s = 0;
            ReadIntData("Введите размер фигуры ",ref s, ref key);
            PrintPicture(s);
        }
    }
}
