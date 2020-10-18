using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._77
{
    public static class _77
    {
        public static IList<IList<int>> Combine(int n, int k)
        {
            if (n * k == 0) return null;
            int[] nums = new int[n];
            for (int i = 1; i <= n; i++)
            {
                nums[i - 1] = i;
            }
            var result = new List<IList<int>>();
            recur(nums, 0, k, new List<int>(), ref result);
            return result;
        }

        private static void recur(int[] nums, int index, int k, List<int> current, ref List<IList<int>> collection)
        {
            if (current.Count == k)
            {

                int[] temp = new int[current.Count];
                Array.Copy(current.ToArray(), temp, current.Count);
                collection.Add(temp);
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {

                current.Add(nums[i]);
                recur(nums, i + 1, k, current, ref collection);
                current.Remove(nums[i]);

            }
        }
    }
}
