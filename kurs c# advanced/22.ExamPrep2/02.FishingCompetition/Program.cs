using System.Runtime.CompilerServices;

namespace _02.FishingCompetition
{
	internal class Program
	{
		private const char EmptySymbol = '-';
		private const char Player = 'S';
		private const char Whirpool = 'W';

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

			bool fellInWhirpool = false;
			int fishCollected = 0;

			string command;
			while ((command = Console.ReadLine()) != "collect the nets")
			{
				(int rowChange, int colChange) = _directions[command];
				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChange;

				if (nextRow < 0) nextRow = n - 1;
				if (nextRow >= n) nextRow = 0;
				if (nextCol < 0) nextCol = n - 1;
				if (nextCol >= n) nextCol = 0;

				if (char.IsDigit(matrix[nextRow, nextCol]))
				{
					fishCollected += matrix[nextRow, nextCol] - '0';
					matrix[nextRow, nextCol] = EmptySymbol;
				}
				else if (matrix[nextRow, nextCol] == Whirpool)
				{
					fellInWhirpool = true;
					Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{nextRow},{nextCol}]");
					break;
                }

				matrix[playerRow, playerCol] = EmptySymbol;
				playerRow = nextRow;
				playerCol = nextCol;
				matrix[playerRow, playerCol] = Player;
			}

		    if (fishCollected >= 20 && fellInWhirpool == false)
			{
                Console.WriteLine("Success! You managed to reach the quota!");
                Console.WriteLine($"Amount of fish caught: {fishCollected} tons.");
				PrintMatrix(matrix);
            }
			else if (fishCollected < 20 && fellInWhirpool == false)
			{
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fishCollected} tons of fish more.");
				if ( fishCollected > 0)
				{
                    Console.WriteLine($"Amount of fish caught: {fishCollected} tons.");
                }
				PrintMatrix(matrix);
            }
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