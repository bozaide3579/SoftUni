﻿
string input = Console.ReadLine();

int primeSum = 0;
int nonPrimeSum = 0;

while (input != "stop")
{
    int num = int.Parse(input);

    if (num < 0)
    {
        Console.WriteLine("Number is negative.");
        input = Console.ReadLine();
        continue;
    }

    bool isPrime = true;

    for (int i = 2; i < num; i++)
    {
        if (num % i == 0)
        {
            isPrime = false;
        }
    }

    if (isPrime)
    {
        primeSum += num;
    }
    else
    {
        nonPrimeSum += num;
    }

    input = Console.ReadLine();
}
Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");

