
class Program
{
    static void Main()
    {

        List<string> chest = Console.ReadLine().Split('|').ToList();

        string input;
        while ((input = Console.ReadLine()) != "Yohoho!")
        {
            List<string> commands = input.Split(" ").ToList();

            if (commands[0] == "Loot")
            {
                List<string> range = commands.GetRange(1, commands.Count - 1);
                chest = Add(chest, range);
            }
            else if (commands[0] == "Drop")
            {
                int index = int.Parse(commands[1]);
                chest = Drop(chest, index);
            }
            else if (commands[0] == "Steal")
            {
                int count = int.Parse(commands[1]);
                chest = Steal(chest, count);
            }
        }

        if (chest.Count == 0)
        {
            Console.WriteLine("Failed treasure hunt.");
        }
        else
        {
            double avgTreasure = CalculateAvgTreasure(chest);
            Console.WriteLine($"Average treasure gain: {avgTreasure:f2} pirate credits.");
        }
    }

    private static List<string> Steal(List<string> chest, int count)
    {
        List<string> stolen = new List<string>();

        for (int i = 1; i <= count; i++)
        {
            if (chest.Count != 0)
            {
                int lastIndex = chest.Count - 1;
                stolen.Insert(0, chest[lastIndex]);
                chest.RemoveAt(lastIndex);
            }
            else
            {

                break;
            }
        }
        Console.WriteLine(string.Join(", ", stolen));
        return chest;
    }

    private static List<string> Drop(List<string> chest, int index)
    {
        if (index >= 0 && index <= chest.Count - 1)
        {
            string item = chest[index];
            chest.RemoveAt(index);
            chest.Insert(chest.Count, item);

        }

        return chest;
    }

    private static List<string> Add(List<string> chest, List<string> range)
    {
        for (int i = 0; i < range.Count; i++)
        {
            if (!chest.Contains(range[i]))
            {
                chest.Insert(0, range[i]);
            }
        }

        return chest;
    }


    private static double CalculateAvgTreasure(List<string> chest)
    {
        double avgTreasure = 0;

        for (int i = 0; i < chest.Count; i++)
        {
            avgTreasure += chest[i].Length;
        }

        return avgTreasure / chest.Count; 
    }
}



