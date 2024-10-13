

using System.Numerics;

int n = int.Parse(Console.ReadLine());

int bestSnow = 0, bestTime = 0, bestQuality = 0;
BigInteger bestValue = 0;

for (int i = 0; i < n; i++)
{
    int snow = int.Parse(Console.ReadLine());
    int time = int.Parse(Console.ReadLine());
    int quality = int.Parse(Console.ReadLine());

    BigInteger value = BigInteger.Pow(snow / time, quality);

    if (value > bestValue)
    {
        bestSnow = snow;
        bestTime = time;
        bestQuality = quality;
        bestValue = value;
    }

}

Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

