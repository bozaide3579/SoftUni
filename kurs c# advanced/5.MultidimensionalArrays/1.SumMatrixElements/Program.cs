namespace _1.SumMatrixElements
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

			int sum = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					sum += matrix[i, j];
				}
			}

            Console.WriteLine(matrix.GetLength(0));
			Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
	}
}
