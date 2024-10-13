namespace _3.Largest3Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

			numbers = numbers.OrderByDescending(number => number)
				.Take(3)
				.ToList();

			Console.WriteLine($"{String.Join(" ", numbers)}");

		}
	}
}