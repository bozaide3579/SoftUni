class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());


        int sumResult = Sum(a, b);
        int subtractResult = Subtract(sumResult, c);

        Console.WriteLine(subtractResult);

    }

     static int Subtract(int sumResult, int c)
    {
        return sumResult - c;
    }

    static int Sum(int a, int b)
    {
        return a + b;
    }
}
