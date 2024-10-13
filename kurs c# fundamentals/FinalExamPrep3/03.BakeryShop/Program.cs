namespace _03.BakeryShop
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Dictionary<string, int> stock = new Dictionary<string, int>();
            int totalSold = 0;

            string input;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] splittedInput = input.Split();

                if (splittedInput[0] == "Receive")
                {
                    string food = splittedInput[2];
                    int quantity = int.Parse(splittedInput[1]);

                    if (quantity > 0) 
                    {
                        if (!stock.ContainsKey(food))
                        {
                            stock.Add(food, quantity);
                        }
                        else
                        {
                            stock[food] += quantity;
                        }
                    }
                }
                else if (splittedInput[0] == "Sell")
                {
                    string food = splittedInput[2];
                    int quantity = int.Parse(splittedInput[1]);

                    if (!stock.ContainsKey(food))
                    {
                        Console.WriteLine($"You do not have any {food}.");
                    }
                    else 
                    {
                        if (stock[food] < quantity)
                        {
                            totalSold += stock[food];
                            Console.WriteLine($"There aren't enough {food}. You sold the last {stock[food]} of them.");
                            stock.Remove(food);
                        }
                        else
                        {
                            totalSold += quantity;
                            stock[food] -= quantity;
                            Console.WriteLine($"You sold {quantity} {food}.");

                            if (stock[food] == 0)
                            {
                                stock.Remove(food);
                            }
                        }
                    }
                }
            }

            foreach (var food in stock)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
            Console.WriteLine($"All sold: {totalSold} goods");
        }
    }
}