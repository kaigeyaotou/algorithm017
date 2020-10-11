using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._242
{
    public static class _242
    {
        public static bool IsAnagram(string s, string t)
        {
            #region O(n)
            //if (s.Length != t.Length) return false;
            //var arr_s = s.ToCharArray();
            //var arr_t = t.ToCharArray();
            //Array.Sort(arr_s);
            //Array.Sort(arr_t);
            //for (int i = 0; i < arr_s.Length; i++)
            //{
            //    if (arr_s[i] != arr_t[i]) return false;
            //}
            //return true;
            #endregion

            #region hash 
            if (s.Length != t.Length) return false;
            int[] counter = new int[26];
            var arr_s = s.ToCharArray();
            var arr_t = t.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                counter[arr_s[i] - 'a']++;
                counter[arr_t[i] - 'a']--;
            }
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] != 0) return false;
            }
            return true;
            #endregion
        }
    }
}
