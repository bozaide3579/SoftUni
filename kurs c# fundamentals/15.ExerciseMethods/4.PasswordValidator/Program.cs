

using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        string pass = Console.ReadLine();

        bool lengthCheckPass = CheckLength(pass);

        bool symbolCheckPass = CheckSymbol(pass);

        bool digitsCheckPass = CheckDigits(pass);

        if (!lengthCheckPass)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }

        if (!symbolCheckPass)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }

        if (!digitsCheckPass)
        {
            Console.WriteLine("Password must have at least 2 digits");
        }

        if (lengthCheckPass && symbolCheckPass && digitsCheckPass)
        {
            Console.WriteLine("Password is valid");
        }
    }

    private static bool CheckDigits(string pass)
    {
        int count = 0;
        for (int i = 0; i < pass.Length; i++)
        {
            char symbol = pass[i];
            if (symbol >= 48 && symbol <= 57)
            {
                count++;
            }
        }

        if (count < 2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static bool CheckSymbol(string pass)
    {
        for (int i = 0; i < pass.Length; i++)
        {
            char symbol = pass[i];
            if (symbol >= 65 && symbol <= 90 ||
                symbol >= 97 && symbol <= 122 ||
                symbol >= 48 && symbol <= 57)
            {
                continue;
            }
            else
            {
                return false;
            }

        }
        return true;
    }

    private static bool CheckLength(string pass)
    {

        if (pass.Length <= 6 || pass.Length >= 10)
        {
            return false;

        }
        else
        {
            return true;
        }

    }
}