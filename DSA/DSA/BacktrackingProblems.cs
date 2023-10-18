using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSA
{
  public static class BacktrackingProblems
  {
    // Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:
    // '.' Matches any single character.​​​​
    // '*' Matches zero or more of the preceding element.
    // The matching should cover the entire input string (not partial).
    // Example: s = "ab", p = ".*"
    // Output: True
    // Ex2: s = "aa", p = "a"
    // Output: false
    // Example: s = "aab" p="c*a*b"
    // Output: true
    public static bool RegularExpressMatching(string s, string p)
    {
      bool Dfs(int i, int j)
      {
        if(i >= s.Length && j >= p.Length)
        {
          return true;
        }

        if(j >= p.Length)
        {
          return false;
        }

        var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

        if(j+1 < p.Length && p[j+1] == '*')
        {
          return (match && Dfs(i + 1, j)) || Dfs(i, j + 2);
        }

        if(match)
        {
          return Dfs(i+1, j+1);
        }

        return false;
      }

      return Dfs(0, 0);
    }

    // Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:
    // '?' Matches any single character.
    // '*' Matches any sequence of characters (including the empty sequence).
    // The matching should cover the entire input string (not partial).
    // Example: input:s= "aa", p = "a"
    // Output: false
    public static bool WildcardMatching(string s, string p)
    {
      // abcdefhi , cd?f*

      bool Dfs(int i, int j)
      {
        if (i >= s.Length && j >= p.Length)
        {
          return true;
        }

        if (j >= p.Length)
        {
          return false;
        }

        var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

        if (j + 1 < p.Length && p[j + 1] == '*')
        {
          return (match && Dfs(i + 1, j)) || Dfs(i, j + 2);
        }

        if (match)
        {
          return Dfs(i + 1, j + 1);
        }

        return false;
      }

      return Dfs(0, 0);
    }

    // Given an m x n board of characters and a list of strings words, return all words on the board.
    // Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally
    // or vertically neighboring.The same letter cell may not be used more than once in a word.
    public static IList<string> FindWords(char[][] board, string[] words)
    {
      var result = new List<string>();

      foreach (var word in words)
      {
        if (WordSearch(board, word))
        {
          result.Add(word);
        }
      }

      return result;
    }

    // Given an m x n grid of characters board and a string word, return true if word exists in the grid.
    // The word can be constructed from letters of sequentially adjacent cells, where adjacent cells
    // are horizontally or vertically neighboring.The same letter cell may not be used more than once.
    public static bool WordSearch(char[][] board, string word)
    {
      int rowCount = board.Length;
      int columnCount = board[0].Length;

      var path = new HashSet<(int, int)>();

      bool Dfs(int r, int c, int currWordLength)
      {
        if (currWordLength == word.Length)
        {
          return true;
        }

        if (r < 0 || c < 0 || r >= rowCount || c >= columnCount || path.Contains((r, c)) || word[currWordLength] != board[r][c])
        {
          return false;
        }

        path.Add((r, c));

        var res = Dfs(r + 1, c, currWordLength + 1)
          || Dfs(r - 1, c, currWordLength + 1)
          || Dfs(r, c + 1, currWordLength + 1)
          || Dfs(r, c - 1, currWordLength + 1);

        path.Remove((r, c));

        return res;
      }

      for (int i = 0; i < rowCount; i++)
      {
        for (int j = 0; j < columnCount; j++)
        {
          if (Dfs(i, j, 0))
          {
            return true;
          }
        }
      }

      return false;
    }

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
        if (currStr.Length == digits.Length)
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
