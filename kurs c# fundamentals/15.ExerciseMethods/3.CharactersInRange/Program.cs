
class Program
{
    static void Main()
    {
        char a = char.Parse(Console.ReadLine());
        char b = char.Parse(Console.ReadLine());


        PrintNumbersInRange(a, b);
    }

    static void PrintNumbersInRange(char a, char b)
    {
        if (a > b)
        {
            char temp = a;
            a = b;
            b = temp;
        }


        for (int i = a + 1; i < b; i++)
        {
            Console.Write($"{(char)i} ");
        }
        Console.WriteLine();
    }
}







