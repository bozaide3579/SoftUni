internal class Program
{
    static void Main(string[] args)
    {
        int numOfCities = int.Parse(Console.ReadLine());
        decimal total = 0;

        for (int i = 1; i <= numOfCities; i++)
        {
            string cityName = Console.ReadLine();
            decimal moneyEarned = decimal.Parse(Console.ReadLine());
            decimal expences = decimal.Parse(Console.ReadLine());

            decimal profit = moneyEarned - expences;

            if (i % 3 == 0 && i % 5 != 0)
            {
                decimal special = expences * 0.5m;
                profit -= special;

            }
            else if (i % 5 == 0)
            {
                decimal rain = moneyEarned * 0.1m;
                profit -= rain;
            }

            Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
            total += profit;
        }

        Console.WriteLine($"Burger Bus total profit: {total:f2} leva.");
    }
}
