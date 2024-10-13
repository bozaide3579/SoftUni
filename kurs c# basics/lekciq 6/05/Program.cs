

string destiantion = Console.ReadLine();


while (destiantion != "End")
{
    double price = double.Parse(Console.ReadLine());
    double savedMoney = 0;

    while (savedMoney < price)
    {
        double money = double.Parse(Console.ReadLine());    
        savedMoney += money;
    }

    Console.WriteLine($"Going to {destiantion}!");


    destiantion = Console.ReadLine();   
}