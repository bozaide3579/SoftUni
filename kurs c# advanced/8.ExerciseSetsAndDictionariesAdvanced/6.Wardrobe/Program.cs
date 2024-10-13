namespace _6.Wardrobe
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			Dictionary<string, Dictionary<string, int>> wardrobe =
				new Dictionary<string, Dictionary<string, int>>();

			for (int i = 0; i < n; i++)
			{
				string[] data = Console.ReadLine().Split(" -> ");
				string color = data[0];
				string[] clothes = data[1].Split(',');

				if (!wardrobe.ContainsKey(color))
				{
					wardrobe[color] = new Dictionary<string, int>();
				}

				foreach (string item in clothes)
				{
					if (!wardrobe[color].ContainsKey(item))
					{
						wardrobe[color][item] = 0;
					}
					wardrobe[color][item]++;
				}
			}

			string[] searchInfo = Console.ReadLine().Split();

			foreach (var (color, clothes) in wardrobe)
			{
				Console.WriteLine($"{color} clothes:");

				foreach (var (item, count) in clothes)
				{
					string suffix = string.Empty;
					if (color == searchInfo[0] && item == searchInfo[1])
					{
						suffix = " (found!)";
					}
					Console.WriteLine($"* {item} - {count}{suffix}");
				}
			}
		}
	}
}
