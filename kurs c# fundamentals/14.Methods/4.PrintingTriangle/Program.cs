


int n = int.Parse(Console.ReadLine());

PrintTriangle(n);

void PrintTriangle(int n)
{
    for (int i = 1; i <= n; i++)
    {
        TriangleLine(i);
    }

    for (int i = 1; i < n; i++)
    {
        TriangleLine(n - i);
    }
}

void TriangleLine(int n)
{
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}