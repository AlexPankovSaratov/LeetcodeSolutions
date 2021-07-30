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
	}
}
