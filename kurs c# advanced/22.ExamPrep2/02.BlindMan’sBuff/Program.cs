namespace _02.BlindMan_sBuff
{
	internal class Program
	{
		private const char EmptySymbol = '-';
		private const char Player = 'B';
		private const char Obsticle = 'O';
		private const char Enemy = 'P';

		private static readonly Dictionary<string, (int RowChnage, int ColChange)>
			_directions = new Dictionary<string, (int RowChnage, int ColChange)>
			{
				["up"] = (-1, 0),
				["right"] = (0, 1),
				["down"] = (1, 0),
				["left"] = (0, -1)
			};

		static void Main(string[] args)
		{
			int[] input = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToArray();

			int row = input[0];
			int col = input[1];

			char[,] matrix = new char[row, col];
			for (int i = 0; i < row; i++)
			{
				string data = Console.ReadLine();
				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = data[j * 2];
				}

			}

			(int playerRow, int playerCol) = FindPlayer(matrix);

			int moves = 0;
			int playersTouched = 0;

			string command;
			while ((command = Console.ReadLine()) != "Finish")
			{
				(int rowChange, int colChange) = _directions[command];

				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChange;

				if (nextRow < 0 || nextRow >= row || nextCol < 0 || nextCol >= col)
				{
					continue;
				}
				else if (matrix[nextRow, nextCol] == Obsticle)
				{
					continue;
				}
				else if (matrix[nextRow, nextCol] == EmptySymbol)
				{
					moves++;

					matrix[playerRow, playerCol] = EmptySymbol;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Player;
				}
				else if (matrix[nextRow, nextCol] == Enemy)
				{
					moves++;
					playersTouched++;

					matrix[playerRow, playerCol] = EmptySymbol;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Player;

					if (!ContainsEnemies(matrix))
					{
						break;
					}
				}
			}

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {playersTouched} Moves made: {moves}");
        }

		private static (int Row, int Col) FindPlayer(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == Player)
					{
						return (i, j);
					}
				}
			}

			return (-1, -1);
		}

		private static bool ContainsEnemies(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == Enemy)
					{
						return true;
					}
				}
			}
			return false;

		}
	}
}
