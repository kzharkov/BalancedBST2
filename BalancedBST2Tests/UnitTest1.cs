using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace BalancedBST2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //       5
            //     /  \
            //    3    7
            //   / \  / \
            //  2  4 6   8

            var arr = new[] {3, 6, 8, 2, 4, 5, 7};

            var tree = new BalancedBST();

            tree.GenerateTree(arr);

            var expectedTree = new BalancedBST();
            var root = new BSTNode(5, null) {Level = 0};
            var node3 = new BSTNode(3, root) {Level = 1};
            root.LeftChild = node3;
            var node7 = new BSTNode(7, root) {Level = 1};
            root.RightChild = node7;
            var node2 = new BSTNode(2, node3) {Level = 2};
            node3.LeftChild = node2;
            var node4 = new BSTNode(4, node3) {Level = 2};
            node3.RightChild = node4;
            var node6 = new BSTNode(6, node7) {Level = 2};
            node7.LeftChild = node6;
            var node8 = new BSTNode(8, node7) {Level = 2};
            node7.RightChild = node8;
            expectedTree.Root = root;

            Assert.AreEqual(tree.Root.Level, 0);
            Assert.IsTrue(tree.Equals(expectedTree));
            Assert.IsTrue(tree.IsBalanced(tree.Root));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //       4
            //     /  \
            //    3    7
            //   /    / \
            //  2    5   8

            var arr = new[] {3, 8, 2, 4, 5, 7};

            var tree = new BalancedBST();

            tree.GenerateTree(arr);

            var expectedTree = new BalancedBST();
            var root = new BSTNode(4, null) {Level = 0};
            var node2 = new BSTNode(2, root) {Level = 1};
            root.LeftChild = node2;
            var node7 = new BSTNode(7, root) {Level = 1};
            root.RightChild = node7;
            var node3 = new BSTNode(3, node2) {Level = 2};
            node2.RightChild = node3;
            var node5 = new BSTNode(5, node7) {Level = 2};
            node7.LeftChild = node5;
            var node8 = new BSTNode(8, node7) {Level = 2};
            node7.RightChild = node8;
            
            expectedTree.Root = root;

            Assert.IsTrue(tree.Equals(expectedTree));
            Assert.IsTrue(tree.IsBalanced(tree.Root));
        }

        [TestMethod]
        public void NotBalanced()
        {
            //        5
            //      / 
            //     3  
            //    / \ 
            //   2  4
            //  /
            // 1

            var tree = new BalancedBST();
            var root = new BSTNode(5, null) {Level = 0};
            var node3 = new BSTNode(3, root) {Level = 1};
            root.LeftChild = node3;
            var node2 = new BSTNode(2, node3) {Level = 2};
            node3.LeftChild = node2;
            var node4 = new BSTNode(4, node3) {Level = 2};
            node3.RightChild = node4;
            var node1 = new BSTNode(1, node2) {Level = 3};
            node2.LeftChild = node1;
            tree.Root = root;

            Assert.IsFalse(tree.IsBalanced(tree.Root));
        }

        [TestMethod]
        public void NotBalanced2()
        {
            //        5
            //      /  \
            //     2    7
            //      \  / \
            //      4 6   8
            //     /
            //    3

            var tree = new BalancedBST();
            var root = new BSTNode(5, null) {Level = 0};
            var node2 = new BSTNode(2, root) {Level = 1};
            root.LeftChild = node2;
            var node7 = new BSTNode(7, root) {Level = 1};
            root.RightChild = node7;
            var node4 = new BSTNode(4, node2) {Level = 2};
            node2.RightChild = node4;
            var node6 = new BSTNode(6, node7) {Level = 2};
            node7.LeftChild = node6;
            var node8 = new BSTNode(8, node7) {Level = 2};
            node7.RightChild = node8;
            var node3 = new BSTNode(3, node4) {Level = 3};
            node4.LeftChild = node3;
            tree.Root = root;

            Assert.IsFalse(tree.IsBalanced(tree.Root));
        }

        [TestMethod]
        public void OnlyRoot()
        {
            var arr = new[] {5};

            var tree = new BalancedBST();

            tree.GenerateTree(arr);
            
            var expectedTree = new BalancedBST();
            var root = new BSTNode(5, null) {Level = 0};
            expectedTree.Root = root;
            
            Assert.IsTrue(tree.Equals(expectedTree));
        }
    }
}