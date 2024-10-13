class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());


        double aFactorial = PrintFactorial(a);
        double bFactorial = PrintFactorial(b);

        Console.WriteLine($"{aFactorial / bFactorial:f2}");
    }

    private static double PrintFactorial(int n)
    {
        double fact = 1;
        for (int i = 2; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }
}