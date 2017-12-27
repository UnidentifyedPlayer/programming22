using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Class1
    {
        public class ListSorter
        {
            static public List<int> StrToList(string str)
            {
                List<int> weights = null;
                string[] Strweights = str.Split(new char[] { ',', ' ' });
                foreach (string s in Strweights) weights.Add(Convert.ToInt32(s));
                return weights;
            }
            public List<List<int>> ListSwapper(IList<int> weights, int sumWeights)
        {
            
        }
            
    }
}
