double filmBudget = double.Parse(Console.ReadLine());

double decor = filmBudget * 0.1;

int people = int.Parse(Console.ReadLine());
double peopleOutfit = double.Parse(Console.ReadLine());
double peopleP = people * peopleOutfit;
if (people > 150)
{
    peopleP = peopleP * 0.9;
}

double moneySpent = decor + peopleP;

if (filmBudget< moneySpent)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {moneySpent - filmBudget:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {filmBudget - moneySpent:f2} leva left.");
}