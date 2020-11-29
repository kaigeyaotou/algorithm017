using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._8
{
    public static class _8
    {
        public static int MyAtoi(string str)
        {

            int sign = 1, result = 0, i = 0;
            while (str[i] == ' ') { i++; }
            if (str[i] == '-' || str[i] == '+')
            {
                sign = 1 - 2 * ((str[i++] == '-') ? 1 : 0);
            }
            while (str[i] >= '0' && str[i] <= '9')
            {
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && str[i] - '0' > 7))
                {
                    if (sign == 1) return int.MaxValue;
                    else return int.MinValue;
                }
                result = 10 * result + (str[i++] - '0');
            }
            return result * sign;
        }
    }
}
