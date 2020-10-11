## 242 异位词

异位词概念：

> 大小写敏感的约定

两个字符串

+ 长度相同
+ 字母相同顺序可以不同



第一遍：

思路1：两个单词转换为两个数组，双层循环遍历看  time:O(n^2)   zone:O(1)

思路2：两个单词转换为两个数组，排序，循环判断	time:O(n) zone:O(1)

> 最佳思路(需过遍数)

使用哈希存储每个字母出现的次数，在第二个数组遍历-1

```bash
 public bool IsAnagram(string s, string t) {
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
    }
```



## 1  两数之和

描述：在数组中查找两数之和未指定值的下标

错误思路：先排序，双指针，导致下标位置不是原始数组位置

暴力解法：两遍遍历，时间复杂度O(n平方)，空间复杂度O(1)

> 思路二：使用hashtable,数据的值作为key,下标作为value

```csharp
  Hashtable hs = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                var num = target - nums[i];
                if (hs.ContainsKey(num)) return new int[] { i, int.Parse(hs[num].ToString()) };
                else hs.Add(nums[i], i);
            }
            throw new Exception("not found");
```



## 589 N叉树的前序遍历

思路一：迭代，使用栈数据结构处理

思路二：递归



代码如下：

```bash
 public static IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);
                if (node.children != null)
                {
                    if (node.children.Any())
                    {
                        for (int i = node.children.Count - 1; i >= 0; i--)
                        {
                            stack.Push(node.children[i]);
                        }
                    }
                }
            }
            return result;
        }
```



## 49字母异位词分组

思路一：242题提供了判断是否异位数的方法，结合hashtable，使用string.join做key,相同异位数的集合作为值，time:O(nk) ***单词集合遍历，k代表集合中字符串最大的长度***

> 思路二:虽然时间复杂度提高，但是也是一种方法，主要是在判断异位数的使用，str=>char[]  array.sort(char[])=>string   用最后的字符串作为key

> 思路三:代码提交中实际运行时间最少的方法，使用的ascii码+100这个公式计算出来的值作为key

思路一代码

```csharp
 private static string GetKey(string str)
        {
            var arr = str.ToCharArray();
            int[] counter = new int[26];
            foreach (var item in arr)
            {
                counter[item - 'a']++;
            }
            return string.Join(",", counter);
        }

            if (strs.Length == 0) return new List<IList<string>>();
            Hashtable hs = new Hashtable();
            foreach (var str in strs)
            {
                var key = GetKey(str);
                if (hs.ContainsKey(key)) ((IList<string>)hs[key]).Add(str);
                else hs.Add(key, new List<string> { str });
            }
            return hs.Values.Cast<IList<string>>().ToList();
```

***思路三代码***

```csharp
  Dictionary<long, int> s = new Dictionary<long, int>();
            IList<string> a = new List<string>();
            IList<IList<string>> ret = new List<IList<string>>();
            int count = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                long t = 1;

                for (int j = 0; j < strs[i].Length; j++)
                {
                    t = t * (long)((int)strs[i][j] + 200);
                }

                if (s.ContainsKey(t))
                {
                    ret[s[t]].Add(strs[i]);
                }
                else
                {
                    s.Add(t, count);
                    ret.Add(new List<string>() { strs[i] });
                    count++;
                }
            }
            return ret;


```

个人感觉写的啰嗦不可取





## 94 二叉树前序遍历

思路一：迭代，使用栈这种数据结构

==思路二：递归(暂不实现，等第三周递归)==

 ```bash
  var result = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            while (root != null || st.Any())
            {
                while (root != null)
                {
                    st.Push(root);
                    root = root.left;
                }

                root = st.Pop();
                result.Add(root.val);
                root = root.right;
            }
            return result;
 ```



## 144 二叉树前序遍历

思路一：迭代

思路二：递归

基础代码，多谢多练

```bash
 if (root == null) return new List<int>();
            List<int> result = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);
            while (st.Any())
            {
                var node = st.Pop();
                result.Add(node.val);
                if (node.right != null)
                    st.Push(node.right);
                if (node.left != null)
                    st.Push(node.left);
            }
            return result;
```



## 429 N叉树的层序遍历

思路一：正常的层序遍历+记录是否是同一层次的手段

> 思路二：递归

思路一有两种实现形式：	

* 使用Queue特性+size来是心啊
* 使用List来处理

两种实现，第二种相对较快

代码如下

```bash
 public static IList<IList<int>> LevelOrder(Node root)
        {

            #region 广度优先+size实现
            //if (root == null)
            //    return new List<IList<int>>();
            //List<IList<int>> result = new List<IList<int>>();
            //Queue<Node> queue = new Queue<Node>();
            //queue.Enqueue(root);
            //while (queue.Any())
            //{
            //    int size = queue.Count;
            //    List<int> temp = new List<int>();
            //    for (int i = 0; i < size; i++)
            //    {
            //        var node = queue.Dequeue();
            //        temp.Add(node.val);
            //        if (node.children != null)
            //        {
            //            foreach (var child in node.children)
            //            {
            //                queue.Enqueue(child);
            //            }
            //        }
            //    }
            //    result.Add(temp);
            //}

            //return result;
            #endregion

            #region 广度优先优化
            if (root == null)
                return new List<IList<int>>();

            var result = new List<IList<int>>();
            List<Node> levelNodes = new List<Node>();
            levelNodes.Add(root);
            while (levelNodes.Any())
            {
                List<Node> currentNodes = new List<Node>();
                List<int> values = new List<int>();
                foreach (var item in levelNodes)
                {
                    values.Add(item.val);
                    if (item.children != null)
                    {
                        currentNodes.AddRange(item.children);
                    }

                }
                result.Add(values);
                levelNodes = currentNodes;
            }

            return result;
            #endregion
        }
```

