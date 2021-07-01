using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }

        public bool Equals(BSTNode node)
        {
            if (node == null) return false;
            if (NodeKey != node.NodeKey) return false;
            if (Level != node.Level) return false;
            if (Parent == null && node.Parent != null) return false;
            if (Parent != null && node.Parent == null) return false;
            if (Parent != null && node.Parent != null && Parent.NodeKey != node.Parent.NodeKey) return false;
            if (LeftChild == null && node.LeftChild != null) return false;
            if (LeftChild != null && node.LeftChild == null) return false;
            if (LeftChild != null && node.LeftChild != null && LeftChild.NodeKey != node.LeftChild.NodeKey)
                return false;
            if (RightChild == null && node.RightChild != null) return false;
            if (RightChild != null && node.RightChild == null) return false;
            if (RightChild != null && node.RightChild != null && RightChild.NodeKey != node.RightChild.NodeKey)
                return false;

            return true;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root; // корень дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            // создаём дерево с нуля из неотсортированного массива a
            // ...
            Array.Sort(a);

            GenerateTreeHelper(null, a);
        }

        private void GenerateTreeHelper(BSTNode parent, int[] a)
        {
            var middle = a.Length / 2;

            var node = new BSTNode(a[middle], parent);

            if (parent == null)
            {
                node.Level = 0;
                Root = node;
            }
            else
            {
                node.Level = parent.Level + 1;
                if (parent.NodeKey > node.NodeKey)
                {
                    parent.LeftChild = node;
                }
                else
                {
                    parent.RightChild = node;
                }
            }


            int[] temp;
            switch (a.Length)
            {
                case 2:
                    temp = new int[middle];
                    Array.Copy(a, 0, temp, 0, middle);
                    GenerateTreeHelper(node, temp);
                    return;
                case 1:
                    return;
            }

            temp = new int[middle];
            Array.Copy(a, 0, temp, 0, middle);
            GenerateTreeHelper(node, temp);
            temp = new int[a.Length - middle - 1];
            Array.Copy(a, middle+1, temp, 0, a.Length - middle - 1);
            GenerateTreeHelper(node, temp);
        }

        public bool IsBalanced(BSTNode root_node)
        {
            var leftHeight = root_node.Level; 
            var rightHeight = root_node.Level; 
            if (root_node.LeftChild != null)
            {
                leftHeight = Height(root_node.LeftChild);
                if (!IsBalanced(root_node.LeftChild)) return false;
            }
            if (root_node.RightChild != null)
            {
                rightHeight = Height(root_node.RightChild);
                if (!IsBalanced(root_node.RightChild)) return false;
            }

            return Math.Abs(leftHeight - rightHeight) <= 1;
        }

        private int Height(BSTNode node)
        {
            var height = node.Level;
            if (node.LeftChild != null)
            {
                height = Height(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                var rightHeight = Height(node.RightChild);
                if (rightHeight > height) height = rightHeight;
            }

            return height;
        }

        public bool Equals(BalancedBST tree)
        {
            return EqualsHelper(Root, tree.Root);
        }

        private bool EqualsHelper(BSTNode node, BSTNode testNode)
        {
            if (!node.Equals(testNode)) return false;

            if (node.LeftChild != null && !EqualsHelper(node.LeftChild, testNode.LeftChild)) return false;
            if (node.RightChild != null && !EqualsHelper(node.RightChild, testNode.RightChild)) return false;

            return true;
        }
    }
}