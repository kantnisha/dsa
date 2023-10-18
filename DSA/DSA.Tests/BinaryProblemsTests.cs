using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
  [TestFixture]
  public class BinaryProblemsTests
  {
    [TestCase(1,2,3)]
    public void TestAddNumbers(int a, int b, int result)
    {
      var _result = BinaryProblems.AddTwoNumbersWithoutUsingPlusOrMinus(a, b);

      Assert.AreEqual(_result, result);
    }

    [Test]
    public void TestHammingWeight()
    {
      var result = BinaryProblems.HammingWeight(00000000000000000000000000001011);
    }
  }
}
