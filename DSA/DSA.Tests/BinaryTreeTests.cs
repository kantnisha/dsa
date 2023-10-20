using DSA.Trees;

namespace DSA.Tests
{
  [TestFixture]
  internal class BinaryTreeTests
  {
    [Test]
    public void BuildBinaryTreeFromPreAndInOrderTest()
    {
      int[] pre = new int[] { 3, 9, 20, 15, 7 };
      int[] inorder = new int[] { 9, 3, 15, 20, 7 };

      var result = BinaryTree.BuildTreeFromGivenInorderAndPreOrder(pre, inorder);
    }
  }
}
