

double kg = double.Parse(Console.ReadLine());

string type = Console.ReadLine();   

int km = int.Parse(Console.ReadLine());

double price = 0;

if (type == "standard")
{
    if (kg < 1)
    {
        price = 0.03;
    }
    else if (kg <= 10)
    {
        price = 0.05;
    }
    else if (kg <= 40)
    {
        price = 0.10;
    }
    else if (kg <= 90)
    {
        price = 0.15;
    }
    else if (kg <= 150)
    {
        price = 0.20;
    }
}
else if (type == "express")
{
    if (kg < 1)
    {
        price = 0.03 + ((0.03 * 0.8) * kg);
    }
    else if (kg <= 10)
    {
        price = 0.05 + ((0.05 * 0.4) * kg);
    }
    else if (kg <= 40)
    {
        price = 0.10 + ((0.10 * 0.05)*kg);
    }
    else if (kg <= 90)
    {
        price = 0.15 + ((0.15 * 0.02)*kg);
    }
    else if (kg <= 150)
    {
        price = 0.20 + ((0.20 * 0.01) * kg);
    }
}

Console.WriteLine($"The delivery of your shipment with weight of {kg:f3} kg. would cost {price*km:f2} lv.");