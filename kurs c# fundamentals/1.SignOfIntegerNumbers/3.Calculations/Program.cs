






using System.ComponentModel;

string command = Console.ReadLine();
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

if (command == "add")
{
    Add(a, b);
}
else if (command == "subtract")
{
    Subtract(a, b);
}
else if (command == "multiply")
{
    Multiply(a, b);
}
else if (command == "divide")
{
    Divide(a, b);
}

void Add(int a, int b)
{
    Console.WriteLine(a + b);
}

void Subtract(int a, int b)
{
    Console.WriteLine(a - b);
}

void Multiply(int a, int b)
{
    Console.WriteLine(a*b);
}

void Divide(int a, int b)
{
    Console.WriteLine(a/b);
}