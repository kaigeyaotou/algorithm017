using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._66
{
    public static class _66
    {
        public static int[] PlusOne(int[] digits)
        {
            #region 1-2
            //for (int i = digits.Length - 1; i >= 0; i--)
            //{
            //    digits[i]++;
            //    digits[i] %= 10;
            //    if (digits[i] != 0)
            //        return digits;
            //}
            //digits = new int[digits.Length + 1];
            //digits[0] = 1;
            //return digits;
            #endregion

            #region 3
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] %= 10;
                if (digits[i] != 0)
                    return digits;
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;

            #endregion
        }
    }
}
