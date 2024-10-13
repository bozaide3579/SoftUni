
long n = long.Parse(Console.ReadLine());
long m = long.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());

long initialPokePower = n;
int pokeCount = 0;

if (n < m)
{
    Console.WriteLine(n);
    Console.WriteLine(pokeCount);
}
else
{
    while (n >= m)
    {
        n -= m;
        pokeCount++;

        if (n == initialPokePower / 2 && y != 0 && n % y == 0)
        {


            n /= y;

        }
    }

}

Console.WriteLine(n);
Console.WriteLine(pokeCount);