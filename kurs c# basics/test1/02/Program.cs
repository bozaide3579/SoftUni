

double dailyMoney = double.Parse(Console.ReadLine());

double salesMoney = double.Parse(Console.ReadLine());   

double expences = double.Parse(Console.ReadLine());

double presentPrice =  double.Parse(Console.ReadLine());

double savedDaily = dailyMoney * 5;

double savedSales = salesMoney * 5;

double allmoney = savedDaily + savedSales - expences;

if (allmoney >= presentPrice)
{
    Console.WriteLine($"Profit: {allmoney:f2} BGN, the gift has been purchased.");
}
else
{
    Console.WriteLine($"Insufficient money: {presentPrice - allmoney:f2} BGN.");
}