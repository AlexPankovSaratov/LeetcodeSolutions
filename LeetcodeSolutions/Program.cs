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
	#endregion
}
