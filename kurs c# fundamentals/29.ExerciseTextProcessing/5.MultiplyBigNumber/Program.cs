
using System.Net.Http.Headers;

internal class Program
{
    static void Main()
    {
        string bigNum = Console.ReadLine();
        string smallNum = Console.ReadLine();

        string result = Multiply(bigNum, smallNum);

        Console.WriteLine(result);
    }

    private static string Multiply(string bigNum, string smallNum)
    {
        if (bigNum == "0" || smallNum == "0")
        {
            return "0";
        }

        int carry = 0;
        char[] resultChars = new char[bigNum.Length + 1];
        int multiplier = int.Parse(smallNum);

        for (int i = bigNum.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(bigNum[i].ToString());

            int result = digit * multiplier + carry;
            resultChars[i + 1] = Charosvane(result % 10);


            carry = result / 10;
        }

        if (carry > 0)
        {
            resultChars[0] = Charosvane(carry);
        }

        return new string(resultChars).TrimStart('\0');
    }

    static char Charosvane(int digit)
    {
        return (char)(digit + 48);
    }
}
