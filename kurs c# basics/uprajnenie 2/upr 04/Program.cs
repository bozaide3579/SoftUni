double excursionPrice = double.Parse(Console.ReadLine());

int countOfPuzzles = int.Parse(Console.ReadLine());
int countOfDolls = int.Parse(Console.ReadLine());
int countOfBears = int.Parse(Console.ReadLine());   
int countOfMinions = int.Parse(Console.ReadLine());
int countOfTrucks = int.Parse(Console.ReadLine());

double puzzlePrice = 2.6 * countOfPuzzles;
double dollPrice = 3 * countOfDolls;
double bearPrice = 4.1 * countOfBears;
double minionPrice = 8.2 * countOfMinions;
double truckPrice = 2 * countOfTrucks;

double moneyFromToys = puzzlePrice + dollPrice + bearPrice + minionPrice + truckPrice;

double overallCount = countOfPuzzles + countOfBears + countOfMinions+ countOfTrucks+ countOfDolls;
if (overallCount >= 50)
{
    moneyFromToys = moneyFromToys * 0.75;
}

double rent = moneyFromToys * 0.1;

double overallIncome = moneyFromToys - rent;

if (overallIncome >= excursionPrice)
{
    Console.WriteLine($"Yes! {overallIncome - excursionPrice:f2} lv left.");
}
else
{
    Console.WriteLine($"Not enough money! {excursionPrice - overallIncome:f2} lv needed.");
}