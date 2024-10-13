namespace _7.CustomComparator
{
	public class Program
	{
		public static void Main()
		{
			int[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Array.Sort(numbers, Comparer);

			Console.WriteLine(string.Join(' ', numbers));
		}

		private static int Comparer(int x, int y)
		{

			if (x % 2 == 0 && y % 2 != 0) return -1;
			if (x % 2 != 0 && y % 2 == 0) return 1;

			return Comparer<int>.Default.Compare(x, y);

		}
	}
}
