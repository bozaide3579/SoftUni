string name = Console.ReadLine();
string pass = Console.ReadLine();   


while (true)
{
    string input = Console.ReadLine();  
    if (input == pass)
    {
        Console.WriteLine($"Welcome {name}!");
        break;
    }
}