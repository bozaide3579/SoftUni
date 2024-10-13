
internal class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split("@").Select(int.Parse).ToList();
        int position = 0;
        string input;
        while ((input = Console.ReadLine()) != "Love!")
        {
            string[] commands = input.Split();
            int length = int.Parse(commands[1]);
            position += length;


            if (position >= list.Count)
            {
                position = 0;
            }

            if (list[position] > 0)
            {
                list[position] -= 2;
                if (list[position] == 0)
                {
                    Console.WriteLine($"Place {position} has Valentine's day.");
                }
            }
            else
            {
                Console.WriteLine($"Place {position} already had Valentine's day.");
            }

        }
        Console.WriteLine($"Cupid's last position was {position}.");

        int failed = 0;
        for ( int i = 0; i < list.Count; i++ )
        {
            if (list[i] > 0 )
            {
                failed++;
            }
        }

        
        if (failed == 0) 
        {
            Console.WriteLine("Mission was successful.");
        }
        else
        {
            Console.WriteLine($"Cupid has failed {failed} places.");
        }
    }
}
