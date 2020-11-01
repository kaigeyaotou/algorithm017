using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._455
{
    public static class _455
    {
        public static int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int child = 0, biscuit = 0, result = 0;
            while (child < g.Length && biscuit < s.Length)
            {
                if (g[child] > s[biscuit])
                {
                    biscuit++;
                }
                else
                {
                    result++;
                    biscuit++;
                    child++;
                }
            }

            return result;
        }
    }
}
