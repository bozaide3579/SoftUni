

List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

string input;
while ((input = Console.ReadLine()) != "end")
{
    string[] commands = input.Split();
    if (commands[0] == "Delete")
    {
        numbers.Remove(int.Parse(commands[1]));
    }
    else if (commands[0] == "Insert")
    {
        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
    }
}

Console.WriteLine(string.Join(" ", numbers));