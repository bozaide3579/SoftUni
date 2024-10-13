
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        List<string> sequence = Console.ReadLine().Split().ToList();


        string input;
        int moves = 0;
        bool won = false;
        while ((input = Console.ReadLine()) != "end")
        {
            List<int> indexes = input.Split(" ").Select(int.Parse).ToList();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            moves++;

            if (firstIndex == secondIndex ||
                firstIndex < 0 || firstIndex > sequence.Count - 1 ||
                secondIndex < 0 || secondIndex > sequence.Count - 1)
            {
                int middleIndex = sequence.Count / 2;
                string newSymbol = $"-{moves}a";
                List<string> newElements = new List<string> { newSymbol, newSymbol };
                sequence.InsertRange(middleIndex, newElements);
                Console.WriteLine("Invalid input! Adding additional elements to the board");
            }
            else
            {
                if (sequence[firstIndex] == sequence[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                    if (secondIndex > firstIndex)
                    {
                        sequence.RemoveAt(firstIndex);
                        sequence.RemoveAt(secondIndex - 1);
                    }
                    else
                    {
                        sequence.RemoveAt(secondIndex);
                        sequence.RemoveAt(firstIndex - 1);
                    }


                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (sequence.Count == 0)
                {
                    won = true;
                    break;
                }
            }
        }

        if (won)
        {
            Console.WriteLine($"You have won in {moves} turns!");
        }
        else
        {
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequence));

        }
    }
}