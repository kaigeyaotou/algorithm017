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

###  22 括号生成

***经典题目***

>  思路：递归+剪枝

开始思路：有2*n个位置可以任意填写，遍历所有的可能性

代码大体如下(盲写，可能有错误)

```csharp
 public IList<string> GenerateParenthesis(int n) {
 	 var result = new List<string>();
     if(n==0) return result;
     recur(2*n,0,"",ref result);
     return result;
 }

private void recur(int max,int index,string current,ref List<string> result){
    if(index==max){
        result.add(current);
        return;
    }
    if(index<max){
        recur(max,index+1,current+")",ref result);
        recur(max,inde+1,current+"(",ref result);
    }
}
```

**接下来进行剪枝操作**

左括号个数应该大于右括号个数

左右括号个数应该小于n

代码如下：

```csharp
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
  var result = new List<string>();
        if(n==0)return result;
            recur(n, 0, 0, "", ref result);
            return result;
    }
       private  void recur(int n, int left, int right, string current, ref List<string> result)
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
}
```

### 208 实现Trie树

> 思路：使用trieNode经典的树结构当作中间的数据结构，每一层都有26个节点

**注意**

使用一个标志符来表示是否是一个完整单词

```csharp
 public class TrieNode
        {
            public char val { get; set; }
            public bool isWord;
            public TrieNode[] children = new TrieNode[26];
            public TrieNode() { }
            public TrieNode(char c)
            {
                TrieNode node = new TrieNode();
                node.val = c;
            }
        }

        public class Trie
        {
            private TrieNode root;
            /** Initialize your data structure here. */
            public Trie()
            {
                root = new TrieNode(' ');
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var wr = root;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (wr.children[c - 'a'] == null)
                    {
                        wr.children[c - 'a'] = new TrieNode(c);
                    }
                    wr = wr.children[c - 'a'];
                }
                wr.isWord = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var wr = root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (wr.children[word[i] - 'a'] == null) return false;
                    wr = wr.children[word[i] - 'a'];
                }
                return wr.isWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var wr = root;
                for (int i = 0; i < prefix.Length; i++)
                {
                    if (wr.children[prefix[i] - 'a'] == null) return false;
                    wr = wr.children[prefix[i] - 'a'];
                }
                return true;
            }
        }
/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
```

