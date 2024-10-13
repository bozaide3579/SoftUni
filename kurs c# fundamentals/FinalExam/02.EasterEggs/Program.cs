
using System.Text.RegularExpressions;

internal class Program
{
	static void Main()
	{
		string input = Console.ReadLine();
		string pattern = @"[@#]+([a-z]{3,})[@#]+[^a-z0-9]*\/+(\d+)\/+";

		MatchCollection matches = Regex.Matches(input, pattern);


		foreach (Match match in matches)
		{
            Console.WriteLine($"You found {match.Groups[2].Value} {match.Groups[1].Value} eggs!");
        }
	}
}

