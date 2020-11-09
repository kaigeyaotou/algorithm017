using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._91
{
    public static class _91
    {
        public static int NumDecodings(string s)
        {
            #region 1
            //int n = s.Length;
            //if (n == 0) return 0;

            //int[] memo = new int[n + 1];
            //memo[n] = 1;
            //memo[n - 1] = s[n - 1] != '0' ? 1 : 0;

            //for (int i = n - 2; i >= 0; i--)
            //    if (s[i] == '0') continue;
            //    else
            //    {
            //        int num = int.Parse(s.Substring(i, 2));
            //        if (num <= 26)
            //            memo[i] = memo[i + 1] + memo[i + 2];
            //        else
            //            memo[i] = memo[i + 1];
            //    }

            //return memo[0];
            #endregion

            #region 2
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int[] dp = new int[n];
            dp[0] = s[0] != '0' ? 1 : 0;
            for (int i = 1; i < n; i++)
            {
                int first = int.Parse(s.Substring(i, 1));
                int second = int.Parse(s.Substring(i - 1, 2));
                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }
                if (second >= 10 && second <= 26)
                {
                    dp[i] += i >= 2 ? dp[i - 2] : 1;
                }
            }
            return dp[n - 1];
            #endregion
        }
    }
}
