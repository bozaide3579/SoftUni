
internal class Program
{
    class Product
    {
        public string Name;
        public double Price;
        public int Quantity;

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {Price * Quantity:f2}";
        }
    }

    static void Main()
    {

        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] argumets = input.Split(); 

            string name = argumets[0];
            double price = double.Parse(argumets[1]);
            int quantity = int.Parse(argumets[2]);

            if (products.ContainsKey(name))
            {
                products[name].Price = price;
                products[name].Quantity += quantity;
            }
            else
            {
                var product = new Product(name, price, quantity);
                products.Add(name, product);

            }

        }

        foreach (Product product in products.Values)
        {
            Console.WriteLine(product);
        }
    }
}
