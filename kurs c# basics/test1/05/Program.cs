

string input = Console.ReadLine();
string height = Console.ReadLine();



int days = 0;
int meters = 5364;

while (input != "END" || height != "END")
{
    

    if (input == "Yes")
    {
        days++;
    }
    else if (input == "No")
    {
        continue;
    }

    meters += int.Parse(height);

    if (meters >= 8848)
    {
        Console.WriteLine($"Goal reached for {days} days!");
        break;
    }

    input = Console.ReadLine();
    height = Console.ReadLine();
}


    if (input == "END" || height == "END")
    {
        Console.WriteLine("Failed!");
        Console.WriteLine($"{meters}");
    }