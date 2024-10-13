using System.Diagnostics;
using System.Xml.Schema;

int numOfPeople = int.Parse(Console.ReadLine());
string type = Console.ReadLine();
string day = Console.ReadLine();

decimal totalCost = 0;
decimal pricePerPerson = 0;


switch (type)
{
    case "Students":
        switch (day)
        {
            case "Friday":
                pricePerPerson = 8.45m;
                break;
            case "Saturday":
                pricePerPerson = 9.80m;
                break;
            case "Sunday":
                pricePerPerson = 10.46m;
                break;

        }
        break;
    case "Business":
        switch (day)
        {
            case "Friday":
                pricePerPerson = 10.90m;
                break;
            case "Saturday":
                pricePerPerson = 15.60m;
                break;
            case "Sunday":
                pricePerPerson = 16m;
                break;

        }
        break;
    case "Regular":
        switch (day)
        {
            case "Friday":
                pricePerPerson = 15m;
                break;
            case "Saturday":
                pricePerPerson = 20m;
                break;
            case "Sunday":
                pricePerPerson = 22.50m;
                break;

        }
        break;
}

totalCost = pricePerPerson * numOfPeople;

if (numOfPeople >= 30 && type == "Students")
{
    totalCost = totalCost * 0.85m;
}
else if (numOfPeople >= 100 && type == "Business")
{
    totalCost = totalCost - (10 * pricePerPerson);
}
else if (numOfPeople >= 10 && numOfPeople <= 20 && type == "Regular")
{
    totalCost = totalCost * 0.95m;
}

Console.WriteLine($"Total price: {totalCost:f2}");
