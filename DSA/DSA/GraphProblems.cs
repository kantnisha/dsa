using System.Collections.Generic;

namespace DSA.Trees
{
  public static class GraphProblems
  {
    public static Node CloneGraph(Node node)
    {
      if (node == null)
      {
        return null;
      }

      Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

      return Dfs(node, visited);
    }

    private static Node Dfs(Node node, Dictionary<Node, Node> visited)
    {
      if (visited.ContainsKey(node))
      {
        return visited[node];
      }

      var copy = new Node { val = node.val };
      visited.Add(node, copy);

      foreach (var neighbor in node.neighbors)
      {
        copy.neighbors.Add(Dfs(neighbor, visited));
      }

      return copy;
    }

    public class Node
    {
      public int val;
      public IList<Node> neighbors;

      public Node()
      {
        val = 0;
        neighbors = new List<Node>();
      }

      public Node(int _val)
      {
        val = _val;
        neighbors = new List<Node>();
      }

      public Node(int _val, List<Node> _neighbors)
      {
        val = _val;
        neighbors = _neighbors;
      }
    }
  }
}
