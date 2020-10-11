using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._49
{
    public static class _49
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            #region 使用dictionary实现
            //if (strs.Length <= 1)
            //{
            //    IList<IList<string>> result = new List<IList<string>>();
            //    result.Add(strs.ToList());
            //    return result;
            //}
            //Dictionary<string, IList<string>> hs = new Dictionary<string, IList<string>>();
            //int[] counter = new int[26];
            //for (int i = 0; i < strs.Length; i++)
            //{
            //    var arr = strs[i].ToCharArray();
            //    for (int j = 0; j < arr.Length; j++)
            //    {
            //        counter[arr[j] - 'a']++;
            //    }
            //    var key = string.Join(",", counter);
            //    List<string> value = new List<string>();
            //    if (hs.ContainsKey(key))
            //    {
            //        value = hs[key].ToList();
            //        value.Add(strs[i]);
            //        hs[key] = value;
            //    }
            //    else
            //    {
            //        value.Add(strs[i]);
            //        hs.Add(key, value);
            //    }
            //    counter = new int[26];

            //}

            //return hs.Values.ToList();
            #endregion

            #region 使用hashtable实现
            //if (strs.Length == 0) return new List<IList<string>>();
            //Hashtable hs = new Hashtable();
            //foreach (var str in strs)
            //{
            //    var key = GetKey(str);
            //    if (hs.ContainsKey(key)) ((IList<string>)hs[key]).Add(str);
            //    else hs.Add(key, new List<string> { str });
            //}
            //return hs.Values.Cast<IList<string>>().ToList();
            #endregion

            #region 3
            Hashtable hs = new Hashtable();
            List<IList<string>> result = new List<IList<string>>();
            if (strs.Length == 0) return result;
            for (int i = 0; i < strs.Length; i++)
            {
                var key = getkey(strs[i]);
                if (hs.ContainsKey(key))
                {
                    var list = (IList<string>)(hs[key]);
                    list.Add(strs[i]);
                }
                else
                {
                    hs.Add(key, new List<string> { strs[i] });
                }
            }

            return hs.Values.Cast<IList<string>>().ToList();
            #endregion
        }

        private static string getkey(string str)
        {
            var arr = str.ToCharArray();
            int[] counter = new int[26];
            for (int i = 0; i < arr.Length; i++)
            {
                counter[arr[i] - 'a']++;
            }

            return string.Join(",", counter);
        }

        //private static string GetKey(string str)
        //{
        //    var arr = str.ToCharArray();
        //    int[] counter = new int[26];
        //    foreach (var item in arr)
        //    {
        //        counter[item - 'a']++;
        //    }
        //    return string.Join(",", counter);
        //}
    }
}
