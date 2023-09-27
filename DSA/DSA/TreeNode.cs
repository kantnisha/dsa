namespace DSA.Trees
{
  public class TreeNode
  {
    public TreeNode(
      int value,
      TreeNode left = null,
      TreeNode right = null)
    {
      Value = value;
      Left = left;
      Right = right;
    }

    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
  }
}