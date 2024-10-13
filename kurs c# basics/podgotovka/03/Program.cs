string place  = Console.ReadLine();

string type= Console.ReadLine();    

string vip = Console.ReadLine();

int days = int.Parse(Console.ReadLine());

double price = 0;

if (days <= 0)
{
    Console.WriteLine("Days must be positive number!");
    return;
}
if (days > 7)
{
    days--;
}

if (place == "Bansko" || place == "Borovets")
{
    if (type == "noEquipment")
    {
        price = 80;
        if (vip == "yes")
        {
            price = price * 0.95;
        }
    }
    else if (type == "withEquipment")
    {
        price = 100;
        if (vip == "yes")
        {
            price *= 0.9;
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
        return;
    }
}
else if (place == "Varna" || place == "Burgas")
{
    if (type == "noBreakfast")
    {
        price = 100;
        if (vip == "yes")
        {
            price *= 0.93;
        }
        
    }
    else if (type == "withBreakfast")
    {
        price = 130;
        if (vip == "yes")
        {
            price *= 0.88;
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
        return;
    }
}
else
{
    Console.WriteLine("Invalid input!");
    return;
}





Console.WriteLine($"The price is {price * days:f2}lv! Have a nice time!");