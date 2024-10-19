using System.Reflection;

namespace _01.ApocalypsePreparation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> textiles = new Queue<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));
			Stack<int> medicaments = new Stack<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));

			Dictionary<string, int> healingItems = new Dictionary<string, int>
			{
				{ "Patch", 0 },
				{ "Bandage", 0 },
				{ "MedKit", 0 }
			};

			while (textiles.Count > 0 && medicaments.Count > 0)
			{
				int currentTextile = textiles.Dequeue();
				int currentMedicament = medicaments.Pop();

				int sum = currentTextile + currentMedicament;

				if (sum == 30)
				{
					healingItems["Patch"]++;
				}
				else if (sum == 40)
				{
					healingItems["Bandage"]++;
				}
				else if (sum == 100)
				{
					healingItems["MedKit"]++;
				}
				else if (sum > 100)
				{
					healingItems["MedKit"]++;
					int additive = sum - 100;

					if ( medicaments.Count > 0)
					{
						int updated = medicaments.Pop() + additive;
						medicaments.Push(updated);
					}
					else
					{
						medicaments.Push(additive);
					}
				}
				else
				{
					currentMedicament += 10;
					medicaments.Push(currentMedicament);
				}
			}

			if (textiles.Count == 0 && medicaments.Count > 0)
			{
				Console.WriteLine("Textiles are empty.");
			}
			else if (medicaments.Count == 0 && textiles.Count > 0)
			{
				Console.WriteLine("Medicaments are empty.");
			}
			else
			{
				Console.WriteLine("Textiles and medicaments are both empty.");
			}

			foreach (var item in healingItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
			{
				if (item.Value > 0)
				{
					Console.WriteLine($"{item.Key} - {item.Value}");
				}
			}

			if (medicaments.Count > 0)
			{
				Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
			}

			if (textiles.Count > 0)
			{
				Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
			}
		}
	}
}


/*
20 10 40 70 20
50 10 30 20 80

*/