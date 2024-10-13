
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
string destination=string.Empty;
double price = 0;
string type = string.Empty;

if (budget <= 100)
{
    destination = "Bulgaria";
    if (season == "summer")
    {
        price = budget * 0.30;
        type = "Camp";
    }
    if (season == "winter")
    {
        price = budget * 0.70;
        type = "Hotel";
    }
}
else if (budget <= 1000)
{
    destination = "Balkans";
    if (season == "summer")
    {
        price = budget * 0.40;
        type = "Camp";
    }
    if (season == "winter")
    {
        price = budget * 0.80;
        type = "Hotel";
    }
}
else if (budget > 1000)
{
    destination = "Europe";
    type = "Hotel";
    price = budget * 0.90;
}

Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{type} - {price:f2}");
    