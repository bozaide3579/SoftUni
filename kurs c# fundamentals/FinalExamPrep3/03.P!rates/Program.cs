
internal class Program
{

	public class City
	{
		public string Name { get; set; }
		public int Population { get; set; }
		public int Gold { get; set; }

		public City(string name, int population, int gold)
		{
			Name = name;
			Population = population;
			Gold = gold;
		}
	}
	static void Main()
	{
		Dictionary<string, City> cities = new Dictionary<string, City>();

		string input;
		while ((input = Console.ReadLine()) != "Sail")
		{
			string[] splittedInput = input.Split("||");

			string name = splittedInput[0];
			int population = int.Parse(splittedInput[1]);
			int gold = int.Parse(splittedInput[2]);


			if (cities.ContainsKey(name))
			{
				cities[name].Population += population;
				cities[name].Gold += gold;
			}
			else
			{
				City city = new City(name, population, gold);
				cities.Add(name, city);
			}
		}

		while ((input = Console.ReadLine()) != "End")
		{
			string[] splittedInput = input.Split("=>");

			if (splittedInput[0] == "Plunder")
			{
				string name = splittedInput[1];
				int people = int.Parse(splittedInput[2]);
				int gold = int.Parse(splittedInput[3]);

				cities[name].Population -= people;
				cities[name].Gold -= gold;
				Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");

				if (cities[name].Gold == 0 || cities[name].Population == 0)
				{
					cities.Remove(name);
					Console.WriteLine($"{name} has been wiped off the map!");
				}

			}
			else if (splittedInput[0] == "Prosper")
			{
				string name = splittedInput[1];
				int gold = int.Parse(splittedInput[2]);

				if (gold < 0)
				{
					Console.WriteLine("Gold added cannot be a negative number!");
					continue;
				}
				else
				{
					cities[name].Gold += gold;
					Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cities[name].Gold} gold.");
				}
			}
		}


		if (cities.Count > 0)
		{
			Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
			foreach (var city in cities)
			{
				Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
			}
		}
		else
		{
			Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
		}

	}
}


/*
 
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End

 */

