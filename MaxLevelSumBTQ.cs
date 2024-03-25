namespace LeetCode;

/// <summary>
/// 1161. Maximum Level Sum of a Binary Tree
/// </summary>
internal class MaxLevelSumBTQ
{
    public static int MaxLevelSum(TreeNode root)
    {
        // optimize for edge case
        if (root.left is null && root.right is null)
        {
            return 1;
        }

        var max = root.val;
        var maxLevel = 0;

        var nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);

        var currentLevel = 0;
        var levelRunningTotal = max;
        var currentLevelLength = 1;
        var nextLevelLength = 0;

        while (nodeQueue.Count > 0)
        {
            currentLevel++;

            // Pull nodes off queue by level adding them to the running total for that level
            while (currentLevelLength > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                currentLevelLength -= 1;

                if (currentNode.left is not null)
                {
                    nodeQueue.Enqueue(currentNode.left);
                    nextLevelLength += 1;
                }

                if (currentNode.right is not null)
                {
                    nodeQueue.Enqueue(currentNode.right);
                    nextLevelLength += 1;
                }

                levelRunningTotal += currentNode.val;
            }

            if (levelRunningTotal > max)
            {
                max = levelRunningTotal;
                maxLevel = currentLevel;
            }

            currentLevelLength = nextLevelLength;
            nextLevelLength = 0;
            levelRunningTotal = 0;
        }

        return maxLevel;
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

    public static void Client()
    {
        //var node5 = new TreeNode(-10);
        var node4 = new TreeNode(0);
        var node3 = new TreeNode(0);
        var node2 = new TreeNode(1);
        var node1 = new TreeNode(-1, node3, node4);
        var root = new TreeNode(-1, node1, node2);

        var maxLevel = MaxLevelSum(root);
        Console.WriteLine(maxLevel);
    }
}
