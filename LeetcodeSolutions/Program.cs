using System;

namespace LeetcodeSolutions
{
	class Program
	{
		static void Main(string[] args)
		{
			EasyDifficulty easyDifficulty = new EasyDifficulty();
			MediumDifficulty mediumDifficulty = new MediumDifficulty();
			HardDifficulty hardDifficulty = new HardDifficulty();

			mediumDifficulty.GenerateParenthesis(7);
		}
	}

	#region Helper classes

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

	/// <summary>
	/// Definition for a binary tree node.
	/// </summary>
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}

	#endregion
}
