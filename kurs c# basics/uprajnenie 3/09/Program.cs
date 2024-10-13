using System.Xml;

int days = int.Parse(Console.ReadLine());
string type  = Console.ReadLine();  
string review = Console.ReadLine();
double price = 0;
int nights = days - 1;

if (type == "room for one person")
{
    price = 18.00;
    if (days < 10)
    {
        price = 18.00;
    }
    else if (days >=10 && days <=15)
    {
        price = 18.00;
    }
    else if (days > 15)
    {
        price = 18.00;
    }
}
else if (type == "apartment")
{
    price = 25.00;
    if (days < 10)
    {
        price = price * 0.7;
    }
    else if (days >= 10 && days <= 15)
    {
        price = price * 0.65;
    }
    else if (days > 15)
    {
        price = price * 0.5;
    }
}
else if (type == "president apartment")
{
    price = 35.00;
    if (days < 10)
    {
        price = price * 0.9;
    }
    else if (days >= 10 && days <= 15)
    {
        price = price * 0.85;
    }
    else if (days > 15)
    {
        price = price * 0.8;
    }
}
double price2 = nights * price;
double price3 = 0;
if (review == "positive")
{
    price3 = price2 + price2 * 0.25;
}
else if (review == "negative")
{
    price3 = price2 * 0.9;
}

Console.WriteLine($"{price3:f2}");