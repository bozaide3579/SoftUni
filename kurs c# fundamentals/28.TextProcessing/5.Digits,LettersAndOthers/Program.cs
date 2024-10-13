
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        StringBuilder digits = new StringBuilder();
        StringBuilder letters = new StringBuilder();
        StringBuilder nums = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsDigit(c))
            {
                digits.Append(c);
            }
            else if (char.IsLetter(c))
            {
                letters.Append(c);
            }
            else
            {
                nums.Append(c);
            }


        }

        Console.WriteLine(digits.ToString());
        Console.WriteLine(letters.ToString());
        Console.WriteLine(nums.ToString());
    }
}
