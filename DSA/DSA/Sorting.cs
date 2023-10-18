using System.Collections.Generic;
using System.ComponentModel;

namespace DSA
{
  public static class Sorting
  {
    // Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix.
    // This matrix has the following properties:
    //    Integers in each row are sorted in ascending from left to right.
    //    Integers in each column are sorted in ascending from top to bottom.
    // Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
    //  Output: true
    public static bool SearchDoublySortedMatrix(int[][] matrix, int target)
    {
      int row = matrix.Length;
      int col = 0;

      while(col < matrix[0].Length && row >= 0)
      {
        if(target > matrix[row][col])
        {
          col++;
        }
        else if(target < matrix[row][col]) 
        {
          row--;
        }
        else
        {
          return true;
        }
      }

      return false; 
    }

    // You are given an m x n integer matrix matrix with the following two properties:
    // Each row is sorted in non-decreasing order.
    // The first integer of each row is greater than the last integer of the previous row.
    // Given an integer target, return true if target is in matrix or false otherwise.
    // You must write a solution in O(log(m* n)) time complexity.
    // Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    // Output: true
    public static bool SearchMatrix(int[][] matrix, int target)
    {
      int rows = matrix.Length;
      int cols = matrix[0].Length;

      int top = 0;
      int bottom = rows - 1;

      while (top <= bottom)
      {
        int mid = (top + bottom) / 2;
        if (target > matrix[mid][cols - 1])
        {
          top = mid + 1;
        }
        else if (target < matrix[mid][0])
        {
          bottom = mid - 1;
        }
        else
        {
          break;
        }
      }

      if (!(top <= bottom))
      {
        return false;
      }

      int row = (top + bottom) / 2;

      int l = 0;
      int r = cols - 1;

      while (l <= r)
      {
        int m = (l + r) / 2;

        if (target > matrix[row][m])
        {
          l = m + 1;
        }
        else if (target < matrix[row][m])
        {
          r = m - 1;
        }
        else
        {
          return true;
        }
      }

      return false;
    }

    public static int FindMinInRotatedSortedArrayWithDuplicates(int[] nums)
    {
      int l = 0;
      int r = nums.Length - 1;

      while (l < r)
      {
        int m = (l + r) / 2;

        if (nums[m] > nums[r])
        {
          l = m + 1;
        }
        else if (nums[m] < nums[r])
        {
          r = m;
        }
        else
        {
          r--;
        }
      }

      return nums[l];
    }

    // Given the sorted rotated array nums of unique elements, return the minimum element of this array.
    // You must write an algorithm that runs in O(log n) time.
    // Example: Input: nums = [3,4,5,1,2]
    // Output: 1
    // Explanation: The original array was[1, 2, 3, 4, 5] rotated 3 times.
    public static int FindMinInRotatedSortedArray(int[] nums)
    {
      int result = nums[0];

      int l = 0;
      int r = nums.Length - 1;

      while (l <= r)
      {
        if (nums[l] < nums[r])
        {
          result = Math.Min(result, nums[l]);
          break;
        }

        int m = (l + r) / 2;

        result = Math.Min(result, nums[m]);

        if (nums[m] >= nums[l])
        {
          l = m + 1;
        }
        else
        {
          r = m - 1;
        }
      }

      return result;

      //int l = 0;
      //int r = nums.Length - 1;

      //while (l <= r)
      //{
      //  int m = (l + r) / 2;

      //  if (nums[m] < nums[m - 1] && nums[m + 1] > nums[m])
      //  {
      //    return nums[m];
      //  }
      //  else if(nums[m] > nums[m - 1] && nums[m + 1] > nums[m])
      //  {
      //    l = m + 1;
      //  }

      //  else
      //  {
      //    r = m - 1;
      //  }
      //}

      //return nums[0];
    }

    // Given an array nums with n objects colored red, white, or blue, sort them in-place
    // so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
    // We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
    // You must solve this problem without using the library's sort function.
    // Example: Input: nums = [2,0,2,1,1,0]
    // Output: [0,0,1,1,2,2]
    public static void SortColors(int[] nums)
    {
      int l = 0;
      int r = nums.Length - 1;
      int m = 0;

      while (m < r)
      {
        if (nums[m] == 2)
        {
          var temp = nums[m];
          nums[m] = nums[r];
          nums[r] = temp;
          r--;
        }
        else if (nums[m] == 0)
        {
          var temp = nums[m];
          nums[m] = nums[l];
          nums[l] = temp;
          l++;
          m++;
        }
        else
        {
          m++;
        }
      }

      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] == 0)
        {
          var temp = nums[l];
          nums[l] = 0;
          nums[i] = temp;
          l++;
        }
        else if (nums[i] == 2)
        {
          var temp = nums[r];
          nums[r] = 2;
          nums[i] = temp;
          r--;
        }
      }
    }

    // Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique
    // element appears only once. The relative order of the elements should be kept the same.
    // Then return the number of unique elements in nums.
    // Input: nums = [0,0,1,1,1,2,2,3,3,4]
    // Output: 5, nums = [0,1,2,3,4, _, _, _, _, _]
    public static int RemoveDuplicatesFromSortedArray(int[] nums)
    {
      int count = 0;
      HashSet<int> visited = new();
      int right = 0;

      for (int i = 0; i < nums.Length; i++)
      {
        if (visited.Contains(nums[i]))
        {
          right++;
        }
        else
        {
          visited.Add(nums[i]);
          nums[count] = nums[i];
          count++;
        }
      }

      return count;
    }

    //You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n,
    //representing the number of elements in nums1 and nums2 respectively.
    // Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    // The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
    // To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged,
    // and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
    // Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    // Output: [1,2,2,3,5,6]
    public static void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
    {
      int n1Length = nums1.Length;

      while (n > 0 && m > 0)
      {
        if (nums1[m - 1] >= nums2[n - 1])
        {
          nums1[n1Length - 1] = nums1[m - 1];
          nums1[m - 1] = 0;
          m--;
        }
        else
        {
          nums1[n1Length - 1] = nums2[n - 1];
          n--;
        }

        n1Length--;
      }

      while (n > 0)
      {
        nums1[n1Length - 1] = nums2[n - 1];
        n--;
        n1Length--;
      }

      #region Brutforce
      //for(int i=0; i< nums2.Length; i++) { 
      //  for(int j=0; j< nums1.Length; j++)
      //  {
      //    if (nums2[i] < nums1[j])
      //    {
      //      var temp = nums2[i];
      //      for(int k=j; k< nums1.Length; k++)
      //      {
      //        var temp2 = nums1[k];
      //        nums1[k] = temp;
      //        temp = temp2;
      //      }
      //    }
      //    else
      //    {
      //      var temp = nums2[i];

      //      for(int k = j+1; k<= m + i; k++)
      //      {
      //        if(nums2[i] > nums1[k] && k <= m + i)
      //        {
      //          continue;
      //        }

      //        var temp2 = nums1[k];
      //        nums1[k] = temp;
      //        temp = temp2;
      //      }
      //    }
      //  }
      //} 
      #endregion
    }
  }
}
