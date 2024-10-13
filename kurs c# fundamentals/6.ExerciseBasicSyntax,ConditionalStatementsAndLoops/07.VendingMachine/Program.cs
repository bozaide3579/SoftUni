

decimal balance = 0;

string input;
while ((input = Console.ReadLine())  != "Start")
{
    decimal coin = decimal.Parse(input);
    
    if (coin == 0.1m ||
        coin == 0.2m ||
        coin == 0.5m ||
        coin == 1m ||
        coin == 2m)
    {
        balance += coin;
    }
    else
    {
        Console.WriteLine($"Cannot accept {input}");
    }

}

while ((input = Console.ReadLine()) != "End")
{
    if (input == "Nuts")
    {
        if (balance >= 2.0m)
        {
            balance -= 2.0m;
            Console.WriteLine($"Purchased nuts");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Water")
    {
        if (balance >= 0.7m)
        {
            balance -= 0.7m;
            Console.WriteLine($"Purchased water");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Crisps")
    {
        if (balance >= 1.5m)
        {
            balance -= 1.5m;
            Console.WriteLine($"Purchased crisps");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Soda")
    {
        if (balance >= 0.8m)
        {
            balance -= 0.8m;
            Console.WriteLine($"Purchased soda");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Coke")
    {
        if (balance >= 1.0m)
        {
            balance -= 1.0m;
            Console.WriteLine($"Purchased coke");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else
    {

        Console.WriteLine("Invalid product");
    }

}

Console.WriteLine($"Change: {balance:f2}");