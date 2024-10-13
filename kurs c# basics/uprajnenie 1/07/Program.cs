using System.Transactions;

double chicken = double.Parse(Console.ReadLine());
double chickenP = 10.35;
double fish  = double.Parse(Console.ReadLine());
double fishP = 12.40;
double veg = double.Parse(Console.ReadLine());
double vegP = 8.15;

double price = chicken * chickenP + fish * fishP + veg * vegP;  

double dessert = 0.2 * price;

double delivery = 2.50;

Console.WriteLine(price + dessert + delivery);


