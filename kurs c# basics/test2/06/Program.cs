

using System.Security.Cryptography;

int locations = int.Parse(Console.ReadLine());

for  (int i = 0; i < locations; i++)
{
    double expectedGold = double.Parse(Console.ReadLine());  
    int days = int.Parse(Console.ReadLine());

    double allGold = 0;

    int daysPassed = 0;

    while (daysPassed < days)
    {
        double goldMined = double.Parse(Console.ReadLine());
        allGold += goldMined;
        daysPassed++;
    }

    double avgGold = allGold / daysPassed;

    if (avgGold >= expectedGold)
    {
        Console.WriteLine($"Good job! Average gold per day: {avgGold:f2}.");
    }
    else
    {
        Console.WriteLine($"You need {expectedGold-avgGold:f2} gold.");
    }
}