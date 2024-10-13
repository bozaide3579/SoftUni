double budget = double.Parse(Console.ReadLine());
string season  = Console.ReadLine();    
double numOfFisherman = double.Parse(Console.ReadLine());
double price = 0;

switch (season)
{
    case "Spring":
        price = 3000;
        break;
    case "Summer":
    case "Autumn":
        price = 4200;
        break;
    case "Winter":
        price = 2600;
        break;
    default:
        break;

}

if  (numOfFisherman <= 6)
{
    price *= 0.90;
}
else if (numOfFisherman <= 11)
{
    price *= 0.85;
}
else 
{
    price *= 0.75;
}

if (numOfFisherman%2==0 && season != "Autumn")
{
    price  *= 0.95;
}

if (budget >= price)
{
Console.WriteLine($"Yes! You have {budget - price:f2} leva left."); 
}
else
{
    Console.WriteLine($"Not enough money! You need {Math.Abs (budget - price):f2} leva.");
}