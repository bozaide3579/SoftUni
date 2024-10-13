namespace _1.CountSameValuesInArray
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<double> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

			Dictionary<double, int> counts = new Dictionary<double, int>();

			foreach (var number in numbers)
			{
				if (!counts.ContainsKey(number))
				{
					counts.Add(number, 0);
				}

				counts[number]++;
			}

			foreach (var count in counts)
			{
				Console.WriteLine($"{count.Key} - {count.Value} times");
			}
		}
	}
}
