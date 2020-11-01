using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._122
{
    public static class _122
    {
        public static int MaxProfit(int[] prices)
        {
            int profile = 0;
            if (prices.Length <= 1) return 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profile += (prices[i] - prices[i - 1]) > 0 ? (prices[i] - prices[i - 1]) : 0;
            }

            return profile;
        }
    }
}
