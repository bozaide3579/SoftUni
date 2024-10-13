
using System.Runtime.CompilerServices;
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
        string username = Console.ReadLine();
        StringBuilder sb = new StringBuilder(username);

        string input;
        while ((input = Console.ReadLine()) != "Registration")
        {
            string[] splittedInput = input.Split();

            if (splittedInput[0] == "Letters")
            {
                if (splittedInput[1] == "Lower")
                {
                    sb = new StringBuilder(sb.ToString().ToLower());
                    Console.WriteLine(sb);
                }
                else if (splittedInput[1] == "Upper")
                {
                    sb = new StringBuilder(sb.ToString().ToUpper());
                    Console.WriteLine(sb);
                }

            }
            else if (splittedInput[0] == "Reverse")
            {
                int start = int.Parse(splittedInput[1]);
                int end = int.Parse(splittedInput[2]);

                if (IsIndexValid(start, sb.Length) && IsIndexValid(end, sb.Length) && start <= end)
                {
                    string substring = sb.ToString().Substring(start, end - start + 1);

                    string reversedSub = new string(substring.ToCharArray().Reverse().ToArray());

                    Console.WriteLine(reversedSub);
                }

            }
            else if (splittedInput[0] == "Substring")
            {
                string substring = splittedInput[1];


                if (sb.ToString().Contains(substring))
                {
                    int startIndex = sb.ToString().IndexOf(substring);

                    sb.Remove(startIndex, substring.Length);

                    Console.WriteLine(sb);
                }
                else
                {
                    Console.WriteLine($"The username {sb} doesn't contain {substring}.");
                }
            }
            else if (splittedInput[0] == "Replace")
            {
                char charToReplace = char.Parse(splittedInput[1]);

                sb.Replace(charToReplace, '-');

                Console.WriteLine(sb);
            }
            else if (splittedInput[0] == "IsValid")
            {
                char validChar = char.Parse(splittedInput[1]);

                if (sb.ToString().Contains(validChar))
                {
                    Console.WriteLine("Valid username.");
                }
                else
                {
                    Console.WriteLine($"{validChar} must be contained in your username.");
                }
            }
        }
    }
}
