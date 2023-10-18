using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
  internal static class ArrayProblems
  {
    /// <summary>
    /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
    //You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
    //Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
    /// </summary>
    public static int MaxProfit(int[] prices)
    {
      int maxProfit = 0;

      int l = 0;
      int r = 1;

      while(r < prices.Length)
      {
        if (prices[r] > prices[l])
        {
          maxProfit = Math.Max(maxProfit, prices[r] - prices[l]);
        }
        else
        {
          l = r;
        }

        r++;
      }

      return maxProfit;
    }

    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target
    /// </summary>
    public static int[] GetIndices(int[] array, int target)
    {
      int[] indices = new int[2];
      var map = new Dictionary<int, int>();

      for (int i = 0; i < array.Length; i++)
      {
        int diff = target - array[i];
        if (map.TryGetValue(diff, out int val))
        {
          indices[0] = val;
          indices[1] = i;

          return indices;
        }

        map.TryAdd(array[i], i);
      }

      return indices;
    }
  }
}
