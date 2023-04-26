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

		/*
		A conveyor belt has packages that must be shipped from one port to another within days days.

		The ith package on the conveyor belt has a weight of weights[i]. Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

		Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within days days.

 

		Example 1:

		Input: weights = [1,2,3,4,5,6,7,8,9,10], days = 5
		Output: 15
		Explanation: A ship capacity of 15 is the minimum to ship all the packages in 5 days like this:
		1st day: 1, 2, 3, 4, 5
		2nd day: 6, 7
		3rd day: 8
		4th day: 9
		5th day: 10

		Note that the cargo must be shipped in the order given, so using a ship of capacity 14 and splitting the packages into parts like (2, 3, 4, 5), (1, 6, 7), (8), (9), (10) is not allowed.
		Example 2:

		Input: weights = [3,2,2,4,1,4], days = 3
		Output: 6
		Explanation: A ship capacity of 6 is the minimum to ship all the packages in 3 days like this:
		1st day: 3, 2
		2nd day: 2, 4
		3rd day: 1, 4
		Example 3:

		Input: weights = [1,2,3,1,1], days = 4
		Output: 3
		Explanation:
		1st day: 1
		2nd day: 2
		3rd day: 3
		4th day: 1, 1
		*/
		public int ShipWithinDays(int[] weights, int days)
		{
			//solution by increasing the weight value

			/*
			int minCapacityShip = weights.Max();
			while (GetCountDayByWeight(weights, minCapacityShip) > days) minCapacityShip++;
			return minCapacityShip;
			*/

			//binary search solution
			int minCapacityShip = weights.Max();
			int maxCapacityShip = weights.Sum();
			
			while (minCapacityShip != maxCapacityShip)
			{
				int midCapacityShip = (minCapacityShip + maxCapacityShip) / 2;
				var q = GetCountDayByWeight(weights, midCapacityShip);
				if (GetCountDayByWeight(weights, midCapacityShip) <= days)
				{
					maxCapacityShip = midCapacityShip;
				}
				else
				{
					minCapacityShip = midCapacityShip + 1;
				}
			}		
			return minCapacityShip;
		}

		/*
		 A decimal number is called deci-binary if each of its digits is either 0 or 1 without any leading zeros. For example, 101 and 1100 are deci-binary, while 112 and 3001 are not.

		Given a string n that represents a positive decimal integer, return the minimum number of positive deci-binary numbers needed so that they sum up to n.

 

		Example 1:

		Input: n = "32"
		Output: 3
		Explanation: 10 + 11 + 11 = 32
		Example 2:

		Input: n = "82734"
		Output: 8
		Example 3:

		Input: n = "27346209830709182346"
		Output: 9
 

		Constraints:

		1 <= n.length <= 105
		n consists of only digits.
		n does not contain any leading zeros and represents a positive integer.
		*/
		public int MinPartitions(string n)
		{
			return int.Parse(n.ToArray().OrderBy(c => int.Parse(c.ToString())).LastOrDefault().ToString());

			//First solution
			int countIter = 0;
			SubtractMaxDeciBinary(n, ref countIter);
			return countIter;
		}

		/*
		 Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

		Example 1:

		Input: n = 3
		Output: ["((()))","(()())","(())()","()(())","()()()"]
		Example 2:

		Input: n = 1
		Output: ["()"]
 

		Constraints:

		1 <= n <= 8
		*/
		public IList<string> GenerateParenthesis(int n)
		{
			List<string> resultList = new List<string>();
			if (n == 0) return resultList;
			if (n == 1) return new List<string> { "()" };
			foreach (var item in GenerateParenthesis(n - 1))
			{
				var itemArr = item.ToArray();
				for (int i = 0; i < item.Length; i++)
				{
					var targetCase = "(" + item.Insert(i, ")");
					if (!resultList.Contains(targetCase))
					{
						resultList.Add(targetCase);
					}
					targetCase = item.Insert(i, "(") + ")";
					if (!resultList.Contains(targetCase))
					{
						resultList.Add(targetCase);
					}
					if (i < n / 2)
					{
						targetCase = item.Insert(i, "(").Insert(n - i, ")");
						if (!resultList.Contains(targetCase))
						{
							resultList.Add(targetCase);
						}
					}
				}
			}
			return resultList;
		}

		#region private metods
		private int GetCountDayByWeight(int[] weights, int capacityShip)
		{
			int ostCapacity = 0;
			int countDays = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				if (ostCapacity >= weights[i])
				{
					ostCapacity = ostCapacity - weights[i];
				}
				else
				{
					countDays++;
					ostCapacity = capacityShip - weights[i];
				}
			}
			return countDays;
		}

		private void SubtractMaxDeciBinary(string n, ref int countIter)
		{
			char[] maxDeciBinary = new char[n.Length];
			char[] subtractionResult = new char[n.Length];
			var needCallNext = false;
			for (int i = 0; i < n.Length; i++)
			{
				if (n[i] != '0')
				{
					maxDeciBinary[i] = '1';
				}
				else
				{
					maxDeciBinary[i] = '0';
				}
				subtractionResult[i] = (int.Parse(n[i].ToString()) - int.Parse(maxDeciBinary[i].ToString())).ToString().FirstOrDefault();
				if (subtractionResult[i] != '0') needCallNext = true;
			}
			countIter++;
			if (needCallNext) SubtractMaxDeciBinary(new string(subtractionResult), ref countIter);
		}
		#endregion

	}
}
