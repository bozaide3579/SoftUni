using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal Price { get; set; }

        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            Price = itemQuantity * item.Price;
        }

        public override string ToString()
        {
            return $"{SerialNumber}\n-- {Item.Name} – ${Item.Price:F2}: {ItemQuantity}\n-- ${Price:F2}";
        }
    }

    static void Main(string[] args)
    {
        List<Box> boxes = new List<Box>();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] arguments = input.Split();

            string serialNumber = arguments[0];
            string itemName = arguments[1];
            int itemQuantity = int.Parse(arguments[2]);
            decimal itemPrice = decimal.Parse(arguments[3]);

            Item item = new Item(itemName, itemPrice);
            Box box = new Box(serialNumber, item, itemQuantity);

            boxes.Add(box);
        }

        List<Box> sortedBoxes = boxes.OrderByDescending(b => b.Price).ToList();

        foreach (Box box in sortedBoxes)
        {
            Console.WriteLine(box);
        }
    }
}
