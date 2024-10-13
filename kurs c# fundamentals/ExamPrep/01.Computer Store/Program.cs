
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {

        double partsSum = 0;
        string input;
        while ((input = Console.ReadLine()) != "regular" && input != "special")
        {
            double parts = double.Parse(input);
            if (parts <= 0)
            {
                Console.WriteLine("Invalid price!");
            }
            else
            {
                partsSum += parts;

            }
        }


        double taxes = 0;
        double finalPrice = 0;
        if (input == "regular")
        {
            if (partsSum == 0) 
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
            taxes = partsSum * 0.2;
            finalPrice = partsSum + taxes;
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {partsSum:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {finalPrice:f2}$");

            }
        }
        else if (input == "special")
        {
            if (partsSum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
            taxes = partsSum * 0.2;
            finalPrice = partsSum + taxes;
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {partsSum:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {finalPrice - finalPrice * 0.1:f2}$");

            }
        }

    }
}