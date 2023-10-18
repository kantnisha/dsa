namespace DSA.Trees
{
  public class BinaryTreeNode<T>
  {
    public BinaryTreeNode(
      T value,
      BinaryTreeNode<T> left = null,
      BinaryTreeNode<T> right = null)
    {
      Value = value;
      Left = left;
      Right = right;
    }

    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
  }
}