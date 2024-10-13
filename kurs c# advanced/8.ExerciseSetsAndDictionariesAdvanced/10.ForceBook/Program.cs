namespace _10.ForceBook
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, HashSet<string>> forceSides = new Dictionary<string, HashSet<string>>();
			Dictionary<string, string> userToSide = new Dictionary<string, string>();

			string input;
			while ((input = Console.ReadLine()) != "Lumpawaroo")
			{
				if (input.Contains("|"))
				{
					string[] parts = input.Split(" | ");
					string side = parts[0];
					string user = parts[1];

					if (!userToSide.ContainsKey(user))
					{
						if (!forceSides.ContainsKey(side))
						{
							forceSides[side] = new HashSet<string>();
						}
						forceSides[side].Add(user);
						userToSide[user] = side;
					}
				}
				else if (input.Contains("->"))
				{
					string[] parts = input.Split(" -> ");
					string user = parts[0];
					string side = parts[1];

					if (userToSide.ContainsKey(user))
					{
						string currentSide = userToSide[user];
						forceSides[currentSide].Remove(user);

						if (forceSides[currentSide].Count == 0)
						{
							forceSides.Remove(currentSide);
						}
					}

					if (!forceSides.ContainsKey(side))
					{
						forceSides[side] = new HashSet<string>();
					}

					forceSides[side].Add(user);
					userToSide[user] = side;

					Console.WriteLine($"{user} joins the {side} side!");
				}
			}

			foreach (var side in forceSides
				.OrderByDescending(s => s.Value.Count)
				.ThenBy(s => s.Key))
			{
				if (side.Value.Count > 0)
				{
					Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
					foreach (var user in side.Value.OrderBy(u => u))
					{
						Console.WriteLine($"! {user}");
					}
				}
			}
		}
	}
}
