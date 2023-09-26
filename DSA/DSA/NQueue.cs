namespace DSA
{
  public class NQueue<T> : INQueue<T>
  {
    private int counter;
    private Data<T> head;
    private Data<T> tail;
    public int Count => counter;

    // T->1 2 3 4 5<-H
    public T Deque()
    {
      if(tail == null)
      {
        throw new InvalidOperationException("Queue is empty");
      }

      var temp = tail;
      tail = tail.Next;
      counter--;

      return temp.Value;
    }

    // T->1 2 3 4 5<-H
    public void Enque(T item)
    {
      var temp = head;

      if(temp == null)
      {
        head = new Data<T>
        {
          Value = item,
          Previous = temp
        };

        tail = head;
      }
      else
      {
        head.Next = new Data<T>
        {
          Value = item,
          Previous = temp
        };

        head = head.Next;
      }

      counter++;
    }
  }

  public class Data<T>
  {
    public T Value { get; set; }
    public Data<T> Next { get; set; }
    public Data<T> Previous { get; set; }
  }
  public interface INQueue<T>
  {
    public int Count { get; }
    void Enque(T item);
    T Deque();
  }
}
