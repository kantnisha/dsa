namespace DSA
{
  public class NStack<T>
  {
    private StackNode<T> top;

    public void Push(T val)
    {
      var node = new StackNode<T>() { Value = val };

      node.Next = top;
      top = node;
    }

    public T Pop()
    {
      if(top == null)
      {
        throw new InvalidOperationException("Stack is empty");
      }

      var node = top;
      top = top.Next;

      return node.Value;
    }

    public T Peek()
    {
      if (top == null)
      {
        throw new InvalidOperationException("Stack is empty");
      }

      var node = top;

      return node.Value;
    }

    public bool IsEmpty()
    {
      return top == null;
    }
  }

  public class StackNode<T>
  {
    public T Value { get; set; }
    public StackNode<T> Next { get; set; }
  }
}
