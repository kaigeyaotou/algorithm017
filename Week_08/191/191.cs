using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._191
{
    public static class _191
    {
        public static int HammingWeight(uint n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum++;
                n &= (n - 1);
            }
            return sum;

          
           
        }
    }
}
