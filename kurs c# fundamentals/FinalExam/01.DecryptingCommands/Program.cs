
using System.Text;

internal class Program
{

	static bool IsIndexValid(int index, int length)
	{
		if (index >= 0 && index < length)
		{
			return true;
		}
		return false;
	}

	static void Main()
	{
		string text = Console.ReadLine();
		StringBuilder result = new StringBuilder(text);

		string input;
		while ((input = Console.ReadLine()) != "Finish")
		{
			string[] splittedInput = input.Split(" ");

			if (splittedInput[0] == "Replace")
			{
				string currentChar = splittedInput[1];
				string newChar = splittedInput[2];

				result.Replace(currentChar, newChar);
                Console.WriteLine(result.ToString());
            }
			else if (splittedInput[0] == "Cut")
			{
				int start = int.Parse(splittedInput[1]);
				int end = int.Parse(splittedInput[2]);

				if (IsIndexValid(start, result.Length) && IsIndexValid(end, result.Length) && start <= end)
				{
					result.Remove(start, end - start + 1);
					Console.WriteLine(result.ToString());
				}
				else
				{
                    Console.WriteLine("Invalid indices!");
                }

			}
			else if (splittedInput[0] == "Make")
			{
				if (splittedInput[1] == "Upper")
				{
					for (int i = 0; i < result.Length; i++)
					{
						result[i] = char.ToUpper(result[i]);
					}
					Console.WriteLine(result.ToString());
				}
				else if (splittedInput[1] == "Lower")
				{
					for (int i = 0; i < result.Length; i++)
					{
						result[i] = char.ToLower(result[i]);
					}
					Console.WriteLine(result.ToString());
				}
			}
			else if (splittedInput[0] == "Check")
			{
				string check = splittedInput[1];

				if (result.ToString().Contains(check))
				{
                    Console.WriteLine($"Message contains {check}");
				}
				else
				{
                    Console.WriteLine($"Message doesn't contain {check}");
                }
			}
			else if (splittedInput[0] == "Sum")
			{
				int start = int.Parse(splittedInput[1]);
				int end = int.Parse(splittedInput[2]);

				if (IsIndexValid(start, result.Length) && IsIndexValid(end, result.Length) && start <= end)
				{
					int sum = 0;
					for (int i = start; i <= end; i++)
					{
						sum += result[i];
					}

                    Console.WriteLine(sum);
                }
				else
				{
                    Console.WriteLine("Invalid indices!");
                }
			}
		}
	}
}

