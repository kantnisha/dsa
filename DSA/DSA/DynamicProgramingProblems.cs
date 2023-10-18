namespace DSA
{
  public static class DynamicProgramingProblems
  {
    // Given an integer array nums, return the length of the longest strictly increasing subsequence.
    // Input: nums = [10,9,2,5,3,7,101,18]
    // Output: 4
    // Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
    public static int LengthOfLongestIncreasingSubsequence(int[] nums)
    {
      int[] allsequences = new int[nums.Length];

      for(int i = 0; i < nums.Length; i++)
      {
        allsequences[i] = 1;
      }

      for(int i = nums.Length-1;  i >= 0; i--)
      {
        for (int j = i + 1; j < nums.Length; j++)
        {
          if (nums[i] < nums[j])
          {
            allsequences[i] = Math.Max(allsequences[i], 1 + allsequences[j]);
          }
        }
      }

      return allsequences.Max();
    }

    // Given an integer array nums, find the subarray with the largest sum, and return its sum.
    // Example 1: Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    // Output: 6
    // Explanation: The subarray [4,-1,2,1] has the largest sum 6.
    public static int MaxSubArray(int[] nums)
    {
      int currSum = 0;
      int maxSum = nums[0];

      foreach (var num in nums)
      {
        if (currSum < 0)
        {
          currSum = 0;
        }

        currSum += num;

        maxSum = Math.Max(maxSum, currSum);
      }

      return maxSum;
    }

    // You are given an array prices where prices[i] is the price of a given stock on the ith day.
    // You want to maximize your profit by choosing a single day to buy one stock and choosing a different day
    // in the future to sell that stock.
    // Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
    // Input: prices = [7,1,5,3,6,4]
    // Output: 5
    // [7,6,4,3,1]
    // [2,1,2,1,0,1,2], 2
    //  [1,4,2], 3
    // [3,2,6,5,0,3]
    public static int MaxProfit(int[] prices)
    {
      int l = 0;
      int r = 1;
      int maxProfit = 0;

      while (r < prices.Length)
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

      //int sellMax = prices[prices.Length - 1];
      //int buyMin = prices[0];
      //int l = 0;
      //int r = prices.Length - 1;

      //while(r > l)
      //{
      //  if (prices[r] >= sellMax)
      //  {
      //    sellMax = prices[r];
      //    r--;
      //  }
      //  else
      //  {
      //    r--;
      //  }

      //  if (prices[l] <= buyMin)
      //  {
      //    buyMin = prices[l];
      //    l++;
      //  }
      //  else
      //  {
      //    l++;
      //  }
      //}

      //return sellMax - buyMin < 0 ? 0: sellMax - buyMin;
      // Brutforce
      //int maxProfit = 0;

      //for(int i = 0; i < prices.Length -1; i++)
      //{
      //  for(int j = i+1;  j < prices.Length; j++)
      //  {
      //    maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
      //  }
      //}

      //return maxProfit;
    }
  }
}
