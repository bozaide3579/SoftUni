


string input = Console.ReadLine();

int n = int.Parse(Console.ReadLine());

string result = Repeat(input, n);

Console.WriteLine(result);

string Repeat(string input, int n)
{
    string result = "";

    for (int i = 0; i < n; i++)
    {
        result += input;
    }

    return result;
}