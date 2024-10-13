
int roomSize = int.Parse(Console.ReadLine()) * int.Parse(Console.ReadLine()) * int.Parse(Console.ReadLine());

string input  = Console.ReadLine(); 

while (input != "Done")
{
    roomSize -= int.Parse(input);

    if (roomSize < 0)
    {
        Console.WriteLine($"No more free space! You need {Math.Abs(roomSize)} Cubic meters more.");
        break;
    }

    input = Console.ReadLine();
}

if (input == "Done")
{
    Console.WriteLine($"{roomSize} Cubic meters left.");
}