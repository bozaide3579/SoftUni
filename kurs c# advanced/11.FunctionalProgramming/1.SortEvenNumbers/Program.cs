namespace _1.SortEvenNumbers
{
	internal class Program
	{
		static void Main()
		{
			int[] array = Console.ReadLine()
				.Split(", ")
				.Select(int.Parse)
				.Where(n => n % 2 == 0)
				.OrderBy(n => n)
				.ToArray();

            Console.WriteLine(String.Join(", ", array));
        }
	}
}
