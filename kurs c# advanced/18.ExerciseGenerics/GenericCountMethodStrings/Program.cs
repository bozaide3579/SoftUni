namespace GenericCountMethodStrings
{
	public class Program
	{
		public static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			Box<string>[] boxedValues = new Box<string>[n];
			for (int i = 0; i < n; i++)
			{
				string line = Console.ReadLine();
				boxedValues[i] = new Box<string>(line);
			}

			string queryValue = Console.ReadLine();

			int results = Count(boxedValues, queryValue);
            Console.WriteLine(results);
        }

		private static int Count<T>(Box<T>[] array, T queryValue, IComparer<T>? comparer = null)
		{
			if (comparer is null) comparer = Comparer<T>.Default;

			int count = 0;	
			foreach (Box<T> box in array)
			{
				int compareResults = comparer.Compare(box.Value, queryValue);
				if (compareResults > 0 ) count++;
			}

			return count;
		}
	}
}
