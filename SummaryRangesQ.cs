namespace LeetCode;
/// <summary>
/// 228. Summary Ranges
/// </summary>
internal static class SummaryRangesQ
{
    public static IList<string> SummaryRanges(int[] nums)
    {
        var rangeSummaryList = new List<string>();

        // Handle empty array
        if (nums.Length == 0)
            return rangeSummaryList;

        // Setup
        byte subrangeStartIndex = 0;

        // Move to end of contiguous range
        for (byte i = 0; i < nums.Length; i++)
        {
            if (i + 1 == nums.Length || nums[i + 1] != nums[i] + 1)
            {
                if (subrangeStartIndex == i)
                {
                    rangeSummaryList.Add($"{nums[subrangeStartIndex]}");
                }
                else
                {
                    rangeSummaryList.Add($"{nums[subrangeStartIndex]}->{nums[i]}");
                }
                subrangeStartIndex = (byte)(i + 1);
            }
        }

        return rangeSummaryList;
    }

    public static void Client()
    {
        var rangeSummaryStrings = SummaryRanges([-34, -33, -32, -1, 0, 1, 4, 6, 10, 11]);

        foreach (var summary in rangeSummaryStrings)
        {
            Console.WriteLine(summary);
        }
    }
}
