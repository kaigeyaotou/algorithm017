using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._64
{
    public static class _64
    {
        public static int MinPathSum(int[][] grid)
        {
            int[,] dp = new int[grid.Length, grid[0].Length];
            for (int i = grid.Length - 1; i >= 0; i--)
            {
                for (int j = grid[0].Length - 1; j >= 0; j--)
                {
                    if (i == grid.Length - 1 && j == grid[0].Length - 1)
                    {
                        dp[i, j] = grid[i][j];
                        continue;
                    }
                    if (i == grid.Length - 1)
                    {
                        dp[i, j] = grid[i][j] + dp[i, j + 1];
                    }
                    else if (j == grid[0].Length - 1)
                    {
                        dp[i, j] = grid[i][j] + dp[i + 1, j];
                    }
                    else
                        dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j + 1]) + grid[i][j];
                }
            }

            return dp[0, 0];
        }
    }
}
