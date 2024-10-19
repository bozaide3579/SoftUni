using System.Numerics;

namespace _02.MouseInTheKitchen
{
	internal class Program
	{

		private const char Mouse = 'M';
		private const char Cheese = 'C';
		private const char Empty = '*';
		private const char Wall = '@';
		private const char Trap = 'T';

		private static readonly Dictionary<string, (int RowChange, int ColChange)> _directions
			= new Dictionary<string, (int RowChange, int ColChange)>
			{
				["up"] = (-1, 0),
				["right"] = (0, 1),
				["down"] = (1, 0),
				["left"] = (0, -1)
			};

		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

			int n = input[0];
			int m = input[1];

			char[,] matrix = new char[n, m];
			for (int i = 0; i < n; i++)
			{
				string data = Console.ReadLine();

				for (int j = 0; j < m; j++)
				{
					matrix[i, j] = data[j];
				}
			}

			(int playerRow, int playerCol) = FindMouse(matrix);

			bool gameEnded = false;

			string command;
			while (!gameEnded && (command = Console.ReadLine()) != "danger")
			{
				(int rowChange, int colChange) = _directions[command];
				int nextRow = playerRow + rowChange;
				int nextCol = playerCol + colChange;

				if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m)
				{
					Console.WriteLine("No more cheese for tonight!");
					gameEnded = true;
				}
				else if (matrix[nextRow, nextCol] == Cheese)
				{
					matrix[playerRow, playerCol] = Empty;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Mouse;

					if (!ContainsCheese(matrix))
					{
						Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
						gameEnded = true;
					}
				}
				else if (matrix[nextRow, nextCol] == Trap)
				{
					matrix[playerRow, playerCol] = Empty;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Mouse;
					Console.WriteLine("Mouse is trapped!");
					gameEnded = true;
				}
				else if (matrix[nextRow, nextCol] == Wall)
				{
					continue;
				}
				else if (matrix[nextRow, nextCol] == Empty)
				{
					matrix[playerRow, playerCol] = Empty;
					playerRow = nextRow;
					playerCol = nextCol;
					matrix[playerRow, playerCol] = Mouse;
				}
			}

			if (!gameEnded)
			{
				Console.WriteLine("Mouse will come back later!");
			}

			PrintMatrix(matrix);
        }

		private static (int Row, int Col) FindMouse(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == 'M')
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

		private static bool ContainsCheese(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == Cheese)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}




/*
 
5,5
**M**
T@@**
CC@**
**@@*
**CC*
left



*/