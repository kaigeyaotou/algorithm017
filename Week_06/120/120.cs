using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeeCodeTur._120
{
    public class _120
    {
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int row = triangle.Count;
            int[,] dp = new int[row + 1, row + 1];
            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
                }
            }
            return dp[0, 0];
        }
    }
}
