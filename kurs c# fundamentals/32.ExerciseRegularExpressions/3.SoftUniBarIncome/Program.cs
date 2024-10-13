
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Schema;

internal class Program
{

    class Order
    {
        public string Name;
        public string Product;
        public int Count; 
        public decimal Price;

        public decimal Total()
        {
            return Price * Count;
        }
    }

    static void Main()
    {
        string pattern = @"\%([A-Z][a-z]+)\%[^|%$.]*\<(\w+)\>[^|%$.]*\|(\d+)\|[^|%$.]*?(\d+(?:\.\d+)?)?\$";
        decimal total = 0;

        string input;
        while ((input = Console.ReadLine()) != "end of shift") 
        {
            if (!Regex.IsMatch(input, pattern))
            {
                continue;
            }

            Match match = Regex.Match(input, pattern);

            Order order = new Order();

            order.Name = match.Groups[1].Value;
            order.Product = match.Groups[2].Value;
            order.Count = int.Parse(match.Groups[3].Value);
            order.Price = decimal.Parse(match.Groups[4].Value);

            total += order.Total();
            Console.WriteLine($"{order.Name}: {order.Product} - {order.Total():f2}");
        }
        Console.WriteLine($"Total income: {total:f2}");
    }
}
