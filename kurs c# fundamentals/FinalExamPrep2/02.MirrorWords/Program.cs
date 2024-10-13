
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = @"([\@\#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";
        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> mirroredWords = new List<string>();

        int count = 0;

        if (matches.Count > 0)
        {
            Console.WriteLine($"{matches.Count} word pairs found!");
        }
        else
        {
            Console.WriteLine("No word pairs found!");
        }

        foreach (Match match in matches)
        {

            string firstGroup = match.Groups[2].Value;
            string secondGroup = match.Groups[3].Value;

            string reversed = new string(secondGroup.Reverse().ToArray());

            if (firstGroup == reversed)
            {
                mirroredWords.Add($"{firstGroup} <=> {secondGroup}");
            }

        }

        if (mirroredWords.Count > 0)
        {
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(String.Join(", ", mirroredWords));
        }
        else
        {
            Console.WriteLine("No mirror words!");
        }
    }
}
