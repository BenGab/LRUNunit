using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnitTestsLRUKelementArray
{
    public class KarraySol
    {
        public static int Sol(int[] A)
        {
            HashSet<int> opposites = new HashSet<int>();
            int result = 0;

            foreach(int item in A)
            {
                if(opposites.Contains(-1 * item))
                {
                    result = Math.Max(result, item < 0 ? item * -1 : item);
                }
                else
                {
                    opposites.Add(item);
                }
            }

            return result;
        }
    }
}
