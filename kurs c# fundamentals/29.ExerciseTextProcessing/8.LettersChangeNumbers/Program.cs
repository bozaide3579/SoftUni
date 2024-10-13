
internal class Program
{
    static void Main(string[] args)
    {
        string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        decimal totalSum = 0;

         
        foreach (string str in strings)
        {
            char letterBefore = str[0];
            char letterAfter = str[str.Length - 1];
            int number = int.Parse(str.Substring(1, str.Length - 2));

            int position = 0;
            decimal result = 0;

            if (char.IsUpper(letterBefore))
            {
                position = (int)(letterBefore - 'A' + 1);
                result = number / (decimal)position;
            }
            else if (char.IsLower(letterBefore))
            {
                position = (int)(letterBefore - 'a' + 1);
                result = number * (decimal)position;
            }

            if (char.IsUpper(letterAfter))
            {
                position = (int)(letterAfter - 'A' + 1);
                result -= position;
            }
            else if (char.IsLower(letterAfter))
            {
                position = (int)(letterAfter - 'a' + 1);
                result += position;
            }

            totalSum += result;  
        }

        Console.WriteLine($"{totalSum:F2}");
    }
}
