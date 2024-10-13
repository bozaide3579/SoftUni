


double neededMoney = double.Parse(Console.ReadLine()); 

string cocktailName = Console.ReadLine();

double allIncome = 0;


while (cocktailName != "Party!")
{
    int cocktailCount = int.Parse(Console.ReadLine());
    int cocktailPrice = cocktailName.Length;

    double currentIncome = cocktailPrice * cocktailCount;

    if (currentIncome % 2 == 1)
    {
        currentIncome *= 0.75;
    }


    allIncome += currentIncome;

    if (allIncome >= neededMoney)
    {
        Console.WriteLine("Target acquired.");
        break;
    }

    
   

    cocktailName = Console.ReadLine();
}

if (cocktailName == "Party!")
{
    Console.WriteLine($"We need {neededMoney - allIncome:f2} leva more.");
}

Console.WriteLine($"Club income - {allIncome:f2} leva.");