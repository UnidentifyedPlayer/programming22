using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Foorm1
    {
        static public int StrToValue(string str)
        {
            return Convert.ToInt32(str);
        }
        static public int[] StrToArray(string str)
        {
            return Array.ConvertAll
            (
                str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries),
                (s) => StrToValue(s)
            );
        }
        static public double FindNumbersBetweenNulls(int[] arr)
        {
            int s = 0;
            for(int i=1; i <= (arr.Length - 2); i++)
            {
                if ((arr[i - 1] == 0) && (arr[i + 1] == 0)&&(arr[i]!=0))
                    s++;
            }
            return s;
        }
        }
}
