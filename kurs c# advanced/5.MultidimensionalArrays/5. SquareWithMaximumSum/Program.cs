namespace _5._SquareWithMaximumSum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int cols = dimentions[1];

			int[,] matrix = new int[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			int maxSum = int.MinValue, maxOriginRow = -1, maxOriginCol = -1;
			for (int i = 0; i < rows - 1; i++)
			{
				for (int j = 0; j < cols - 1; j++)
				{
					int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

					if (currentSum > maxSum)
					{
						maxSum = currentSum;
						maxOriginRow = i;
						maxOriginCol = j;
					}
				}
			}

			Console.WriteLine($"{matrix[maxOriginRow, maxOriginCol]} {matrix[maxOriginRow, maxOriginCol + 1]}");
            Console.WriteLine($"{matrix[maxOriginRow + 1, maxOriginCol]} {matrix[maxOriginRow + 1, maxOriginCol + 1]}");
            Console.WriteLine(maxSum);
        }
	}
}
