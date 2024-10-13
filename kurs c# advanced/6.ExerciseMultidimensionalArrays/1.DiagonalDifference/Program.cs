namespace _1.DiagonalDifference
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[,] matrix = new int[n, n];

			for (int i = 0; i < n; i++)
			{
				int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int j = 0; j < n; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			int primarySum = 0;
			for (int i = 0;i < n; i++)
			{
				primarySum += matrix[i, i];
			}

			int secondarySum = 0;
			for(int i = 0; i < n; i++)
			{
				secondarySum += matrix[i, n - (i + 1)];
			}

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
	}
}
