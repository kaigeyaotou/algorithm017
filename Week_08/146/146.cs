using System;
using System.Collections.Generic;
using System.Text;

namespace LeeCodeTur._146
{
    public static class _146
    {
        public class LinkedList
        {
            public int key { get; set; }
            public int value { get; set; }
            public LinkedList prev;
            public LinkedList next;
        }
        public class LRUCache
        {
            private Dictionary<int, LinkedList> dics;
            private LinkedList head;
            private LinkedList tail;
            private int cap;
            public LRUCache(int capacity)
            {
                cap = capacity;
                dics = new Dictionary<int, LinkedList>();
                head = new LinkedList() { value = -1 };
                tail = new LinkedList() { value = -1 };
                head.next = tail;
                tail.prev = head;
            }

            public int Get(int key)
            {
                if (dics.ContainsKey(key))
                {
                    return dics[key].value;
                }
                else return -1;
            }

            public void Put(int key, int value)
            {
                var flag = dics.ContainsKey(key);
                if (flag)
                {
                    // 存在，放到头节点
                    moveToHead(dics[key]);
                }
                else
                {
                    // 判断dic个数
                    if (dics.Count == cap)
                    {
                        // 移除
                        var tail = removeTail();
                        dics.Remove(tail.key);
                        // 添加
                        var linklist = new LinkedList() { key = key, value = value };
                        dics.Add(key, linklist);
                        
                    }
                    else
                    {

                    }
                }
            }

            private void addToHead(LinkedList node)
            {
                node.prev = head;
                node.next = head.next;
                head.next.prev = node;
                head.next = node;
            }

            private void removeNode(LinkedList node)
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
            }

            private void moveToHead(LinkedList node)
            {
                removeNode(node);
                addToHead(node);
            }

            private LinkedList removeTail()
            {
                var tail_node = tail.prev;
                removeNode(tail_node);
                return tail_node;

            }
        }
    }
}
