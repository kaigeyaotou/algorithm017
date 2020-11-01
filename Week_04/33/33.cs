using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._33
{
    public static class _33
    {
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                if (nums[0] < nums[mid])
                {
                    if (target > nums[mid] || target < nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else if (nums[0] > nums[mid])
                {
                    if (target > nums[mid] && target < nums[0])
                    {
                        left = mid + 1;
                    }
                    else right = mid - 1;
                }
            }
            return -1;
        }

        //private static int findTarget(int[] nums, int target)
        //{
        //    int left = 0, right = nums.Length - 1, result = int.MinValue;
        //    while (left <= right)
        //    {
        //        int mid = (right + left) / 2;
        //        if (nums[mid] == target) result = mid;

        //        if (nums[mid] < target)
        //        {
        //            left = mid + 1;
        //        }
        //        else if (nums[mid] > target)
        //        {
        //            right = mid - 1;
        //        }
        //    }
        //    return result;
        //}
    }
}
