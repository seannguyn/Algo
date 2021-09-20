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

        #region Three Largest Number
        /// time: O(n) bc we walk through the array once, and other operations are constant
        /// space: storage is constant, which is just the result array, and not dependent on in input size n
        public static int[] FindThreeLargestNumbers(int[] array)
        {
            int[] results = new int[] { int.MinValue, int.MinValue, int.MinValue };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > results[2])
                {
                    shiftAndUpdate(ref results, array[i], 2);
                }
                else if (array[i] > results[1])
                {
                    shiftAndUpdate(ref results, array[i], 1);
                }
                else if (array[i] > results[0])
                {
                    shiftAndUpdate(ref results, array[i], 0);
                }
            }
            // Write your code here.
            return results;
        }

        public static void shiftAndUpdate(ref int[] array, int number, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    array[i] = number;
                } else
                {
                    array[i] = array[i + 1];
                }
            }
        }
        #endregion

        #region Binary search
        /// time: O(log n)
        /// space: O(1)
        public static int BinarySearch(int[] array, int target)
        {
            int lo = 0;
            int hi = array.Length - 1;
            while (lo <= hi)
            {
                int mi = lo + (hi - lo) / 2;
                if (array[mi] == target) { return mi; }
                else if (array[mi] > target)
                {
                    hi = mi - 1;
                }
                else if (array[mi] < target)
                {
                    lo = mi + 1;
                }
            }
            return -1;
        }
        #endregion

        #region fibonbacci
        public static int GetNthFib(int n)
        {
            if(n <= 2) return n - 1;

            int[] result = new int[] { 0, 1 };
            int counter = 2;

            while (counter < n)
            {
                int nextFib = result[0] + result[1];
                result[0] = result[1];
                result[1] = nextFib;
                counter++;
            }

            return result[1];
        }
        #endregion

        #region Tournament Winner
        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            Dictionary<string, int> teamPoints = new Dictionary<string, int>();
            int currentMaxPoint =int.MinValue;
            string currentMaxTeam ="";

            for(int i = 0; i < results.Count; i++)
            {
                if (results[i] == 1) {
                    assignPoint(teamPoints, competitions[i][0], ref currentMaxPoint, ref currentMaxTeam);
                }
                else if (results[i] == 0) {
                    assignPoint(teamPoints, competitions[i][1], ref currentMaxPoint, ref currentMaxTeam);
                }
            }
            return currentMaxTeam;
        }

        public void assignPoint(Dictionary<string, int> teamPoints, string team, ref int currentMaxPoint, ref string currentMaxTeam)
        {
            if (teamPoints.ContainsKey(team))
            {
                teamPoints[team] += 3;
            } else
            {
                teamPoints.Add(team, 3);
            }

            if (teamPoints[team] > currentMaxPoint)
            {
                currentMaxTeam = team;
            }
        }
        #endregion

        #region remove duplicate from linked list
        // This is an input class. Do not edit.
        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
        {
            if (linkedList == null) return linkedList;

            LinkedList current = linkedList.next;
            LinkedList previous = linkedList;
            LinkedList head = linkedList;

            while (current != null)
            {
                if (previous.value == current.value)
                {
                    current = current.next;
                } else
                {
                    previous.next = current;
                    previous = current;
                    current = current.next;
                }
            }

            if (previous.next != current)
            {
                previous.next = current;
            }
            return head;
        }
        #endregion
    }
}
