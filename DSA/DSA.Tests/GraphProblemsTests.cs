using DSA.Trees;

namespace DSA.Tests
{
  [TestFixture]
  public class GraphProblemsTests
  {
    [Test]
    public void TestCanFinishCourse()
    {
      var prerequisites = new int[][]
      {
        new int[] { 1, 0 }
      };

      var result = GraphProblems.CanFinishCourse(2, prerequisites);
    }
  }
}
