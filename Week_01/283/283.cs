using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._283
{
    public static class _283
    {
        public static int[] MoveZeroes(int[] nums)
        {
            #region 暴力解法 时间O(n平方)  空间O(1)
            //if (nums.Length <= 1) return nums;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int index = i;
            //    while (nums[index] == 0)
            //    {
            //        if (index == nums.Length - 1)
            //        {
            //            return nums;
            //        }
            //        index++;
            //    }
            //    int temp = nums[i];
            //    nums[i] = nums[index];
            //    nums[index] = temp;

            //}
            //return nums;
            #endregion

            #region 改进版本 O(n) O(1)
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    if (i != j)
                        nums[i] = 0;
                    j++;
                }
            }
            return nums;
            #endregion
        }
    }
}
