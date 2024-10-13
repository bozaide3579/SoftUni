using System.Xml;

int n = int.Parse(Console.ReadLine());

int sum = 0;

int counter = 0;

for (int i = 1; i <= 100; i+=2)
{
    Console.WriteLine(i);
    counter++;
    sum += i;

    if (counter == n)
    {
        Console.WriteLine($"Sum: {sum}");
        break;
    }
}

