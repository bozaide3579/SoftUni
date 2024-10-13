int n = int.Parse(Console.ReadLine());


for (int i = 1; i <= n; i++)
{
    int currentNum = i;
    int digitsSum = 0;

    while (currentNum > 0)
    {
        digitsSum += currentNum % 10;
        currentNum /= 10;

    }

    bool isSpecial = false;

    if (digitsSum == 5 || digitsSum == 7 || digitsSum == 11)
    {
        isSpecial = true;
    }

    Console.WriteLine($"{i} -> {isSpecial}");
}