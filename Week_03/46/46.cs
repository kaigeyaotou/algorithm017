using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._46
{
    public static class _46
    {
        public static IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == 0) return null;
            var result = new List<IList<int>>();
            recur(nums, 0, new List<int>(), ref result);
            return result;
        }

        private static void recur(int[] nums, int index, List<int> current, ref List<IList<int>> collection)
        {
            if (index == nums.Length)
            {
                int[] copy = new int[current.Count];
                Array.Copy(current.ToArray(), copy,copy.Length);
                collection.Add(copy);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!current.Any(a => a == nums[i]))
                {
                    current.Add(nums[i]);
                    recur(nums, index + 1, current, ref collection);
                    current.Remove(nums[i]);
                }
            }
        }
    }
}
