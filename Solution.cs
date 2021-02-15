using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LeetCode
{
    public class Solution
    {
        // Search insert position
        public int SearchInsert(int[] nums, int target) {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target)
                {
                    continue;
                }

                if (nums[i] == target)
                {
                    return i;
                }

                if (nums[i] > target)
                {
                    return i;
                }

            }

            return nums.Length;
        }
        // Implement strStr()
        public int StrStr(string haystack, string needle)
        {
            if (needle == "")
            {
                return 0;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    if (IsSameStr(haystack, needle, i))
                        return i;
                }
            }
            
            return -1;
        }

        public bool IsSameStr(string haystack, string needle, int startIndex)
        {
            int index = startIndex;
            if (haystack.Length - index  < needle.Length)
            {
                return false;
            }
            for (int i = 0; i < needle.Length; i++)
            {
                if (haystack[index] != needle[i])
                {
                    return false;
                }

                index++;
            }

            return true;
        }
        // Remove element
        public int RemoveElement(int[] nums, int val)
        {
            int SIZE = nums.Length;
            for (int i = 0; i < SIZE; i++)
            {
                if (nums[i] == val)
                {
                    RepositionArray(nums, i);
                    i--;
                    SIZE--;
                    continue;
                }
                else
                {
                    continue;
                }
                
            }            
            return SIZE;
        }

        public void RepositionArray(int[] nums, int index)
        {
            for (int i = index; i < nums.Length - 1; i++)
            {
                nums[i] = nums[i + 1];
            }
        }
        // Remove duplicates from sorted array
        public int RemoveDuplicates(int[] nums)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Count() == 0)
                {
                    list.Add(nums[i]);                    
                    continue;
                }

                else
                {
                    if (isInList(nums[i], list))
                    {
                        continue;
                    }

                    else
                    {
                        list.Add(nums[i]);
                    }
                }
            }
            //nums = list.ToArray();
            for (int i = 0; i < list.Count(); i++)
            {
                nums[i] = list[i];
            }
            return list.Count;
        }

        public bool isInList(int value, List<int> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == value)
                {
                    return true;
                }

                else
                {
                    continue;
                }
            }

            return false;
        }
        // Merge two sorted lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            List<int> list = new List<int>();
            if (l1 == null && l2 == null)
            {
                return null;
            }

            if (l1 != null)
            {
                while (true)
                {
                    if (l1.next != null)
                    {
                        list.Add(l1.val);
                        l1.val = l1.next.val;
                        l1.next = l1.next.next;
                    }

                    else
                    {
                        list.Add(l1.val);
                        break;
                    }
                }
            }

            if (l2 != null)
            {
                while (true)
                {
                    if (l2.next != null)
                    {
                        list.Add(l2.val);
                        l2.val = l2.next.val;
                        l2.next = l2.next.next;
                    }

                    else
                    {
                        list.Add(l2.val);
                        break;
                    }
                }
            }
            list.Sort();

            int LENGTH = list.Count();
            ListNode[] listArr = new ListNode[LENGTH];

            for (int i = LENGTH - 1; i >= 0; i--)
            {


                if (i == LENGTH - 1)
                {
                    listArr[i] = new ListNode(list[i], null);
                }

                else
                {
                    listArr[i] = new ListNode(list[i], listArr[i + 1]);
                }
            }

            return listArr[0];
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        // Valid prentheses
        public bool IsValid(string s)
        {
            Stack st = new Stack();            

            char temp;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 40 || s[i] == 91 || s[i] == 123)
                {
                    st.Push(s[i]);                    
                }                

                else 
                {
                    if (st.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        temp = (char)st.Pop();
                        if (s[i] - temp == 1 || s[i] - temp == 2)
                        {
                            continue;
                        }

                        else
                        {
                            return false;
                        }
                    }
                                       
                }
            }

            if (st.Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }

        // Longest common prefix
        public string LongestCommonPrefix(string[] strs)
        {
            List<char> commonPrefix = new List<char>();

            int MIN_LENGTH = 201;
            for (int i = 1; i < strs.Length; i++)
            {               
                if (MIN_LENGTH > strs[i].Length)
                {
                    MIN_LENGTH = strs[i].Length;
                    continue;
                }                
            }

            char temp = 'a';
            for (int i = 0; i < MIN_LENGTH; i++)
            {
                
                for (int j = 0; j < strs.Length; j++)
                {
                    if (j == 0)
                    {
                        temp = strs[j][i];
                        continue;
                    }

                    else
                    {
                        if (temp != strs[j][i])
                        {
                            MIN_LENGTH = i;
                            break;      
                        }

                        else if (j == strs.Length - 1)
                        {
                            commonPrefix.Add(strs[j][i]);
                            continue;
                        }
                    }
                }                
            }
            string result = new string(commonPrefix.ToArray());
            if (result.Length != 0)
            {
                return result;
            }
            else
            {
                return "";
            }
        }

        // RomanToInt
        public int RomanToInt(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}

            };

            Stack st = new Stack();
            int STR_SIZE = s.Length;

            for (int i = 0; i < STR_SIZE; i++)
            {
                if (i == 0)
                {
                    st.Push(dict[s[i]]);
                }

                else
                {
                    if (dict[s[i - 1]] == dict[s[i]])
                    {
                        st.Push(dict[s[i]] + (int)st.Pop());
                    }

                    else if (dict[s[i - 1]] < dict[s[i]])
                    {
                        st.Push(dict[s[i]] - (int)st.Pop());
                    }

                    else
                    {
                        st.Push(dict[s[i]]);
                    }
                }               
            }
            return CalStack(st);
        }

        public int CalStack(Stack st)
        {
            int STACK_SIZE = st.Count;
            int result = 0;
            for (int i = 0; i < STACK_SIZE; i++)
            {
                result += (int)st.Pop();
            }

            return result;
        }

        // ReverseInt
        public int ReverseInt(int x)
        {

            List<int> integers = new List<int>();


            if (x > 0)
            {
                return Calculate(integers, x);
            }
            else
            {
                return -Calculate(integers, x * (-1));
            }


        }

        public int Calculate(List<int> integers, int x)
        {
            int answer = 0;
            int cnt = 1;
            while (true)
            {
                integers.Add(x % 10);

                if (x / 10 > 0)
                {
                    cnt++;
                    x = x / 10;
                    continue;
                }
                else
                {
                    break;
                }

            }
            integers.Add(x % 10);
            Console.WriteLine(cnt);
            Console.WriteLine(integers[0]);

            for (int i = 0; i < cnt; i++)
            {
                answer += integers[i] * (int)Math.Pow((double)10, (double)(cnt - 1 - i));
            }

            if (answer > (int)Math.Pow((double)2, (double)31) - 1)
                return 0;
            else
                return answer;


        }

        public bool IsPalindrome(int x)
        {
            int remainder;
            Stack st = new Stack();
            int result = 0;

            int initValue = x;
            //st.Push(1);
            //st.Push(2);
            //var a = st.Pop();
            if (initValue == 0)
            {
                return true;
            }

            else if (initValue < 0)
            {
                return false;
            }



            while (x != 0)
            {
                remainder = x % 10;
                st.Push(remainder);
                x = x / 10;
            }
            int count = st.Count;
            for (int i = 0; i < count; i++)
            {
                //int a = st.Pop();
                result += ((int)st.Pop() * intPow(10, i));
            }


            if (initValue == result)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private int intPow(int baseNumber, int exponent)
        {
            int result = 1;


            for (int i = 0; i < exponent; i++)
            {
                result *= baseNumber;
            }

            return result;

        }

    }
}
