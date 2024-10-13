

List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();


int maxCapacity = int.Parse(Console.ReadLine());

string input;
while ((input = Console.ReadLine()) != "end")
{
    string[] arguments = input.Split();

    if (arguments[0] == "Add")
    {
        wagons.Add(int.Parse(arguments[1]));
    }
    else
    {
        int newPassengers = int.Parse(arguments[0]);
        for (int i = 0; i < wagons.Count; i++)
        {
            if (wagons[i] + newPassengers <= maxCapacity)
            {
                wagons[i] += newPassengers;
                break;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", wagons));