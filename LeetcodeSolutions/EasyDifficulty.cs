using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions
{
	class EasyDifficulty
	{
		/*
		Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
		You may assume that each input would have exactly one solution, and you may not use the same element twice.
		You can return the answer in any order.

		Example 1:

		Input: nums = [2,7,11,15], target = 9
		Output: [0,1]
		Output: Because nums[0] + nums[1] == 9, we return [0, 1].
		*/
		public int[] TwoSum(int[] nums, int target)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				for (int k = 0; k < nums.Length; k++)
				{
					if (nums[i] + nums[k] == target && k != i)
					{
						return new int[] { i, k };
					}
				}
			}
			return new int[] { };
		}
	}
}
