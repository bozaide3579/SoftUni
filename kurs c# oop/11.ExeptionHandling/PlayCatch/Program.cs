using System;

namespace PlayCatch
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int exeptions = 0;

			while (exeptions < 3)
			{
				string[] commands = Console.ReadLine().Split(" ");
				string command = commands[0];

				try
				{
					if (command == "Replace")
					{
						int index = int.Parse(commands[1]);
						int element = int.Parse(commands[2]);

						numbers[index] = element;
					}
					else if (command == "Print")
					{
						int startIndex = int.Parse(commands[1]);
						int endIndex = int.Parse(commands[2]);

						if (startIndex < 0 || endIndex >= numbers.Length || startIndex > endIndex)
						{
							throw new IndexOutOfRangeException();
						}

						for (int i = startIndex; i <= endIndex; i++)
						{
							Console.Write(numbers[i]);
							if (i < endIndex)
							{
								Console.Write(", ");
							}
						}
                        Console.WriteLine();
                    }
					else if (command == "Show")
					{
						int index = int.Parse(commands[1]);

						Console.WriteLine(numbers[index]);
					}
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("The index does not exist!");
					exeptions++;
				}
				catch (FormatException)
				{
					Console.WriteLine("The variable is not in the correct format!");
					exeptions++;
				}

			}

			Console.WriteLine(string.Join(", ", numbers));

		}
	}
}
