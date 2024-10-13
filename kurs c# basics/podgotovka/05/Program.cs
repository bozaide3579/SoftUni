

double wantedIncome = double.Parse(Console.ReadLine());

string input = Console.ReadLine();
double allIncome = 0;

while (input != "Party!")
{
    int countOfDrinks = int.Parse(Console.ReadLine());
    int priceOfDrink = input.Length;

    double currentIncome = countOfDrinks * priceOfDrink;

    if (currentIncome % 2 == 1)
    {
        currentIncome *= 0.75;
    }

    allIncome += currentIncome;

    if (allIncome >= wantedIncome)
    {
        Console.WriteLine("Target acquired.");
        break;
    }

    


    input = Console.ReadLine();
}


if ( input == "Party!")
{
    Console.WriteLine($"We need {wantedIncome - allIncome:f2} leva more.");
}

Console.WriteLine($"Club income - {allIncome:f2} leva.");