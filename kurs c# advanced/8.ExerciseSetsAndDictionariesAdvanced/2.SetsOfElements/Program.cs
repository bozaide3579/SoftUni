namespace _2.SetsOfElements
{
	public class Program
	{
		public static void Main()
		{
			int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int n = sizes[0];
			int m = sizes[1];

			HashSet<int> firstSet = ReadInt(n);
			HashSet<int> secondSet = ReadInt(m);

			List<int> result = new List<int>();

			foreach (int number in firstSet)
			{
				if (secondSet.Contains(number))
				{
					result.Add(number);
				}
			}

			Console.WriteLine(string.Join(" ", result));

		}

		private static HashSet<int> ReadInt(int count)
		{
			HashSet<int> set = new HashSet<int>();

			for (int i = 0; i < count; i++)
			{
				int currentNum = int.Parse(Console.ReadLine());
				set.Add(currentNum);
			}

			return set;
		}

	}
}
