string fruit = Console.ReadLine();
string day = Console.ReadLine();    
double quantity = double.Parse(Console.ReadLine());

double bananaP = 2.50;
double appleP = 1.20;
double orangeP = 0.85;
double grapefruitP = 1.45;
double kiwiP = 2.70;
double pineappleP = 5.50;
double grapesP = 3.85;


if (fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit" || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes")
{
    if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
    {
        if (fruit == "banana")
        {
            Console.WriteLine($"{bananaP * quantity:f2}");
        }
        if (fruit == "apple")
        {
            Console.WriteLine($"{appleP * quantity:f2}");
        }
        if (fruit =="orange")
        {
            Console.WriteLine($"{orangeP * quantity:f2}");
        }
        if (fruit == "grapefruit")
        {
            Console.WriteLine($"{grapefruitP * quantity:f2}");
        }
        if (fruit == "kiwi")
        {
            Console.WriteLine($"{kiwiP * quantity:f2}");
        }
        if (fruit == "pineapple")
        {
            Console.WriteLine($"{pineappleP * quantity:f2}");
        }
        if (fruit == "grapes")
        {
            Console.WriteLine($"{grapesP * quantity:f2} ");
        }
           
    }
    else if (day == "Saturday" || day == "Sunday")
    {
        if (fruit == "banana")
        {
            Console.WriteLine($"{(bananaP+0.20) * quantity:f2}");
        }
        if (fruit == "apple")
        {
            Console.WriteLine($"{(appleP + 0.05) * quantity:f2}");
        }
        if (fruit == "orange")
        {
            Console.WriteLine($"{(orangeP + 0.05) * quantity:f2}");
        }
        if (fruit == "grapefruit")
        {
            Console.WriteLine($"{(grapefruitP + 0.15) * quantity:f2}");
        }
        if (fruit == "kiwi")
        {
            Console.WriteLine($"{(kiwiP + 0.30) * quantity:f2}");
        }
        if (fruit == "pineapple")
        {
            Console.WriteLine($"{(pineappleP + 0.10) * quantity:f2}");
        }
        if (fruit == "grapes")
        {
            Console.WriteLine($"{(grapesP + 0.35) * quantity:f2}");
        }
    }
    else
    {
        Console.WriteLine("error");
    }
}
else
{
    Console.WriteLine("error");
}
  