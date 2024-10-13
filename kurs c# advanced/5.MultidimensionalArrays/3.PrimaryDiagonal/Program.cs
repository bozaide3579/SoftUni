namespace _3.PrimaryDiagonal
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int rows = n;
			int cols = n;
			int[,] matrx = new int[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

				for (int j = 0; j < cols; j++)
				{
					matrx[i, j] = data[j];
				}
			}

			int sum = 0;
			for (int i = 0; i < rows; i++)
			{
				sum += matrx[i, i];
			}

			Console.WriteLine(sum);
		}
	}
}
