using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._208
{
    public static class _208
    {
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
    }
}
