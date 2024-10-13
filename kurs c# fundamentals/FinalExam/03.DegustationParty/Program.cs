
internal class Program
{
	static void Main(string[] args)
	{
		Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
		int count = 0;

		string input;
		while ((input = Console.ReadLine()) != "Stop")
		{
			string[] splittedInput = input.Split('-');
			string name = splittedInput[1];
			string meal = splittedInput[2];

			if (splittedInput[0] == "Like")
			{
				if (!guests.ContainsKey(name))
				{
					guests[name] = new List<string>();
				}
				
				if (!guests[name].Contains(meal))
				{
					guests[name].Add(meal);
				}
			}
			else if (splittedInput[0] == "Dislike")
			{
				if (guests.ContainsKey(name))
				{
					if (guests[name].Contains(meal))
					{
						guests[name].Remove(meal);
						count++;
                        Console.WriteLine($"{name} doesn't like the {meal}.");
                    }
					else
					{
                        Console.WriteLine($"{name} doesn't have the {meal} in his/her collection.");
                    }
				}
				else
				{
                    Console.WriteLine($"{name} is not at the party.");
                }
			}
		}

		foreach (var guest in guests)
		{
            Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
		}
        Console.WriteLine($"Unliked meals: {count}");
    }
}

