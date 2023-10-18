namespace DSA.Tests
{
  [TestFixture]
  public class SortingTests
  {
    [Test]
    public void TestMatrixSearch()
    {
      var matrix = new int[][]
      {
      new int[] { 1, 4, 7, 11, 15 },
      new int[] {2, 5, 8, 12, 19 },
      new int[]{3, 6, 9, 16, 22 },
      new int[]{10, 13, 14, 17, 24 },
      new int[]{18, 21, 23, 26, 30 }
      };

      var result = Sorting.SearchDoublySortedMatrix(matrix, 5);

      Assert.IsTrue(result);
    }

    [Test]
    public void TestMerge()
    {
      int[] a1 = new int[] { 1, 2, 3, 0, 0, 0 };
      int[] a2 = new int[] { 2, 5, 6 };

      Sorting.MergeSortedArrays(a1, 3, a2, 3);
    }
  }
}
