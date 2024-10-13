
internal class Program
{
    static void Main(string[] args)
    {
        List<int> target = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            List<string> commands = input.Split(" ").ToList();

            int index = int.Parse(commands[1]);
            if (commands[0] == "Shoot")
            {
                int power = int.Parse(commands[2]);
                if (index >= 0 && index < target.Count)
                {
                    target[index] -= power;
                    if (target[index] <= 0)
                    {
                        target.RemoveAt(index);
                    }
                }
            }
            else if (commands[0] == "Add")
            {
                int value = int.Parse(commands[2]);
                if (index >= 0 && index < target.Count)
                {
                    target.Insert(index, value);
                }
                else
                {
                    Console.WriteLine("Invalid placement!");
                }
            }
            else if (commands[0] == "Strike")
            {
                int radius = int.Parse(commands[2]);
                if (index - radius >= 0 && index + radius < target[target.Count - 1])
                {
                    target.RemoveRange(index - radius, radius * 2 + 1);
                }
                else
                {
                    Console.WriteLine("Strike missed!");
                }

            }



        }

        Console.WriteLine(string.Join("|", target));


    }
}
