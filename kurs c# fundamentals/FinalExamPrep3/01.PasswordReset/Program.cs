
using System.Text;

internal class Program
{
	static void Main()
	{
		string input = Console.ReadLine();
		StringBuilder result = new StringBuilder(input);

		while ((input = Console.ReadLine()) != "Done")
		{
			string[] splittedInput = input.Split(" ");

			if (splittedInput[0] == "TakeOdd")
			{
				StringBuilder newResult = new StringBuilder();
				for (int i = 1; i < result.Length; i += 2)
				{
					newResult.Append(result[i]);
				}

				result = newResult;

				Console.WriteLine(result.ToString());
			}
			else if (splittedInput[0] == "Cut")
			{
				int index = int.Parse(splittedInput[1]);
				int length = int.Parse(splittedInput[2]);

				result.Remove(index, length);
				Console.WriteLine(result.ToString());
			}
			else if (splittedInput[0] == "Substitute")
			{
				string substr = splittedInput[1];
				string substitute = splittedInput[2];

				if (result.ToString().Contains(substr))
				{
					result.Replace(substr, substitute);
					Console.WriteLine(result.ToString());
				}
				else
				{
					Console.WriteLine("Nothing to replace!");
				}

			}
		}

		Console.WriteLine($"Your password is: {result.ToString()}");

	}
}

/*
 
Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr 
TakeOdd
Cut 15 3
Substitute :: -
Substitute | ^
Done

 */

