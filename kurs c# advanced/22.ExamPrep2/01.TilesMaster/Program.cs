using System.ComponentModel;
using System.Reflection;

namespace _01.TilesMaster
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> white = new Stack<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));
			Queue<int> gray = new Queue<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));

			Dictionary<string, int> locations = new Dictionary<string, int>
			{
				{"Sink", 0},
				{"Oven", 0},
				{"Countertop", 0 },
				{"Wall", 0},
				{"Floor", 0}
			};

			while (gray.Count > 0 && white.Count > 0)
			{
				int currentGray = gray.Dequeue();
				int currentWhite = white.Pop();

				if (currentGray == currentWhite)
				{
					int sum = currentWhite + currentGray;

					if (sum == 40)
					{
						locations["Sink"]++;
					}
					else if (sum == 50)
					{
						locations["Oven"]++;
					}
					else if (sum == 60)
					{
						locations["Countertop"]++;
					}
					else if (sum == 70)
					{
						locations["Wall"]++;
					}
					else
					{
						locations["Floor"]++;
					}
				}
				else
				{
					currentWhite = currentWhite / 2;
					white.Push(currentWhite);
					gray.Enqueue(currentGray);
				}
			}

			if (white.Count <= 0)
			{
				Console.WriteLine("White tiles left: none");
			}
			else
			{
				Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
			}

			if (gray.Count <= 0)
			{
				Console.WriteLine("Grey tiles left: none");
			}
			else
			{
				Console.WriteLine($"Grey tiles left: {string.Join(", ", gray)}");
			}


			foreach (var location in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
			{
				if (location.Value > 0)
				{
					Console.WriteLine($"{location.Key}: {location.Value}");
				}
			}
		}
	}
}

/*
20 30 6 10 10
10 20 5 6 30
*/