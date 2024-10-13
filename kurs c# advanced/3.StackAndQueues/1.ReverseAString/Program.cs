
string input = Console.ReadLine();

Stack<char> stack = new Stack<char>();

foreach (char i in input)
{
    stack.Push(i);
}

Console.WriteLine(string.Join("", stack));