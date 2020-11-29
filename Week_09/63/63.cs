using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._63
{
    public static class _63
    {
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int width = obstacleGrid[0].Length;
            int[] dp = new int[width];
            dp[0] = 1;
            foreach(var row in obstacleGrid)
            {
                for (int j = 0; j < width; j++)
                {
                    if (row[j] == 1)
                        dp[j] = 0;
                    else if (j > 0)
                        dp[j] += dp[j - 1];
                }
            }
            return dp[width - 1];
        }
    }
}
