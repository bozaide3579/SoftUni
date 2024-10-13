
using System.Text;

internal class Program
{

    static bool IsIndexValid(int index, int length)
    {
        if (index >= 0 && index <= length)
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
        while ((input = Console.ReadLine()) != "Travel")
        {
            string[] splittedInput = input.Split(':');

            if (splittedInput[0].Contains("Add Stop"))
            {
                int index = int.Parse(splittedInput[1]);
                string stringToAdd = splittedInput[2];

                if (IsIndexValid(index, result.Length))
                {
                    result.Insert(index, stringToAdd);
                }
            }
            else if (splittedInput[0].Contains("Remove Stop"))
            {
                int start = int.Parse(splittedInput[1]);
                int end = int.Parse(splittedInput[2]);

                if (IsIndexValid(start, result.Length) && IsIndexValid(end, result.Length) && start <= end && end < result.Length)
                {
                    result.Remove(start, end - start + 1);
                }
            }
            else if (splittedInput[0].Contains("Switch"))
            {
                string oldString = splittedInput[1];
                string newString = splittedInput[2];  

                result.Replace(oldString, newString);
            }

            Console.WriteLine(result);
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {result}");
    }
}
