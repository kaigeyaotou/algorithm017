## 动态规划

**动态规划步骤**

+ 分治思想拆分问题空间
+ 找出状态表达式(比较困难)
+ 找出递推公式(根据状态表达式来)

### 62 不同路径

>  思路一：递归，自顶向下变成思路太简单了

> 思路二：动态规划

+ 分治：机器人只能向右或者向下走
+ dp[i,j]:状态记录机器人走到i,j这个坐标有几种走法
+ dp[i,j]=dp[i-1,j]+dp[i,j-1]

**需要注意，很多题目使用动态规划可以从后向前思考*



代码如下

```csharp
 public int UniquePaths(int m, int n) {
       int[][] ans = new int[m][];
            for (int i=0;i<m;i++)
            {
                ans[i] = new int[n];
            }

            for (int i=0;i<m;i++)
            {
                ans[i][0] = 1;
            }

            for (int j=0;j<n;j++)
            {
                ans[0][j] = 1;
            }

            for (int i=1;i<m;i++)
            {
                for (int j=1;j<n;j++)
                {
                    ans[i][j] = ans[i - 1][j] + ans[i][j - 1];
                }
            }

            return ans[m - 1][n - 1];

    }
```



==个人感觉比较臃肿==,埋点，后期做优化



### 1143 最长公共子序列  (埋点)

> 思路一：暴力解法

> 思路二：动态规划

==埋点==：动手写暴力解法，从暴力解法过程中逐渐向动态规划思路靠

思路在视频中讲解，感觉太过抽象不好描述

代码如下

```csharp
 public int LongestCommonSubsequence(string text1, string text2) {
int[,] dp = new int[text1.Length + 1, text2.Length + 1];
            for (int i = 1; i <= text1.Length; i++)
            {
                for (int j = 1; j <= text2.Length; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[text1.Length, text2.Length];
    }
```







### 70 爬楼梯

> 思路一：递归，贼简单

> 思路二：动态规划

+ 分治：只能走一步或者两步，典型斐波那契列函数
+ d[i]:n=i时不同的走法
+ d[i]=d[i-1]+d[i-2]



**注意：再写递归的过程中发现可以缓存的值，把值缓存起来，形成了动态规划算法**



### 120 三角形最小路径和

> 思路一：递归

> 思路二：动态规划

**改题目也是在递归的过程中逐渐找到可以缓存的值，去进行的动态规划**



```csharp
 public int MinimumTotal(IList<IList<int>> triangle) {
 int row = triangle.Count;
            int[,] dp = new int[row + 1, row + 1];
            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
                }
            }
            return dp[0, 0];
    }
```



在c#实现细节方面本体需要特别注意



**作业如下：**



### 64 最小路径和

> 思路一：该题目开始想到的是不同的路径62题，找到所有的路径求和，然后找到最小的路径

> 思路二：动态规划，思路和一相似，但是实现起来要特别注意细节

+ 分治：只能向下或者向右走一步
+ dp[i,j]：到达i，j最小的步数
+ dp[i,j]=min(dp[i+1,j],dp[i,j+1])



```csharp
  public int MinPathSum(int[][] grid) {
 int[,] dp = new int[grid.Length, grid[0].Length];
            for (int i = grid.Length - 1; i >= 0; i--)
            {
                for (int j = grid[0].Length - 1; j >= 0; j--)
                {
                    if (i == grid.Length - 1 && j == grid[0].Length - 1)
                    {
                        dp[i, j] = grid[i][j];
                        continue;
                    }
                    if (i == grid.Length - 1)
                    {
                        dp[i, j] = grid[i][j] + dp[i, j + 1];
                    }
                    else if (j == grid[0].Length - 1)
                    {
                        dp[i, j] = grid[i][j] + dp[i + 1, j];
                    }
                    else
                        dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j + 1]) + grid[i][j];
                }
            }

            return dp[0, 0];
    }
```



### 221 最大正方形（埋点）

> 思路一：（埋点）暴力解法

> 思路二：动态规划

+ 分治：要找到最大长度，数组中每个为1的格子可以看作变成为1的正方形，因此根据比较另外三边的计算可以逐渐找到正方形(按照这个思路可以递归？（埋点）)
+ dp[i,j]:最大的边长
+ dp[i,j]=min(dp[i-1,j],dp[i-1,j-1],dp[i,j-1])+1

**(埋点)：感觉通过暴力解法，分析其中过程的缓存和剪枝，可以更好的理解本题目的动态规划思路**

```csharp
 public int MaximalSquare(char[][] matrix) {
        int maxrow = 0;
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return maxrow;
            }
       int row = matrix.Length, column = matrix[0].Length;
            
            int[,] dp = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0 || j == 0) dp[i, j] = 1;
                        else
                        {
                            dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i - 1, j - 1], dp[i, j - 1])) + 1;
                          
                        }
                        maxrow = Math.Max(maxrow, dp[i, j]);
                    }
                    
                }
            }
            return maxrow * maxrow; 
    }
```







### 32 最长有效括号（埋点）

> 思路一：不会做，直接看的动态规划的题解

后期补上解析

这个题目总感觉隐隐约约的有思路，但是认真分析的时候还是没有发现解题点

该题目关键思路

如果当前遍历的值是')'

+ 向前找一位，如果是'('，那么dp[i]=dp[i-1]+2
+ 如果是')'，可能前面还有连续的有效括号，那么就需要往前找
  + 找规律找到i-dp[i-1]-1这个元素



还是代码好理解

```csharp
 public int LongestValidParentheses(string s) {
 int[] dp = new int[s.Length + 1];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = i - 2 >= 0 ? dp[i - 2] + 2 : 2;
                    }
                    else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + 2 + ((i - dp[i - 1] - 2) >= 0 ? dp[i - dp[i - 1] - 2] : 0);
                    }
                }
            }

            return dp.Max();
    }
```







### 91 解码方法（坑）

**完全没思路，国际站题解有，我背下来了，需要好好理解下**



```csharp
   if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int[] dp = new int[n];
            dp[0] = s[0] != '0' ? 1 : 0;
            for (int i = 1; i < n; i++)
            {
                int first = int.Parse(s.Substring(i, 1));
                int second = int.Parse(s.Substring(i - 1, 2));
                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }
                if (second >= 10 && second <= 26)
                {
                    dp[i] += i >= 2 ? dp[i - 2] : 1;
                }
            }
            return dp[n - 1];
```



```csharp
   //int n = s.Length;
            //if (n == 0) return 0;

            //int[] memo = new int[n + 1];
            //memo[n] = 1;
            //memo[n - 1] = s[n - 1] != '0' ? 1 : 0;

            //for (int i = n - 2; i >= 0; i--)
            //    if (s[i] == '0') continue;
            //    else
            //    {
            //        int num = int.Parse(s.Substring(i, 2));
            //        if (num <= 26)
            //            memo[i] = memo[i + 1] + memo[i + 2];
            //        else
            //            memo[i] = memo[i + 1];
            //    }

            //return memo[0];
```















