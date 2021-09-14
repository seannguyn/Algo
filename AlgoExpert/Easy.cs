using System;
using System.Collections.Generic;

namespace AlgoExpert
{
    public class Easy
    {
        public Easy()
        {
        }

        #region Find Closest Value In Bst
        //// iterative
        //public static int FindClosestValueInBst(BST tree, int target)
        //{
        //    if (tree == null) { return -1; }

        //    BST currentNode = tree;
        //    BST minNode = tree;

        //    while (currentNode != null)
        //    {
        //        if (Math.Abs(target - currentNode.value) < Math.Abs(target - minNode.value))
        //        {
        //            minNode = currentNode;
        //        }

        //        if (target == currentNode.value) { break; }
        //        else if (target > currentNode.value)
        //        {
        //            currentNode = currentNode.right;
        //        }
        //        else if (target < currentNode.value)
        //        {
        //            currentNode = currentNode.left;
        //        }
        //    }

        //    return minNode.value;
        //}

        //// recursion
        //// Time worst: O(n) when tree is skewed and shaped like a linked list
        //// Time average: O(log n) or O(d) where d is the depth
        //// Space average and worst: O log n or O (d) where d is the depth. Bc we are adding frame to the call stack
        //public static int FindClosestValueInBst(BST tree, int target)
        //{
        //    BST minNode = FindClosestValueInBst(tree, tree, target);
        //    return minNode.value;
        //}

        //public static BST FindClosestValueInBst(BST currentNode, BST minNode, int target)
        //{
        //    if (currentNode == null) return minNode;

        //    if (Math.Abs(target - currentNode.value) < Math.Abs(target - minNode.value))
        //    {
        //        minNode = currentNode;
        //    }

        //    if (target == currentNode.value) { return minNode; }
        //    else if (target > currentNode.value)
        //    {
        //        minNode = FindClosestValueInBst(currentNode.right, minNode, target);
        //    }
        //    else if (target < currentNode.value)
        //    {
        //        minNode = FindClosestValueInBst(currentNode.left, minNode, target);
        //    }
        //    return minNode;
        //}

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
        #endregion

        #region Node Depth
        //// iterative
        /// space: O(n/2) in worst, average, best. At every iteration, the number of node in the stack is the number of that level. and number of nodes at that level is < total number of nodes
        /// time O(n) in worst, average, best
        //public static int NodeDepths(BinaryTree root)
        //{
        //    if (root == null) { return 0; }

        //    Level rootLevel = new Level(0, root);

        //    Stack<Level> stackLevel = new Stack<Level>();
        //    stackLevel.Push(rootLevel);

        //    int levelSum = 0;

        //    while(stackLevel.Count > 0)
        //    {
        //        Level currentLevel = stackLevel.Pop();
        //        levelSum += currentLevel.value;

        //        if (currentLevel.node.left != null) {
        //            Level leftNextLevel = new Level(currentLevel.value + 1, currentLevel.node.left);
        //            stackLevel.Push(leftNextLevel);
        //        }
        //        if (currentLevel.node.right != null) {
        //            Level rightNextLevel = new Level(currentLevel.value + 1, currentLevel.node.right);
        //            stackLevel.Push(rightNextLevel);
        //        }
        //    }

        //    return levelSum;
        //}

        //public class Level
        //{
        //    public int value;
        //    public BinaryTree node;
        //    public Level(int value, BinaryTree node)
        //    {
        //        this.value = value;
        //        this.node = node;
        //    }
        //}

        //// recursion
        ///
        public static int NodeDepths(BinaryTree root)
        {
            int depth = NodeDepths(root, 0);
            return depth;
        }

        public static int NodeDepths(BinaryTree node, int depth)
        {
            if (node == null) return 0;
            return depth + NodeDepths(node.left, depth + 1) + NodeDepths(node.right, depth + 1);
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public bool visited;

            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }
        #endregion

        #region Product Sum
        public static int ProductSum(List<object> array)
        {
            int sum = ProductSum(array, 1);
            return sum;
        }

        public static int ProductSum(List<object> array, int level)
        {
            int sum = 0;
            foreach(object element in array)
            {
                if (element is IList<object>)
                {
                    List<object> innerArray = (List<object>) element;
                    sum += (level + 1) * ProductSum(innerArray, level + 1);
                }
                else
                {
                    int value = (int) element;
                    sum += value;
                }
            }
            return sum;
        }
        #endregion

        #region Nth Fib
        public static int GetNthFib(int n)
        {
            // Write your code here.
            return -1;
        }
        #endregion

        #region Branch Sums
        //// recursion
        /// time complexity is O(n), since you traverse through all the nodes in the tree
        /// space complexity is the combination of the call stack and list of sum
        //public static List<int> BranchSums(BinaryTree root)
        //{
        //    List<int> sumList = new List<int>();
        //    BranchSums(root, 0, sumList);
        //    return sumList;
        //}

        //public static void BranchSums(BinaryTree node, int currentSum, List<int> sumList)
        //{
        //    currentSum += node.value;

        //    if (node.left == null && node.right == null)
        //    {
        //        sumList.Add(currentSum);
        //    }

        //    if (node.left != null)
        //    {
        //        BranchSums(node.left, currentSum, sumList);
        //    }
        //    if (node.right != null)
        //    {
        //        BranchSums(node.right, currentSum, sumList);
        //    }
        //}

        ////iterative
        public static List<int> BranchSums(BinaryTree root)
        {
            Stack<BinaryTree> nodeStack = new Stack<BinaryTree>();
            nodeStack.Push(root);

            Stack<BinaryTree> currentPath = new Stack<BinaryTree>();
            List<int> sumList = new List<int>();
            int currentSum = 0;
            while(nodeStack.Count > 0)
            {
                BinaryTree node = nodeStack.Peek();
                if (node.visited)
                {
                    nodeStack.Pop();
                    currentPath.Pop();
                    currentSum -= node.value;
                    continue;
                }

                currentSum += node.value;
                currentPath.Push(node);
                if (node.left == null && node.right == null)
                {
                    sumList.Add(currentSum);
                }

                if (node.left != null)
                {
                    nodeStack.Push(node.left);
                }

                if (node.right != null)
                {
                    nodeStack.Push(node.right);
                }
                node.visited = true;
            }

            return sumList;
        }
        #endregion
    }
}
