
string flowers = Console.ReadLine();
int quantity = int.Parse(Console.ReadLine());
double budget = double.Parse(Console.ReadLine());
double price = 0;



switch (flowers)
{
    case "Roses":
        price = 5.00;
        if (quantity > 80)
        {
            price = price - price * 0.10;
        }
        
        break;
    case "Dahlias":
        price = 3.80;
        if (quantity > 90)
        {
            price = price - price * 0.15;
        }
        
        break;
    case "Tulips":
        price = 2.80;
        if (quantity > 80)
        {
            price = price - price * 0.15;

        }
        break;
    case "Narcissus":
        price = 3.00;
        if (quantity < 120)
        {
            price = price + price * 0.15;

        }
        break;
    case "Gladiolus":
        price = 2.50;
        if (quantity < 80)
        {
            price = price + price * 0.20;

        }
        break;
}
double finalprice = price * quantity;

if (budget >= price * quantity)
            Console.WriteLine($"Hey, you have a great garden with {quantity} {flowers} and {budget - finalprice:f2} leva left.");
        else
            Console.WriteLine($"Not enough money, you need {finalprice - budget:f2} leva more.");
