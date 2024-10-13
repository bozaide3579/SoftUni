


int n = int.Parse(Console.ReadLine());

int capacity = 0;

for (int i = 1; i <= n; i++)
{
    int l = int.Parse(Console.ReadLine());  

    capacity += l; 

    if (capacity > 255)
    {
        Console.WriteLine("Insufficient capacity!");
        capacity -= l;
    }

}

Console.WriteLine(capacity);