using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._221
{
    public static class _221
    {
        public static int MaximalSquare(char[][] matrix)
        {
         
            int row = matrix.Length, column = matrix[0].Length, maxrow = 0;
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return maxrow;
            }
            int[,] dp = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0 || j == 0) dp[i, j] = 1;
                        else
                        {
                            dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i - 1, j - 1], dp[i, j - 1])) + 1;
                          
                        }
                        maxrow = Math.Max(maxrow, dp[i, j]);
                    }
                    
                }
            }
            return maxrow * maxrow; 
        }
    }
}
