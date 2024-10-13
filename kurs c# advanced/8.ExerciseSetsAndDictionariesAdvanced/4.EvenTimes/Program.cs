namespace _4.EvenTimes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			Dictionary<int, int> numberCounter = new Dictionary<int, int>();

			for (int i = 0; i < n; i++)
			{
				int currentNumber = int.Parse(Console.ReadLine());

				if (!numberCounter.ContainsKey(currentNumber))
				{
					numberCounter[currentNumber] = 0;
				}

				numberCounter[currentNumber]++;
			}

			var result = numberCounter.Single(x => x.Value % 2 == 0).Key;
			Console.WriteLine(result);
		}
	}
}
