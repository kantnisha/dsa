using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
  public static class BinaryProblems
  {
    // Given an integer n, return an array ans of length n + 1 such that
    // for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.
    // Input: n = 2
    // Output: [0,1,1]
    //  Explanation: 2 in binary - > 010
    //  0 --> 0
    //  1 --> 1
    //  2 --> 10
    // Input: n = 5
    // 5 in binary => 000101
    // 0 -> 0 -> 0
    // 1 -> 1 -> 1
    // 2 -> 10 -> 1
    // 3 -> 11 -> 2
    // 4 -> 100 -> 1
    // 5 -> 101 -> 2
    // 0 | 1 = 1, 1 ^ 1=
    public static int[] CountBits(int n)
    {
      int[] result = new int[n+1];
      int offset = 1;

      for(int i = 1; i <= n; i++)
      {
        if(offset*2 == i)
        {
          offset = i;
        }

        result[i] = 1 + result[i - offset];
      }

      return result;
    }

    // Write a function that takes the binary representation of an unsigned integer and returns the number of '1' bits it has
    // (also known as the Hamming weight).
    public static int HammingWeight(uint n)
    {
      int count = 0;
      while(n!=0)
      {
        if(n%2 == 1)
        {
          count++;
        }

        n = n >> 1;
      }

      return count;
    }

    // Given two integers a and b, return the sum of the two integers without using the operators + and -.
    public static int AddTwoNumbersWithoutUsingPlusOrMinus(int a, int b)
    {
      while(b != 0)
      {
        var temp = a & b << 1;
        a = a ^ b;
        b= temp;
      }

      return a;
    }
  }
}
