

string team = Console.ReadLine();

string souvenier = Console.ReadLine();   

int count = int.Parse(Console.ReadLine());

double price = 0;

if (team == "Argentina")
{
    if (souvenier == "flags")
    {
        price = 3.25;
    }
    else if (souvenier == "caps")
    {
        price = 7.20;
    }
    else if (souvenier == "posters")
    {
        price = 5.10;
    }
    else if (souvenier == "stickers")
    {
        price = 1.25;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
        return;
    }
}
else if (team == "Brazil")
{
    if (souvenier == "flags")
    {
        price = 4.20;
    }
    else if (souvenier == "caps")
    {
        price = 8.50;
    }
    else if (souvenier == "posters")
    {
        price = 5.35;
    }
    else if (souvenier == "stickers")
    {
        price = 1.20;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
        return;
    }
}
else if (team == "Croatia")
{
    if (souvenier == "flags")
    {
        price = 2.75;
    }
    else if (souvenier == "caps")
    {
        price = 6.90;
    }
    else if (souvenier == "posters")
    {
        price = 4.95;
    }
    else if (souvenier == "stickers")
    {
        price = 1.10;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
        return;
    }
}
else if (team == "Denmark")
{
    if (souvenier == "flags")
    {
        price = 3.10;
    }
    else if (souvenier == "caps")
    {
        price = 6.50;
    }
    else if (souvenier == "posters")
    {
        price = 4.80;
    }
    else if (souvenier == "stickers")
    {
        price = 0.90;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
        return;
    }
}
else
{
    Console.WriteLine("Invalid country!");
    return;
}


Console.WriteLine($"Pepi bought {count} {souvenier} of {team} for {price * count:f2} lv.");
