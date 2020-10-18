## 46 全排列递归实现

思路一：类似于括号生成的思路

实现如下

```bash
  public IList<IList<int>> Permute(int[] nums) {
if (nums.Length == 0) return null;
            var result = new List<IList<int>>();
            recur(nums, 0, new List<int>(), ref result);
            return result;
    }
       private  void recur(int[] nums, int index, List<int> current, ref List<IList<int>> collection)
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
```

注意点：

+ 实现细节方面，注意使用了List(current)引用类型



## 77 组合

思路一：类似于上面的全排列的递归实现，需要注意的是结果集里面重复元素

代码实现：

```csharp
 public IList<IList<int>> Combine(int n, int k) {
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
    
     private  void recur(int[] nums, int index, int k, List<int> current, ref List<IList<int>> collection)
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
```

