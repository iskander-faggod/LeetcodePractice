﻿using System;

namespace LeetcodeTest.Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftNode = new TreeNode()
            {
                left = null,
                right = null,
                val = 9
            };

            var rightNode = new TreeNode()
            {
                left = new TreeNode()
                {
                    left = null,
                    right = null,
                    val = 15
                },
                right = new TreeNode()
                {
                    left = null,
                    right = null,
                    val = 7
                },
                val = 20
            };
            TreeNode root = new TreeNode()
            {
                left = leftNode,
                right = rightNode,
                val = 3,
            };
            InvertTree(root);
            MaxDepth(root);
        }

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root is null) return null;
            (root.left, root.right) = (root.right, root.left);
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);
            return Math.Max(left, right) + 1;
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p is null && q is null) return true;
            if ((p != null && q is null) || (p is null && q != null)) return false;
            if (p.val != q.val) return false;

            var nextLeft = IsSameTree(p.left, q.left);
            var nextRight = IsSameTree(p.right, q.right);
            return nextLeft && nextRight;
        }

        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root is null) return false;
            if (subRoot is null) return false;
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot) || IsEqualTree(root, subRoot);
        }
            
        private bool IsEqualTree(TreeNode s, TreeNode t) {
            if (s == null || t == null)
                return (s == null) && (t == null);
            return IsEqualTree(s.left, t.left) && IsEqualTree(s.right, t.right) && s.val == t.val;        
        }
        
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (p.val > root.val && q.val > root.val)
            {
                // если две ноды в правом поддереве
                return LowestCommonAncestor(root.right, p, q);
            }
            else if (p.val < root.val && q.val < root.val)
            {
                // если две ноды в левом поддереве
                return LowestCommonAncestor(root.left, p, q);
            }
            else
            {
                return root;
            }
        }   
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}