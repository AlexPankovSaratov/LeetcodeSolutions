using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
	public class HardDifficulty
	{
		/*
		Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
		The overall run time complexity should be O(log (m+n)).

		Example 1:

		Input: nums1 = [1,3], nums2 = [2]
		Output: 2.00000
		Explanation: merged array = [1,2,3] and median is 2.
		*/
		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			List<int> UnionArr = new List<int>();
			int index1 = 0;
			int index2 = 0;
			while (nums1.Length > index1 || nums2.Length > index2)
			{
				if (nums1.Length == index1)
				{
					UnionArr.Add(nums2[index2]);
					index2++;
				}
				else if(nums2.Length == index2)
				{
					UnionArr.Add(nums1[index1]);
					index1++;
				}
				else if(nums1[index1] > nums2[index2])
				{
					UnionArr.Add(nums2[index2]);
					index2++;
				}
				else if (nums1[index1] < nums2[index2])
				{
					UnionArr.Add(nums1[index1]);
					index1++;
				}
				else
				{
					UnionArr.Add(nums1[index1]);
					UnionArr.Add(nums2[index2]);
					index1++;
					index2++;
				}
			}
			if (UnionArr.Count == 1)
			{
				return UnionArr[0];
			}
			else if(UnionArr.Count % 2 == 0)
			{
				return (double)(UnionArr[UnionArr.Count / 2 - 1] + UnionArr[UnionArr.Count / 2]) / 2;
			}
			else
			{
				return UnionArr.ElementAt((UnionArr.Count / 2));
			}
		}

		/*
		You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
		Merge all the linked-lists into one sorted linked-list and return it.

		Example 1:

		Input: lists = [[1,4,5],[1,3,4],[2,6]]
		Output: [1,1,2,3,4,4,5,6]
		Explanation: The linked-lists are:
		[
		  1->4->5,
		  1->3->4,
		  2->6
		]
		merging them into one sorted list:
		1->1->2->3->4->4->5->6
		*/
		public ListNode MergeKLists(ListNode[] lists)
		{
			List<ListNode> MainLists = lists.Where(n => n != null).ToList();
			ListNode ResultListNode = null;
			ListNode LastListNode = null;
			int MinVal = int.MaxValue;
			List<int> ListIndex = new List<int>();

			while (MainLists.Count() > 0)
			{
				for (int i = 0; i < MainLists.Count; i++)
				{
					if (MainLists[i].val < MinVal)
					{
						MinVal = MainLists[i].val;
						ListIndex.Clear();
						ListIndex.Add(i);
					}
					else if (MainLists[i].val == MinVal)
					{
						ListIndex.Add(i);
					}
				}
				foreach (var item in ListIndex)
				{
					if (ResultListNode == null)
					{
						ResultListNode = new ListNode(MainLists[item].val);
						LastListNode = ResultListNode;
					}
					else
					{
						LastListNode.next = new ListNode(MainLists[item].val);
						LastListNode = LastListNode.next;
					}
				}
				ListIndex.Reverse();
				foreach (var item in ListIndex)
				{
					if (MainLists[item].next == null)
					{
						MainLists.RemoveAt(item);
					}
					else
					{
						MainLists[item] = MainLists[item].next;
					}
				}
				MinVal = int.MaxValue;
			}

			return ResultListNode;
		}

		/*
		A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. 
		A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.
		The path sum of a path is the sum of the node's values in the path.
		Given the root of a binary tree, return the maximum path sum of any path.

		Example 1:

		Input: root = [-10,9,20,null,null,15,7]
		Output: 42
		Explanation: The optimal path is 15 -> 20 -> 7 with a path sum of 15 + 20 + 7 = 42.
		*/
		public int MaxPathSum(TreeNode root)
		{
			return 1;
		}
	}
}
