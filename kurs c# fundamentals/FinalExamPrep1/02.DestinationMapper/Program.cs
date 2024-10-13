
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"([=\/])([A-Z][A-Za-z]{2,})\1";

        MatchCollection matches = Regex.Matches(input, pattern);
        List<string> results = new List<string>();
        int count = 0;

        foreach (Match match in matches)
        {
            results.Add(match.Groups[2].Value);
            count += match.Groups[2].Value.Length;
        }


        Console.WriteLine($"Destinations: {String.Join(", ", results)}");
        Console.WriteLine($"Travel Points: {count}");
    }
}
