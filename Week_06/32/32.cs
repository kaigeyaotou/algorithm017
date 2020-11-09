using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._32
{
    public static class _32
    {
        public static int LongestValidParentheses(string s)
        {
            int[] dp = new int[s.Length + 1];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = i - 2 >= 0 ? dp[i - 2] + 2 : 2;
                    }
                    else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + 2 + ((i - dp[i - 1] - 2) >= 0 ? dp[i - dp[i - 1] - 2] : 0);
                    }
                }
            }

            return dp.Max();
        }
    }
}
