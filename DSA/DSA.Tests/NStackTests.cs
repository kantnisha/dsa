namespace DSA.Tests
{
  [TestFixture]
  internal class NStackTests
  {
    [Test]
    public void TestStack()
    {
      var stack  = new NStack<int>();

      Assert.Throws<InvalidOperationException>(() => stack.Pop());
      Assert.Throws<InvalidOperationException>(() => stack.Peek());

      stack.Push(1);
      stack.Push(2);
      stack.Push(3);
      stack.Push(4);

      var res1 = stack.Pop();
      var res2 = stack.Pop();

      Assert.AreEqual(res1, 4);
      Assert.AreEqual(res2, 3);

      var res3 = stack.Peek();
      var res4 = stack.Pop();

      Assert.AreEqual(res3, res4);
      Assert.AreEqual(res4, 2);
      Assert.AreEqual(res3, 2);

      stack.Pop();

      Assert.Throws<InvalidOperationException>( () => stack.Pop());
    }

    [Test]
    public void TestSortedStack()
    {
      var stack = new SortedStack();

      Assert.Throws<InvalidOperationException>(() => stack.Pop());
      Assert.Throws<InvalidOperationException>(() => stack.Peek());

      stack.Push(1);
      stack.Push(2);
      stack.Push(3);
      stack.Push(4);

      var res1 = stack.Pop();
      var res2 = stack.Pop();

      Assert.AreEqual(res1, 1);
      Assert.AreEqual(res2, 2);

      var res3 = stack.Peek();
      var res4 = stack.Pop();

      Assert.AreEqual(res3, res4);
      Assert.AreEqual(res4, 3);
      Assert.AreEqual(res3, 3);

      stack.Pop();

      Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
  }
}
