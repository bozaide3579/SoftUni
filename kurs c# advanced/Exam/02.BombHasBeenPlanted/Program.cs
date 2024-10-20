using System.Numerics;

namespace _02.BombHasBeenPlanted
{
	internal class Program
	{
		private const char CT = 'C';
		private const char T = 'T';
		private const char Bomb = 'B';
		private const char Empty = '*';

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
				.Split(", ")
				.Select(int.Parse)
				.ToArray();

			int row = input[0];
			int col = input[1];
			char[,] matrix = new char[row, col];

			for (int i = 0; i < row; i++)
			{
				string data = Console.ReadLine();
				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			(int playerRow, int playerCol) = FindPlayer(matrix);
			int initialRow = playerRow;
			int initialCol = playerCol;

			int timer = 16;
			bool isDefused = false;
			bool exploded = false;
			bool isKilled = false;

			while (timer > 0 && isDefused == false && isKilled == false)
			{
				string command = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(command))
				{
					continue;
				}

				if (!_directions.ContainsKey(command))
				{
					if (command == "defuse")
					{
						if (matrix[playerRow, playerCol] == Bomb)
						{
							if (timer >= 4)
							{
								timer -= 4;
								matrix[playerRow, playerCol] = 'D';
								isDefused = true;
								break;
							}
							else
							{
								exploded = true;
								matrix[playerRow, playerCol] = 'X';
								break;
							}
						}
						else
						{
							timer -= 2;
						}
					}
					continue;
				}

				(int rowChange, int colChange) = _directions[command];
				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChange;

				if (nextRow >= 0 && nextRow < row && nextCol >= 0 && nextCol < col)
				{
					if (matrix[nextRow, nextCol] == Empty || matrix[nextRow, nextCol] == Bomb)
					{
						if (matrix[playerRow, playerCol] == Bomb)
						{
							matrix[playerRow, playerCol] = Bomb;
							playerRow = nextRow;
							playerCol = nextCol;
							matrix[playerRow, playerCol] = CT;
						}
						else
						{
							matrix[playerRow, playerCol] = Empty;
							playerRow = nextRow;
							playerCol = nextCol;
							matrix[playerRow, playerCol] = CT;
						}

						timer--;
					}
					else if (matrix[nextRow, nextCol] == T)
					{
						if (matrix[playerRow, playerCol] == Bomb)
						{
							matrix[playerRow, playerCol] = Bomb;
							playerRow = nextRow;
							playerCol = nextCol;
							matrix[playerRow, playerCol] = CT;
						}
						else
						{
							matrix[playerRow, playerCol] = Empty;
							playerRow = nextRow;
							playerCol = nextCol;
							matrix[playerRow, playerCol] = Empty;
						}

						isKilled = true;
						timer--;
						break;
					}
				}
				else
				{
					timer--;
				}
			}

			if (exploded || timer < 0)
			{
				Console.WriteLine("Terrorists win!");
				Console.WriteLine("Bomb was not defused successfully!");
				Console.WriteLine($"Time needed: {16 - timer} second/s.");
			}
			else if (isDefused)
			{
				Console.WriteLine("Counter-terrorist wins!");
				Console.WriteLine($" Bomb has been defused: {timer} second/s remaining.");
			}
			else if (isKilled)
			{
				Console.WriteLine("Terrorists win!");
			}

			matrix[playerRow, playerCol] = Empty;
			matrix[initialRow, initialCol] = CT;

			PrintMatrix(matrix);
		}


		private static (int Row, int Col) FindPlayer(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == CT)
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


/*
5, 7
*****T*
****T**
**B****
***T**T
C*****T
up
up
down
right
right
up
up
defuse
down
defuse
*/