using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode;

/// <summary>
/// 128. Longest Consecutive Sequence
/// </summary>
internal static class LongestConsecutiveQ
{
    public static int LongestConsecutive(int[] nums)
    {
        Array.Sort(nums);

        var left = 0;
        var right = 0;
        var max = 0;
        var len = 0;

        while (right < nums.Length)
        {
            while (right + 1 < nums.Length && nums[right] + 2 > nums[right + 1]) 
            {
                right++;
            }

            len = nums[right] - nums[left] + 1;

            if (len > max)
            {
                max = len;
            }

            right++;
            left = right;
        }

        return max;
    }

    public static void Client()
    {
        int[] nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];

        var len = LongestConsecutive(nums);
        Console.WriteLine(len);
    }
}
