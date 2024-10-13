namespace _5.CountSymbols
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

			foreach (char symbol in text)
			{
				if (!symbolsCount.ContainsKey(symbol))
				{
					symbolsCount[symbol] = 0;
				}
				symbolsCount[symbol]++;
			}

			foreach (var (symbol, count) in symbolsCount.OrderBy(x => x.Key))
			{
				Console.WriteLine($"{symbol}: {count} time/s");
			}


		}
	}
}
