using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._1两数之和
{
    public static class _1
    {
        //public static int[] TwoSum1(int[] nums, int target)
        //{
        //    int[] result = new int[2];
        //    Hashtable hashtable = new Hashtable();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        hashtable.Add(i, nums[i]);
        //    }
        //    foreach (var item in hashtable.Keys)
        //    {
        //        if (hashtable.ContainsValue(target - (int)hashtable[item]))
        //        {
        //            var index=hashtable.Values
        //            result = new int[] {  };
        //        }
        //    }
        //    return result;
        //}
        public static int[] TwoSum(int[] nums, int target)
        {
            Hashtable tb = new Hashtable();
            for (int i=0;i<nums.Length;i++)
            {
                var sub = target - nums[i];
                if (tb.ContainsKey(sub))
                {
                    return new int[] { (int)tb[sub], i };
                }
                tb[nums[i]] = i;

            }
            throw new Exception("not found");
            //Array.Sort(nums);
            //int j = nums.Length - 1;
            //int i = 0;
            //int[] result = new int[2];
            //while (j >= i)
            //{
            //    //if (nums[j] > target)
            //    //{
            //    //    j--;
            //    //    continue;
            //    //}
            //    if (nums[i] + nums[j] > target)
            //    {
            //        if (nums[i + 1] + nums[j] > target)
            //        {
            //            j--;
            //        }
            //        else if (nums[i + 1] + nums[j] < target)
            //        {
            //            i++;
            //        }
            //        else
            //        {
            //            result = new int[] { i + 1, j };
            //            break;
            //        }
            //    }
            //    else if (nums[i] + nums[j] == target)
            //    {
            //        result = new int[] { i, j };
            //        break;
            //    }
            //}
            //return result;
        }
    }
}
