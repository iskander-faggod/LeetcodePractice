using System;
using System.Collections.Generic;

namespace LeetcodeTest.NTries
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static IList<int> Preorder(Node root)
        {
            var preorderList = new List<int>();
            var stack = new Stack<Node>();
            stack.Push(root);

            if (root is null)
            {
                return preorderList;
            }

            while (stack.Count > 0)
            {
                var tempNode = stack.Peek();
                stack.Pop();
                preorderList.Add(tempNode.val);
                for (int i = tempNode.children.Count - 1; i >= 0; i--)
                {
                    stack.Push(tempNode.children[i]);
                }
            }

            return preorderList;
        }
    }
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node()
    {
    }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}