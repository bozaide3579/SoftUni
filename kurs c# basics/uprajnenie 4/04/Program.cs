int age = int.Parse(Console.ReadLine());
double dishwasherPrice = double.Parse(Console.ReadLine());
int toyPrice = int.Parse(Console.ReadLine());
int money = 0;


for (int i = 1; i <= age; i++)
{
    if (i % 2 == 0)
    {
        money += i * 5 - 1;
    }
    else
    {
        money += toyPrice;
    }
}


if (money >= dishwasherPrice)
{
    Console.WriteLine($"Yes! {money - dishwasherPrice:f2}");
}
else
{
    Console.WriteLine($"No! {dishwasherPrice - money:f2}");
}