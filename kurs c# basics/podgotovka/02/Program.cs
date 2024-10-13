

double budget = double.Parse(Console.ReadLine());

double liters = double.Parse(Console.ReadLine());   

string day = Console.ReadLine();

double fuel = 2.10 * liters;

double guide = 100;

double finalprice = fuel + guide;

if (day == "Saturday")
{
    finalprice *= 0.9;
}
else if (day =="Sunday")
{
    finalprice *= 0.8;
}

if (budget>= finalprice)
{
    Console.WriteLine($"Safari time! Money left: {budget - finalprice:f2} lv. ");
}
else
{
    Console.WriteLine($"Not enough money! Money needed: {finalprice - budget:f2} lv.");
}