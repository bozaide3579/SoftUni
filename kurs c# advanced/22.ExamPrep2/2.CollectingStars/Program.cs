using System.Net.Http.Headers;

namespace _2.CollectingStars
{
	public class Program
	{
		private static readonly Dictionary<string, (int RowChange, int ColChange)> _directions
			= new Dictionary<string, (int RowChange, int ColChange)>
			{
				["up"] = (-1, 0),
				["right"] = (0, 1),
				["down"] = (1, 0),
				["left"] = (0, -1)
			};

		public static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			char[,] matrix = new char[n, n];
			for (int i = 0; i < n; i++)
			{
				string data = Console.ReadLine();

				for (int j = 0; j < n; j++)
				{
					matrix[i, j] = data[j * 2];
				}
			}

			(int playerRow, int playerCol) = FindPlayer(matrix);

			int stars = 2;
			while (stars > 0 && stars < 10)
			{
				string command = Console.ReadLine();

				(int rowChange, int colChanage) = _directions[command];

				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChanage;

				if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
				{
					nextRow = 0;
					nextCol = 0;
				}

				if (matrix[nextRow, nextCol] == '#')
				{
					stars--;
				}
				else
				{
					if (matrix[nextRow, nextCol] == '*')
					{
						stars++;
					}

					matrix[playerRow, playerCol] = '.';
					matrix[nextRow, nextCol] = 'P';

					playerRow = nextRow;
					playerCol = nextCol;
				}
			}

			if (stars == 0)
			{
				Console.WriteLine("Game over! You are out of any stars.");
			}
			else
			{
				Console.WriteLine("You won! You have collected 10 stars.");
			}

			Console.WriteLine($"Your final position is [{playerRow}, {playerCol}]");
			PrintMatrix(matrix);
		}

		private static (int Row, int Col) FindPlayer(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == 'P')
					{
						return (i, j);
					}
				}
			}

			return (-1, -1);
		}

		private static void PrintMatrix(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (j > 0) Console.Write(' ');
					Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
		}
	}
}
