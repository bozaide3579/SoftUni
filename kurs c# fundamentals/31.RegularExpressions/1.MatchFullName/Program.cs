
using System.Text.RegularExpressions;

internal class Program
{

    class Furniture
    {
        public string Name;
        public decimal Price;
        public int Quantity;

        public decimal Total()
        {
            return Price * Quantity;
        }
    }

    static void Main(string[] args)
    {
        string pattern = @"\>\>([A-Za-z]+)\<\<(\d+.\d+|\d+)\!(\d+)";
        
        List<Furniture> furnitures = new List<Furniture>();
        string input;
        while ((input = Console.ReadLine()) != "Purchase")
        {

            foreach (Match match in Regex.Matches(input, pattern))
            {
                Furniture furniture = new Furniture();
                furniture.Name = match.Groups[1].Value;
                furniture.Price = decimal.Parse(match.Groups[2].Value);
                furniture.Quantity = int.Parse(match.Groups[3].Value);


                furnitures.Add(furniture);
            }

        }
        Console.WriteLine("Bought furniture:");
        decimal total = 0;

        foreach (Furniture furniture in furnitures)
        {
            Console.WriteLine(furniture.Name);
            total += furniture.Total();
        }

        Console.WriteLine($"Total money spend: {total:f2}");

    }
}
