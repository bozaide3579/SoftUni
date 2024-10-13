
using System.Runtime.InteropServices;

string ticketType = Console.ReadLine();
int row = int.Parse(Console.ReadLine());
int col = int.Parse(Console.ReadLine());    

double income = row * col;

switch (ticketType)
{
    case "Premiere":
        income = income * 12.00;
            break;
    case "Normal":
        income = income * 7.50;
            break;
    case "Discount":
        income = income * 5.00;
        break;
}

Console.WriteLine($"{income:f2} leva");