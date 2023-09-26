namespace DSA.Tests
{
  [TestFixture]
  public class DataStructureTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestQueue()
    {
      var queue = new NQueue<int>();

      queue.Enque(1);
      queue.Enque(2);
      queue.Enque(3);
      queue.Enque(4);

      Assert.That(queue.Count, Is.EqualTo(4));

      var result = queue.Deque();

      
      Assert.AreEqual(result, 1);
      Assert.AreEqual(queue.Count, 3);

      queue.Deque();
      queue.Deque();
      queue.Deque();

      Assert.AreEqual(queue.Count, 0);

      Assert.Throws<InvalidOperationException>(() => queue.Deque());
    }
  }
}