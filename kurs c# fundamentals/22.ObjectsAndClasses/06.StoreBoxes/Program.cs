
using System;
using System.Collections.Generic;
using System.Linq;


/*
 
19861519 Dove 15 2.50
86757035 Butter 7 3.20
39393891 Orbit 16 1.60
37741865 Samsung 10 1000
end

 */

internal class Program
{

    class Item
    {
        public string Name;
        public decimal Value;

        public Item(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }

    class Box
    {
        public string SerialNumber;
        public Item Item;
        public int Quantity;
        public decimal Price;

        public Box(string serialNumber, Item item, int quantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            Quantity = quantity;
            Price = quantity * Item.Value;
        }

        public override string ToString()
        {
            return $"{SerialNumber}\n-- {Item.Name} - ${Item.Value:f2}: {Quantity}\n-- ${Price:f2}";
        }
    }
    static void Main(string[] args)
    {


        List<Box> boxes = new List<Box>();


        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] argumets = input.Split();

            string serialNum = argumets[0];
            string name = argumets[1];
            int quantity = int.Parse(argumets[2]);
            decimal price = decimal.Parse(argumets[3]);

            Item item = new Item(name, price);
            Box box = new Box(serialNum, item, quantity);

            boxes.Add(box);
        }

        List<Box> sortedBoxes = boxes.OrderByDescending(b => b.Price).ToList();

        foreach (Box box in sortedBoxes)
        {
            Console.WriteLine(box.ToString());
        }

    }
}
