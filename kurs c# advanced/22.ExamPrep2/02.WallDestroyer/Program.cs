using System.Numerics;
using System.Reflection;

namespace _02.WallDestroyer
{
	internal class Program
	{
		private const char EmptySymbol = '-';
		private const char Vanko = 'V';
		private const char Rods = 'R';
		private const char Cables = 'C';
		private const char Hole = '*';

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
			int n = int.Parse(Console.ReadLine());
			char[,] matrix = new char[n, n];

			for (int i = 0; i < n; i++)
			{
				string data = Console.ReadLine();
				for (int j = 0; j < n; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			(int playerRow, int playerCol) = FindPlayer(matrix);

			int holesCount = 1;
			int rodsHitCount = 0;
			string command;
			while ((command = Console.ReadLine()) != "End")
			{
				(int rowChange, int colChange) = _directions[command];
				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChange;

				if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
				{
					continue;
				}

				if (matrix[nextRow, nextCol] == EmptySymbol)
				{
					holesCount++;

					matrix[playerRow, playerCol] = Hole;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Vanko;
				}
				else if (matrix[nextRow, nextCol] == Rods)
				{
                    Console.WriteLine("Vanko hit a rod!");
					rodsHitCount++;
				}
				else if (matrix[nextRow, nextCol] == Cables)
				{
					holesCount++;
					matrix[playerRow, playerCol] = Hole;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = 'E'; // Vanko gets electrocuted
					Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
					break;
				}
				else if (matrix[nextRow, nextCol] == Hole)
				{
                    Console.WriteLine($"The wall is already destroyed at position [{nextRow}, {nextCol}]!");
					matrix[playerRow, playerCol] = Hole;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Vanko;
				}
				
				
            }

			if (matrix[playerRow, playerCol] != 'E')
			{
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsHitCount} rod(s).");
            }

			PrintMatrix(matrix);
		}
		private static (int Row, int Col) FindPlayer(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == Vanko)
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
					Console.Write(matrix[i, j]);
				}

				Console.WriteLine();
			}
		}
	}

	
}
