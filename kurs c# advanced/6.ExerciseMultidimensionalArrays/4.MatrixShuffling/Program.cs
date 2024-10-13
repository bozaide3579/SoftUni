namespace _4.MatrixShuffling
{
	public class Program
	{
		public static void Main()
		{
			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int rows = dimentions[0];
			int cols = dimentions[1];

			string[][] matrix = new string[rows][];
			for (int i = 0; i < rows; i++)
			{
				matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

			}

			string command;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if (InterpretCommand(matrix, data))
				{
					PrintMatrix(matrix);
				}
				else
				{
                    Console.WriteLine("Invalid input!");
                }
			}
		}

		private static bool InterpretCommand(string[][] matrix, string[] command)
		{
			if (command.Length != 5 || command[0] != "swap")
			{
                return false;
            }

			int row1 = int.Parse(command[1]);
			int col1 = int.Parse(command[2]);
			if (!IndiciesAreValid(matrix, row1, col1))
			{
				return false ;
			}
			int row2 = int.Parse(command[3]);
			int col2 = int.Parse(command[4]);
			if (!IndiciesAreValid(matrix, row2, col2))
			{
				return false;
			}

			string temp = matrix[row1][col1];
			matrix[row1][col1] = matrix[row2][col2];
			matrix[row2][col2] = temp;

			return true;
		}

		private static bool IndiciesAreValid(string[][] matrix, int row, int col)
		{
			return 0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length;
		}

		private static void PrintMatrix(string[][] matrix)
		{
			foreach (string[] row in matrix)
			{
                Console.WriteLine(string.Join(' ', row));
            }

		}

	}
}
