



using Microsoft.VisualBasic;

int energy = int.Parse(Console.ReadLine());
int winCount = 0;

string input;
while ((input = Console.ReadLine()) != "End of battle")
{
    int distance = int.Parse(input);

    if (energy < distance)
    {
        Console.WriteLine($"Not enough energy! Game ends with {winCount} won battles and {energy} energy");
        break;
    }


    energy -= distance;
    winCount++;


    if (winCount % 3 == 0)
    {
        energy += winCount;
    }

}

if (input == "End of battle")
{
    Console.WriteLine($"Won battles: {winCount}. Energy left: {energy}");

}