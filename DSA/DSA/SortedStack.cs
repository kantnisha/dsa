namespace DSA
{
  // Smallest number is always on top
  public class SortedStack
  {
    private StackNode<int> top;
    private Stack<int> supportingStack = new Stack<int>();

    public void Push(int val)
    {
      if (top == null)
      {
        top = new StackNode<int>() { Value = val };
      }
      else
      {
        while(top != null && top.Value <= val)
        {
          var poppedVal = top;
          top = top.Next;
          supportingStack.Push(poppedVal.Value);
        }

        if (top == null)
        {
          top = new StackNode<int> { Value = val };
        }
        else
        {
          var temp = top.Next;
          top.Next = new StackNode<int> { Value = val, Next = temp.Next };
        }

        while(supportingStack.Count > 0)
        {
          var p = supportingStack.Pop();
          var tmp = top;
          top = new StackNode<int> {Value = p, Next = tmp };
        }
      }
    }

    public int Pop()
    {
      if(top != null)
      {
        var tmp = top;
        top = top.Next;

        return tmp.Value;
      }

      throw new InvalidOperationException("Stack is empty");
    }

    public int Peek()
    {
      if (top != null)
      {
        return top.Value;
      }

      throw new InvalidOperationException("Stack is empty");
    }

    public bool IsEmpty()
    {
      return top == null;
    }
  }
}
