﻿namespace _04.ProductShop
{
	internal class Program
	{
		static void Main(string[] args)
		{



			Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();


			string input = Console.ReadLine();
			while (input != "Revision")
			{
				string[] splitted = input.Split(", ");
				string shop = splitted[0];
				string product = splitted[1];
				double price = double.Parse(splitted[2]);

				if (!shops.ContainsKey(shop))
				{
					shops.Add(shop, new Dictionary<string, double>());
				}

				shops[shop].Add(product, price);

				input = Console.ReadLine();
			}

			shops = shops.OrderBy(s => s.Key)
				.ToDictionary(s => s.Key, s => s.Value);

			foreach (var (shop, products) in shops)
			{
				Console.WriteLine($"{shop}->");

				foreach (var (product, price) in products)
				{
					Console.WriteLine($"Product: {product}, Price: {price}");
				}
			}
		}
	}
}
