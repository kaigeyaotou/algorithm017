### 860 柠檬水找零

> 思路一：该题目难度偏小，主要注意审题

```csharp
 public static bool LemonadeChange(int[] bills)
        {

            int num1 = 0;
            int num2 = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    num1++;

                }
                else if (bills[i] == 10 && num1 > 0)
                {
                    num1--;
                    num2++;
                }
                else if (bills[i] == 20 && num2 > 0 && num1 > 0)
                {
                    num1--;
                    num2--;
                }
                else if (bills[i] == 20 && num2 <= 0 && num1 > 3)
                {
                    num1 = num1 - 3;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
```

### 122 股票卖出2

>  思路1:经典的贪心算法解决，首先局部解就是最优解的前提下使用贪心算法，如果第一天买入，第二天卖出就有收益那么就这么操作

```csharp
int profile = 0;
            if (prices.Length <= 1) return 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profile += (prices[i] - prices[i - 1]) > 0 ? (prices[i] - prices[i - 1]) : 0;
            }

            return profile;
```

### 455 分发饼干

> 思路一:迭代，双指针比较

```csharp
Array.Sort(g);
            Array.Sort(s);
            int child = 0, biscuit = 0, result = 0;
            while (child < g.Length && biscuit < s.Length)
            {
                if (g[child] > s[biscuit])
                {
                    biscuit++;
                }
                else
                {
                    result++;
                    biscuit++;
                    child++;
                }
            }

            return result;
```





### 127单词接龙

> 思路一：注意，这是一个深度优先的变式，主要是对于单词的转换，转换后题目就回变为深度优先的问题

对于单词转换：

对于单词库中的单词全部转换为可变式

对于firstword的每一次转变都进行一次深度遍历，查询是否能够变成最后的endword

**代码中严格使用dfs的模板进行编写，注意visited**



```csharp
 Dictionary<string, IList<string>> dics = new Dictionary<string, IList<string>>();
            foreach (var word in wordList)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    var list = new List<string>();
                    if (dics.ContainsKey(newWord))
                    {
                        list = dics[newWord].ToList();
                        list.Add(word);
                        dics[newWord] = list;
                    }
                    else
                    {
                        list.Add(word);
                        dics.Add(newWord, list);
                    }
                }
            }

            List<string> visited = new List<string>();
            Queue<(string node, int count)> q = new Queue<(string node, int count)>();
            q.Enqueue((beginWord, 1));
            visited.Add(beginWord);
            while (q.Any())
            {
                var node = q.Dequeue();
                string word = node.node;
                int count = node.count;
                for (int i = 0; i < word.Length; i++)
                {
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    if (dics.ContainsKey(newWord))
                    {
                        var list = dics[newWord];
                        foreach (var item in list)
                        {
                            if (item == endWord)
                            {
                                return count + 1;
                            }
                            if (!visited.Any(a => a == item))
                            {
                                q.Enqueue((item, count + 1));
                                visited.Add(item);
                            }
                        }
                    }


                }
            }
            return 0;
```

### 33 搜索旋转数组

>  思路一：查找旋转节点，找到之后会得到两个有序的数组，然后查找目标值在的数组，对数组进行二分查找

时间复杂度分析：

+ 1、查找旋转节点O(n)
+ 2、二分查找O(Log(n))

这种思路时间复杂度较高





> 思路二：二分查找法的变式

**主要注意点**

+ 1、比较nums[0]与nums[mid]的大小，如果nums[0]<nums[mid],说明0-mid之间是有序的，否则说明0-mid之间有旋转节点
+ 根据1中分析的情况，找到向后规约的条件
+ 套用二分查找的模板进行查询



整体时间度就是二分查找的时间复杂度O(Log(n))

```csharp
 public int Search(int[] nums, int target) {
    if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                if (nums[0] < nums[mid])
                {
                    if (target > nums[mid] || target < nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else if (nums[0] > nums[mid])
                {
                    if (target > nums[mid] && target < nums[0])
                    {
                        left = mid + 1;
                    }
                    else right = mid - 1;
                }
            }
            return -1;
    }
```

### 45 跳跃游戏2

**审题**：注意要找的是最小的

> 思路一：之前做过跳跃游戏1，可以找到所有的情况，然后判断最小的

***时间复杂度想想就很高，放弃***

> 思路二：使用深度优先+贪心算法实现

具体细节如下：

+ nums[0]中会得到一个布数区间nums[0],在这个区间里面使用贪心算法
+ **贪心**：使用index(所在nums中的位置)+nums[index]的最大值
+ 找到最大值之后使用深度优先算法，重复步骤一

实现细节

**c#在贪心中使用tuple数据类型，1、存储index 2、存储max**



```csharp
 public int Jump(int[] nums) {
if (nums.Length <=1) return 0;
            return recur(0, nums, 0);
    }
     private  int recur(int index, int[] nums, int count)
        {
              int num = count;
            var bushu = nums[index];
            if ((bushu + index) >= nums.Length - 1) return num + 1;
            (int index, int max) tup = (0, 0);
            for (int i = 1; i <= bushu; i++)
            {
                int max = Math.Max((i + nums[i + index]), tup.max);
                if (max != tup.max)
                {
                    tup = (i + index, max);
                }
            }
            num = recur(tup.index, nums, count + 1);
            return num;
        }
```



