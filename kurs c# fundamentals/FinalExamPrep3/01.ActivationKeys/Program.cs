
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

internal class Program
{
	static void Main()
	{
		string activationKey = Console.ReadLine();
		StringBuilder result = new StringBuilder(activationKey);

		string input;
		while((input = Console.ReadLine()) != "Generate")
		{
			string[] splittedInput = input.Split(">>>");

			if (splittedInput[0] == "Contains")
			{
				string substring = splittedInput[1];

				if (result.ToString().Contains(substring))
				{
                    Console.WriteLine($"{result.ToString()} contains {substring}");
                }
				else
				{
                    Console.WriteLine("Substring not found!");
                }
			}
			else if (splittedInput[0] == "Flip")
			{
				string upOrLow = splittedInput[1];
				int start = int.Parse(splittedInput[2]);
				int end = int.Parse(splittedInput[3]);

				if (upOrLow == "Upper")
				{
					string substring = result.ToString().Substring(start, end - start).ToUpper();
					result.Remove(start, end - start);
					result.Insert(start, substring);
					Console.WriteLine(result.ToString());
                }
				else if (upOrLow == "Lower")
				{
					string substring = result.ToString().Substring(start, end - start).ToLower();
					result.Remove(start, end - start);
					result.Insert(start, substring);
                    Console.WriteLine(result.ToString());
                }
			}
			else if (splittedInput[0] == "Slice")
			{
				int start = int.Parse(splittedInput[1]);
				int end = int.Parse(splittedInput[2]); 

				result.Remove(start, end - start);
				Console.WriteLine(result.ToString());
            }
		}

        Console.WriteLine($"Your activation key is: {result.ToString()}");
    }
}


/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate

 */