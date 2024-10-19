namespace _01.OffroadChallenge
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> fuel = new Stack<int>(Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));
			Queue<int> consumption = new Queue<int>(Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));
			Queue<int> nededFuel = new Queue<int>(Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));


			List<int> reachedList = new List<int>();	
			bool end = false;
			int reached = 0;
			while (fuel.Count > 0 && consumption.Count > 0 && nededFuel.Count > 0 && !end)
			{
				int currentFuel = fuel.Pop();
				int currentConsumption = consumption.Dequeue();
				int currentNededFuel = nededFuel.Dequeue();

				if (currentFuel - currentConsumption >= currentNededFuel)
				{
					reached++;
					reachedList.Add(reached);
                    Console.WriteLine($"John has reached: Altitude {reached}");
                }
				else
				{
                    Console.WriteLine($"John did not reach: Altitude {reached + 1}");
                    end = true;
				}

			}

			if (end == true)
			{
				if (reached > 0)
				{
                    Console.WriteLine($"John failed to reach the top.");
					Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedList.Select(a => $"Altitude {a}"))}");

				}
				else
				{
                    Console.WriteLine("John failed to reach the top.");
					Console.WriteLine("John didn't reach any altitude.");
                }
			}
			else
			{
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }

		}
	}
}
