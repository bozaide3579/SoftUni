namespace _01.TempleOfDoom
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> tools = new Queue<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));
			Stack<int> substance = new Stack<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));
			List<int> challenges = new List<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));

			while (substance.Count > 0 && challenges.Count > 0)
			{
				int currentTool = tools.Dequeue();
				int currentSubstance = substance.Pop();

				if (challenges.Contains(currentTool * currentSubstance))
				{
					challenges.Remove(currentTool * currentSubstance);
				}
				else
				{
					tools.Enqueue(currentTool + 1);
					if (currentSubstance - 1 > 0)
					{
						substance.Push(currentSubstance - 1);
					}
				}
			}

			if (substance.Count == 0 && challenges.Count > 0)
			{
				Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
			}
			else
			{
				Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
			}

			if (tools.Count > 0)
			{
				Console.WriteLine($"Tools: {string.Join(", ", tools)}");
			}
			if (substance.Count > 0)
			{
				Console.WriteLine($"Substances: {string.Join(", ", substance)}");
			}
			if (challenges.Count > 0)
			{
				Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
			}
		}
	}
}

/*
2 4 6 8
11 3 5 7 9
24 28 18 30



13 7 4 22 11 15 20
3 2 1
12 10 5

*/

