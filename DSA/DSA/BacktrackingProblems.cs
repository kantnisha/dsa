namespace DSA
{
  public static class BacktrackingProblems
  {
    // Given a string containing digits from 2-9 inclusive, return all possible letter combinations
    // that the number could represent.Return the answer in any order.
    // A mapping of digits to letters (just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
    // Example: Input: "23", Output: ad,ae,af,bd,be,bf,...
    public static IList<string> LetterCombinations(string digits)
    {
      var digitToChar = new Dictionary<string, string>
      {
        {"2", "abc" },
        {"3", "def" },
        {"4", "ghi" },
        {"5", "jkl" },
        {"6", "mno" },
        {"7", "pqrs" },
        {"8", "tuv" },
        {"9", "wxyz" },
      };

      var combinations = new List<string>();

      void Backtrack(int i, string currStr)
      {
        if(currStr.Length == digits.Length)
        {
          combinations.Add(currStr);

          return;
        }

        foreach (var c in digitToChar[digits[i].ToString()])
        {
          Backtrack(i + 1, currStr + c);
        }
      }

      if (!string.IsNullOrWhiteSpace(digits))
      {
        Backtrack(0, "");
      }

      return combinations;
    }
  }
}
