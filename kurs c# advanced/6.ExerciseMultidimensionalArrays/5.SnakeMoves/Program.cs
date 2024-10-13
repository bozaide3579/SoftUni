namespace _5.SnakeMoves
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int rows = dimentions[0];
			int cols = dimentions[1];

			string snake = Console.ReadLine();

			char[,] matrix = new char[rows, cols];

			int index = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					int col;
					if (i % 2 == 0) col = j;
					else col = cols - (j + 1);

					matrix[i, col] = snake[index];

					if (index == snake.Length - 1) index = 0;
					else index++;
				}
			}

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Console.Write(matrix[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}
