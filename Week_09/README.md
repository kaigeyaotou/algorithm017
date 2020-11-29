### 8 atoi函数

> 思路：字符迭代

**--1=1  -+1=-1  需要特殊注意的操作 **

**对于int.max和int.min的处理**

```csharp
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
```



### 63 不同路径问题

> 经典dp

1、状态表达式  dp[i]表示走到i有几种方式

2、状态转移方程

+ 如果row[i]为1代表有石头，那么dp[i]=dp[i-1]
+ 如果row[i]为0，没有石头，那么dp[i]=dp[i]+dp[i-1]

```csharp
 public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int width = obstacleGrid[0].Length;
            int[] dp = new int[width];
            dp[0] = 1;
            foreach(var row in obstacleGrid)
            {
                for (int j = 0; j < width; j++)
                {
                    if (row[j] == 1)
                        dp[j] = 0;
                    else if (j > 0)
                        dp[j] += dp[j - 1];
                }
            }
            return dp[width - 1];
        }
```

