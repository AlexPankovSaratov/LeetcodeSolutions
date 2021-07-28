using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
	class MediumDifficulty
	{
		/*
		You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order,
		and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
		You may assume the two numbers do not contain any leading zero, except the number 0 itself

		Example 1:

		Input: l1 = [0], l2 = [0]
		Output: [0]
		*/
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
	}
}
