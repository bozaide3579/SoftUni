namespace _8.Bombs
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int[,] matrix = ReadMatrix(n);
			int[,] bombCoordinates = ReadBombs();

			for (int i = 0; i < bombCoordinates.GetLength(0); i++)
			{
				int bombRow = bombCoordinates[i, 0];
				int bombCol = bombCoordinates[i, 1];
				ExplodeBomb(matrix, bombRow, bombCol);
			}

			int aliveCells = 0;
			int sum = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (matrix[i, j] > 0)
					{
						aliveCells++;
						sum += matrix[i, j];
					}
				}
			}

			PrintAnswer(matrix, aliveCells, sum);
		}

		private static void PrintAnswer(int[,] matrix, int aliveCells, int sum)
		{
			Console.WriteLine($"Alive cells: {aliveCells}");
			Console.WriteLine($"Sum: {sum}");

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (j > 0)
					{
						Console.Write(' ');
					}
					Console.Write(matrix[i, j]);
				}

				Console.WriteLine();
			}

		}
		private static int[,] ReadMatrix(int n)
		{
			int[,] matrix = new int[n, n];

			for (int i = 0; i < n; i++)
			{
				int[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int j = 0; j < n; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			return matrix;
		}

		private static int[,] ReadBombs()
		{
			string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

			int[,] bombCoordinates = new int[data.Length, 2];
			for (int i = 0; i < bombCoordinates.GetLength(0); i++)
			{
				int[] coordinates = data[i].Split(',').Select(int.Parse).ToArray();

				for (int j = 0; j < bombCoordinates.GetLength(1); j++)
				{
					bombCoordinates[i, j] = coordinates[j];
				}
			}

			return bombCoordinates;
		}

		private static void ExplodeBomb(int[,] matrix, int row, int col)
		{
			if (matrix[row, col] <= 0)
			{
				return;
			}

			int rowItreStart = Math.Max(row - 1, 0);
			int rowIterEnd = Math.Min(row + 1, matrix.GetLength(0) - 1);

			int colIterStart = Math.Max(col - 1, 0);
			int colIterEnd = Math.Min(col + 1, matrix.GetLength(1) - 1);
			int damage = matrix[row, col];

			for (int i = rowItreStart; i <= rowIterEnd; i++)
			{
				for (int j = colIterStart; j <= colIterEnd; j++)
				{
					if (matrix[i, j] > 0)
					{
						matrix[i, j] -= damage;
					}
				}
			}
		}
	}
}
