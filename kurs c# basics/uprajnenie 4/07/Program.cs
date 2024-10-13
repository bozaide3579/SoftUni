int groups = int.Parse(Console.ReadLine());
int p1 = 0;
int p2 = 0;
int p3 = 0;
int p4 = 0;
int p5 = 0;

int total = 0;

for (int group = 1; group <= groups; group++)
{
    int count = int.Parse(Console.ReadLine());
    total += count;

    if (count <= 5)
    {
        p1 += count;
    }
    else if (count <= 12)
    {
        p2 += count;
    }
    else if (count <= 25)
    {
        p3 += count;
    }
    else if (count <= 40)
    {
        p4 += count;
    }
    else
    {
        p5 += count;
    }
}

Console.WriteLine($"{(double)p1 / total * 100:f2}%");
Console.WriteLine($"{(double)p2 / total * 100:f2}%");
Console.WriteLine($"{(double)p3 / total * 100:f2}%");
Console.WriteLine($"{(double)p4 / total * 100:f2}%");
Console.WriteLine($"{(double)p5 / total * 100:f2}%");

