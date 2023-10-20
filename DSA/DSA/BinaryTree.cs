namespace DSA.Trees
{
  public static class BinaryTree
  {
    public static void RunAlgo()
    {
      var root = new BinaryTreeNode<int>(1);

      var l1 = new BinaryTreeNode<int>(2);
      var r1 = new BinaryTreeNode<int>(3);

      var l2 = new BinaryTreeNode<int>(4);
      var r2 = new BinaryTreeNode<int>(5);

      var l3 = new BinaryTreeNode<int>(6);
      var r3 = new BinaryTreeNode<int>(7);


      root.Left = l1;
      root.Right = r1;

      l1.Left = l2;
      l1.Right = r2;

      r1.Left = l3;
      r1.Right = r3;

      //PreOrderTraversalRecurive<int>(root);
      InOrderTraversalRecursive(root);

      Console.ReadLine();
    }

    // Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree
    // and inorder is the inorder traversal of the same tree, construct and return the binary tree.
    // Ex: pre: [3,9,20,15,7]
    // in: [9,3,15,20,7]

    public static BinaryTreeNode<int> BuildTreeFromGivenInorderAndPreOrder(int[] preorder, int[] inorder)
    {
      if(preorder.Length != inorder.Length || preorder.Length == 0 || inorder.Length == 0)
      {
        return null;
      }

      var root = new BinaryTreeNode<int>(preorder[0]);

      int i = 0;
      while(inorder[i] != preorder[0])
      {
        i++;
      }

      root.Left = BuildTreeFromGivenInorderAndPreOrder(preorder[1..(i+1)], inorder[0..i]);
      root.Right = BuildTreeFromGivenInorderAndPreOrder(preorder[(i+1)..inorder.Length], inorder[(i + 1)..inorder.Length]);

      return root;
    }

    public static int MaxDepthOfBinaryTree_BFS(TreeNode root)
    {
      if (root == null)
      {
        return 0;
      }

      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      int level = 1;

      while (queue.Count > 0)
      {
        var node = queue.Dequeue();

        if(node.Left != null)
        {
          queue.Enqueue(node.Left);
        }

        if(node.Right != null)
        {
          queue.Enqueue(node.Right);
        }

        level++;
      }

      return level;
    }

    public static int MaxDepthOfBinaryTree_DFS(TreeNode root)
    {
      if (root == null)
      {
        return 0;
      }

      var stack = new Stack<(TreeNode, int)>();
      stack.Push((root, 1));
      int maxDepth = 1;

      while (stack.Count > 0)
      {
        var (node, depth) = stack.Pop();

        if (node != null)
        {
          maxDepth = Math.Max(maxDepth, depth);
          stack.Push((node.Left, depth + 1));
          stack.Push((node.Right, depth + 1));
        }
      }

      return maxDepth;
    }
    //Binary Tree Level Order Traversal

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
      if (p.Value > root.Value && q.Value > root.Value)
      {
        return LowestCommonAncestor(root.Right, p, q);
      }
      else if (p.Value < root.Value && q.Value < root.Value)
      {
        return LowestCommonAncestor(root.Left, p, q);
      }
      else
      {
        return root;
      }
    }

    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
      var result = new List<IList<int>>();

      if (root == null) return result;

      Queue<TreeNode> queue = new Queue<TreeNode>();

      queue.Enqueue(root);

      while (queue.Count > 0)
      {
        var levelSize = queue.Count;
        var currentLevel = new List<int>();

        for (int i = 0; i < levelSize; i++)
        {
          var node = queue.Dequeue();

          currentLevel.Add(node.Value);

          if (node.Left != null)
          {
            queue.Enqueue(node.Left);
          }

          if (node.Right != null)
          {
            queue.Enqueue(node.Right);
          }
        }

        result.Add(currentLevel);
      }

      return result;
    }

    public static bool IsValidBST(TreeNode root)
    {
      return IsValid(root, int.MinValue, int.MaxValue);
    }

    private static bool IsValid(TreeNode node, int left, int right)
    {
      if (node == null) return true;

      if (!(left < node.Value && right > node.Value))
      {
        return false;
      }

      return IsValid(node.Left, left, node.Value) && IsValid(node.Right, node.Value, right);
    }

    private static int MaxDepth<T>(BinaryTreeNode<T> root)
    {
      if (root == null)
      {
        return 0;
      }

      return 1 + Math.Max(MaxDepth<T>(root.Left), MaxDepth<T>(root.Right));
    }

    private static BinaryTreeNode<T> InvertTree<T>(BinaryTreeNode<T> root)
    {
      if (root == null)
      {
        return null;
      }

      var temp = root.Left;
      root.Left = root.Right;
      root.Right = temp;

      InvertTree<T>(root.Left);
      InvertTree<T>(root.Right);

      return root;
    }

    #region Traveral
    private static void InOrderTraversal<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      InOrderTraversal<T>(rootNode.Left);
      Console.WriteLine(rootNode.Value);
      InOrderTraversal<T>(rootNode.Right);
    }

    private static void PreOrderTraversal<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      Console.WriteLine(rootNode.Value);
      PreOrderTraversal<T>(rootNode.Left);
      PreOrderTraversal<T>(rootNode.Right);
    }

    private static void PostOrderTraversal<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      PostOrderTraversal<T>(rootNode.Left);
      PostOrderTraversal<T>(rootNode.Right);

      Console.WriteLine(rootNode.Value);
    }

    #endregion

    #region TraversalRecursive
    private static void InOrderTraversalRecursive<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      InOrderTraversal<T>(rootNode.Left);
      Console.WriteLine(rootNode.Value);
      InOrderTraversal<T>(rootNode.Right);
    }

    private static void PreOrderTraversalRecurive<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      Console.WriteLine(rootNode.Value);
      PreOrderTraversal<T>(rootNode.Left);
      PreOrderTraversal<T>(rootNode.Right);
    }

    private static void PostOrderTraversalRecursive<T>(BinaryTreeNode<T> rootNode)
    {
      if (rootNode == null)
      {
        return;
      }

      PostOrderTraversal<T>(rootNode.Left);
      PostOrderTraversal<T>(rootNode.Right);

      Console.WriteLine(rootNode.Value);
    }
    #endregion
  }
}
