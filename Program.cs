using System;

namespace LeetCode
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 3, 5, 6 };
            int target = 5;
            Console.WriteLine(solution.SearchInsert(nums, target)); 
        }

        
    }
}
