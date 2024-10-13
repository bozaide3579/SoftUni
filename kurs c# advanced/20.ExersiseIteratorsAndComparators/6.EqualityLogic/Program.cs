namespace _6.EqualityLogic
{
	public class Program
	{
		public static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			HashSet<Person> hashSet = new HashSet<Person>();
			SortedSet<Person> sortedSet = new SortedSet<Person>();

			for (int i = 0; i < n; i++)
			{
				string[] data = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					

				Person current = new Person(data[0], int.Parse(data[1]));

				hashSet.Add(current);
				sortedSet.Add(current);
			}

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
	}
}
