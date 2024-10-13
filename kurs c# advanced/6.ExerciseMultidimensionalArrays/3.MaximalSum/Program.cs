namespace _3.MaximalSum
{
	public class Program
	{
		const int M = 3;
		const int N = 3;



		public static void Main()
		{

			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int cols = dimentions[1];

			int[,] matrix = new int[rows, cols];
			for (int i = 0; i < rows; i++)
			{
				int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			int maxSum = int.MinValue;
			int maxOriginRow = -1;
			int maxOriginCol = -1;
			for (int i = 0; i < rows - M + 1; i++)
			{
				for (int j = 0; j < cols - N + 1; j++)
				{
					int currentSum = SumSub(matrix, i, j);
					if (currentSum > maxSum)
					{
						maxSum = currentSum;
						maxOriginRow = i;
						maxOriginCol = j;
					}
				}
			}


			Console.WriteLine($"Sum = {maxSum}");
			PrintSum(matrix, maxOriginRow, maxOriginCol);
		}

		private static int SumSub(int[,] matrix, int row, int col)
		{
			int sum = 0;
			for (int i = 0; i < M; i++)
			{
				for (int j = 0; j < N; j++)
				{
					sum += matrix[row + i, col + j];
				}
			}

			return sum;
		}

		private static void PrintSum(int[,] matrix, int row, int col)
		{
			for (int i = 0; i < M; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (j > 0)
					{
						Console.Write(' ');
					}
					Console.Write(matrix[row + i, col + j]);
				}
                Console.WriteLine();
            }
		}
	}
}
