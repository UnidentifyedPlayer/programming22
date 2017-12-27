using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Class1
    {
        static public char[] StrToArray(string str)
        {
            return str.ToCharArray();
        }
        static public int FindVowels( char[] chars)
        {
            int s = 0;
            char[] vowels = new char[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            for(int z=0; z<= (chars.Length - 1); z++)
            {
                for (int r = 0; r <= 9; r++)
                {
                    if (chars[z] == vowels[r])
                    {
                        s++;
                        break;
                    }
                }
            }
            return s;
        }
        static public int FindCommas(char[] chars)
        {
            int s = 0;
            char[] commas = new char[] { ',', '.', '!', '?', '(', ')' };
            for (int z = 0; z <= (chars.Length - 1); z++)
            {
                for (int r = 0; r <= 5; r++)
                {
                    if (chars[z] == commas[r])
                    {
                        s++;
                        break;
                    }
                }
            }
            return s;
        }
    }
}
