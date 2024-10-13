
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

internal class Program
{
	static void Main()
	{
		string text = Console.ReadLine();



		long coolThreshold = 1;
		foreach (char ch in text)
		{
			if (char.IsDigit(ch))
			{
				coolThreshold *= (ch - '0');
			}
		}

		string pattern = @"(\:\:|\*\*)([A-Z][a-z]{2,})\1";
		MatchCollection emojis = Regex.Matches(text, pattern);

		List<string> coolEmojis = new List<string>();

		foreach (Match match in emojis) 
		{ 
			string emoji = match.Value;
			string innerText = match.Groups[2].Value;
			int coolness = innerText.Sum(c => (int)c);

			if (coolness > coolThreshold) 
			{ 
				coolEmojis.Add(emoji);
			}
		}

		Console.WriteLine($"Cool threshold: {coolThreshold}");
        Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

		foreach (var coolEmoji in coolEmojis)
		{
            Console.WriteLine(coolEmoji);
        }


	}
}

