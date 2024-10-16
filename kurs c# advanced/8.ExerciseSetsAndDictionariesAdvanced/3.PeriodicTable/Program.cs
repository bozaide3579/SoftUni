﻿namespace _3.PeriodicTable
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			SortedSet<string> elements = new SortedSet<string>();

			for (int i = 0; i < n; i++)
			{
				string[] currentElements = Console.ReadLine().Split();
				foreach (string element in currentElements)
				{
					elements.Add(element);
				}
			}

			Console.WriteLine(string.Join(" ", elements));
		}
	}
}
