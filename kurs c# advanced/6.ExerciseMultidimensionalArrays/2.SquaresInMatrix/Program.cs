namespace _2.SquaresInMatrix
{
	internal class Program
	{
		static void Main()
		{
			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int rows = dimentions[0];
			int cols = dimentions[1];

			char[][] matrix = new char[rows][];
			for (int i = 0; i < rows; i++)
			{
				matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
			}

			int count = 0;
			for (int i = 0;i < rows - 1; i++)
			{
				for (int j = 0; j < cols - 1; j++)
				{
					bool areEqual = matrix[i][j] == matrix[i][j + 1] 
						&& matrix[i][j] == matrix[i +1 ][j]
						&& matrix[i][j] == matrix[i + 1][j + 1];
						
					if (areEqual)
					{
						count++;
					}
				}
			}

            Console.WriteLine(count);
        }
	}
}
