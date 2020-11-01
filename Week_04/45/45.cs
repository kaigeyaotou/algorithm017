using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._45
{
    public static class _45
    {
        public static int Jump(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            return recur(0, nums, 0);
        }

        private static int recur(int index, int[] nums, int count)
        {
            int num = count;
            var bushu = nums[index];
            if ((bushu + index) >= nums.Length - 1) return num + 1;
            (int index, int max) tup = (0, 0);
            for (int i = 1; i <= bushu; i++)
            {
                int max = Math.Max((i + nums[i + index]), tup.max);
                if (max != tup.max)
                {
                    tup = (i + index, max);
                }
            }
            num = recur(tup.index, nums, count + 1);
            return num;
        }
    }
}
