using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(#|\|)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,5})\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            int calories = 0;

            foreach (Match match in matches)
            {
                calories += int.Parse(match.Groups[4].Value);
            }

            int count = 0;
            while (calories >= 2000)
            {
                calories -= 2000;
                count++;
            }

            Console.WriteLine($"You have food to last you for: {count} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
            }

        }
    }
}