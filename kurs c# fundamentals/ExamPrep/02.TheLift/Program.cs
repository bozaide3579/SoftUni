
internal class Program
{
    static void Main(string[] args)
    {
        int peopleWaiting = int.Parse(Console.ReadLine());

        List<int> wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

        int max = 4;

        for (int i = 0; i < wagons.Count; i++)
        {
            int space = max - wagons[i];

            if (peopleWaiting > 0)
            {
                if (space > 0)
                {
                    if (peopleWaiting >= space)
                    {
                        wagons[i] += space;
                        peopleWaiting -= space;
                    }
                    else
                    {
                        wagons[i] += peopleWaiting;
                        peopleWaiting = 0;
                    }
                }
            }
        }


        bool hasEmptySpots = false;
        foreach (int i in wagons)
        {
            if (i < 4)
            {
                hasEmptySpots = true;
                break;
            }
        }

        if (hasEmptySpots && peopleWaiting == 0)
        {
            Console.WriteLine("The lift has empty spots!");
            Console.WriteLine(string.Join(" ", wagons));
        }
        else if (!hasEmptySpots && peopleWaiting > 0)
        {
            Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            Console.WriteLine(string.Join(" ", wagons));
        }
        else
        {
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}