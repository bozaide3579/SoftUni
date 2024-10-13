namespace _4.SymbolInMatrix
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int rows = n;
			int cols = n;
			char[,] matrix = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				string row = Console.ReadLine();
				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = row[j];
				}
			}

			char symbol = char.Parse(Console.ReadLine());
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (matrix[i, j] == symbol)
					{
						Console.WriteLine($"({i}, {j})");
						return;
					}
				}
			}

			Console.WriteLine($"{symbol} does not occur in the matrix");
		}
	}
}
