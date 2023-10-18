using System.Collections.Generic;

namespace DSA.Trees
{
  public static class GraphProblems
  {
    // There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
    // You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first
    // if you want to take course ai.
    // For example, the pair[0, 1], indicates that to take course 0 you have to first take course 1.
    // Return true if you can finish all courses.Otherwise, return false.
    // Example: Input: numCourses = 2, prerequisites = [[1,0]]
    // Output: true
    public static bool CanFinishCourse(int numCourses, int[][] prerequisites)
    {
      var preRequisiteMap = new Dictionary<int, List<int>>();

      for(int i = 0;i<numCourses;i++)
      {
        preRequisiteMap.Add(i, new List<int>());
      }

      for (int kv =0; kv < prerequisites.Length; kv++)
      {
        if (preRequisiteMap.ContainsKey(prerequisites[kv][0]))
        {
          preRequisiteMap[prerequisites[kv][0]].Add(prerequisites[kv][1]);
        }
        else
        {
          preRequisiteMap.Add(prerequisites[kv][0], new List<int>() { prerequisites[kv][1] });
        }
      }

      HashSet<int> visited = new HashSet<int>();
      bool Dfs(int course)
      {
        if (preRequisiteMap.ContainsKey(course) && !preRequisiteMap[course].Any())
        {
          return true;
        }

        if(visited.Contains(course))
        {
          return false;
        }

        visited.Add(course);

        if(preRequisiteMap.TryGetValue(course, out var preqs))
        {
          foreach (var c in preqs)
          {
            if (!Dfs(c))
            {
              return false;
            }
          }
        }

        visited.Remove(course);
        preRequisiteMap[course] = new List<int>();

        return true;
      }

      for(int i=0; i < numCourses; i++)
      {
        if(!Dfs(i))
        {
          return false;
        }
      }

      return true;
    }

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
