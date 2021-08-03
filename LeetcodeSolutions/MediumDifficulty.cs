using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
	public class MediumDifficulty
	{
		/*
		You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order,
		and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
		You may assume the two numbers do not contain any leading zero, except the number 0 itself

		Example 1:

		Input: l1 = [0], l2 = [0]
		Output: [0]
		*/	
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			int number1 = 0;
			int number2 = 0;
			string resStr = "";
			bool overflow = false;
			ListNode resNode = null;
			ListNode lastNode = null;
			while (l1 != null || l2 != null)
			{
				if (l1 != null)
				{
					number1 = l1.val;
					l1 = l1.next;
				}
				else
				{
					number1 = 0;
				}
				if (l2 != null)
				{
					number2 = l2.val;
					l2 = l2.next;
				}
				else
				{
					number2 = 0;
				}
				int sum = number1 + number2;
				if (overflow)
				{
					overflow = false;
					sum++;
				}
				if (sum > 9)
				{
					overflow = true;
					sum -= 10;
				}
				resStr += sum.ToString();
			}
			if (overflow) resStr += "1";
			foreach (var item in resStr.Reverse())
			{
				resNode = new ListNode(int.Parse(new string(item, 1)));
				if (lastNode != null)
				{
					resNode.next = lastNode;
				}
				lastNode = resNode;
			}
			return resNode;
		}

		/*
		Given a string s, find the length of the longest substring without repeating characters.
		Example 1:

		Input: s = "abcabcbb"
		Output: 3
		Explanation: The answer is "abc", with the length of 3.
		*/
		public int LengthOfLongestSubstring(string s)
		{
			#region My algorithm
			//List<char> strArr = s.ToList<char>();
			//int maxLength = 0;
			//List<char> targetArr = new List<char>();
			//for (int i = 0; i < strArr.Count; i++)
			//{
			//	if (targetArr.Contains(strArr[i]))
			//	{
			//		if (targetArr.Count > maxLength) maxLength = targetArr.Count;
			//		strArr = strArr.Skip(strArr.IndexOf(strArr[i]) + 1).ToList();
			//		i = -1;
			//		targetArr.Clear();
			//	}
			//	else
			//	{
			//		targetArr.Add(strArr[i]);
			//	}
			//}
			//if (targetArr.Count > maxLength) maxLength = targetArr.Count;
			//return maxLength;
			#endregion

			#region Leetcode algorithm
			List<string> ArrStr = new List<string>();
			int n = s.Length;
			int res = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = i; j < n; j++)
				{
					if (!ArrStr.Contains(s.Substring(i, j - i + 1)))
					{
						if (checkRepetition(s, i, j))
						{
							res = Math.Max(res, j - i + 1);
						}
						ArrStr.Add(s.Substring(i, j - i + 1));
					}
				}
			}
			return res;
		}
		private bool checkRepetition(string s, int start, int end)
		{
			int[] chars = new int[128];

			for (int i = start; i <= end; i++)
			{
				char c = s.ElementAt(i);
				chars[c]++;
				if (chars[c] > 1)
				{
					return false;
				}
			}

			return true;
			#endregion
		}
	}
}
