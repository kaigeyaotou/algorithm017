using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._22
{
    public static class _22
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            //IList<string>[] dp = new IList<string>[n + 1];
            //return Digui(n, ref dp);
            #region 1
            //List<string> result = new List<string>();
            //if (n == 0)
            //{
            //    return result;
            //}
            //_generate(0, 0, n, "", ref result);
            //return result;
            #endregion

            #region 2
            var result = new List<string>();
            recur(n, 0, 0, "", ref result);
            return result;
            #endregion 2
        }

        private static void recur(int n, int left, int right, string current, ref List<string> result)
        {
            if (left == n && right == n)
            {
                result.Add(current);
                return;
            }

            if (left < n)
                recur(n, left + 1, right, current + "(", ref result);
            if (left > right && right < n)
            {
                recur(n, left, right + 1, current + ")", ref result);
            }
        }

        //public static void _generate(int left, int right, int max, string s, ref List<string> result)
        //{
        //    // terminator
        //    if (left == max && right == max)
        //    {
        //        //Console.WriteLine(s);
        //        result.Add(s);
        //        return;
        //    }

        //    //process

        //    //drill down
        //    if (left < max)
        //        _generate(left + 1, right, max, s + "(", ref result);
        //    if (right < max && right < left)
        //        _generate(left, right + 1, max, s + ")", ref result);
        //    //reverse state
        //}
        #region old code
        //private static IList<string> Digui(int n, ref IList<string>[] dp)
        //{
        //    #region oldcode
        //    //IList<string> result = new List<string>();
        //    //if (n == 0)
        //    //{
        //    //    dp[n] = new List<string>() { "" };
        //    //    return dp[n];
        //    //}
        //    //for (int i = 0; i < n; i++)
        //    //{
        //    //    IList<string> list_front = new List<string>();
        //    //    IList<string> list_back = new List<string>();
        //    //    if (dp[i] != null)
        //    //    {
        //    //        list_front = dp[i];
        //    //    }
        //    //    else
        //    //    {
        //    //        list_front = Digui(i, ref dp);
        //    //    }
        //    //    if (dp[n - i - 1] != null)
        //    //    {
        //    //        list_back = dp[n - i - 1];
        //    //    }
        //    //    else
        //    //    {
        //    //        list_back = Digui(n - i - 1, ref dp);
        //    //    }

        //    //    foreach (var front in list_front)
        //    //    {
        //    //        foreach (var back in list_back)
        //    //        {
        //    //            result.Add("(" + front + ")" + back);
        //    //        }
        //    //    }


        //    //}
        //    //dp[n] = result;
        //    //return result;
        //    #endregion
        //}
        #endregion
    }
}
