using System;

class CounterTerroristGame
{
	static void Main()
	{
		// Read dimensions
		var dimensions = Console.ReadLine().Split(", ");
		int N = int.Parse(dimensions[0]);
		int M = int.Parse(dimensions[1]);

		// Initialize the map
		char[,] map = new char[N, M];
		int ctRow = -1, ctCol = -1;
		int bombRow = -1, bombCol = -1;

		// Read map layout
		for (int i = 0; i < N; i++)
		{
			string line = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				map[i, j] = line[j];
				if (map[i, j] == 'C')
				{
					ctRow = i;
					ctCol = j;
				}
				else if (map[i, j] == 'B')
				{
					bombRow = i;
					bombCol = j;
				}
			}
		}

		// Read commands
		string command;
		int time = 0;
		bool bombDefused = false;

		while (time < 16 && (command = Console.ReadLine()) != null)
		{
			time++;
			switch (command)
			{
				case "left":
					if (ctCol > 0) ctCol--;
					break;
				case "right":
					if (ctCol < M - 1) ctCol++;
					break;
				case "up":
					if (ctRow > 0) ctRow--;
					break;
				case "down":
					if (ctRow < N - 1) ctRow++;
					break;
				case "defuse":
					if (ctRow == bombRow && ctCol == bombCol)
					{
						time += 4; // Defuse time
						if (time < 16)
						{
							map[bombRow, bombCol] = 'D'; // Bomb defused
							bombDefused = true;
						}
						else
						{
							map[bombRow, bombCol] = 'X'; // Bomb exploded
						}
					}
					else
					{
						time += 2; // Skip defuse time
					}
					break;
			}

			// Check for interactions
			if (map[ctRow, ctCol] == 'T')
			{
				Console.WriteLine("Terrorists win!");
				map[ctRow, ctCol] = '*'; // Mark position as empty
				PrintFinalMap(map, ctRow, ctCol);
				return;
			}
			else if (map[ctRow, ctCol] == 'B')
			{
				if (bombDefused)
				{
					Console.WriteLine("Counter-terrorist wins!");
					Console.WriteLine($"Bomb has been defused: {16 - time} second/s remaining.");
				}
				else
				{
					map[ctRow, ctCol] = 'X'; // Bomb exploded
					Console.WriteLine("Terrorists win!");
				}
				PrintFinalMap(map, ctRow, ctCol);
				return;
			}
		}

		// If time runs out
		if (time >= 16)
		{
			Console.WriteLine("Terrorists win!");
			Console.WriteLine("Bomb was not defused successfully!");
			Console.WriteLine($"Time needed: {time} second/s.");
		}

		PrintFinalMap(map, ctRow, ctCol);
	}

	static void PrintFinalMap(char[,] map, int ctRow, int ctCol)
	{
		for (int i = 0; i < map.GetLength(0); i++)
		{
			for (int j = 0; j < map.GetLength(1); j++)
			{
				if (i == ctRow && j == ctCol)
					Console.Write('C');
				else
					Console.Write(map[i, j]);
			}
			Console.WriteLine();
		}
	}
}