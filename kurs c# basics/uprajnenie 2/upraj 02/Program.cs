int number = int.Parse(Console.ReadLine());
double bonus = 0;

if (number <= 100)
{
    bonus = 5;
}
else if (number <= 1000)
{
    bonus = number * 0.2;
}
else if (number > 1000)
{
    bonus = number * 0.1;
}

if (number % 2 == 0)
{
    bonus += 1;
}

if (number % 10 == 5) 
{
    bonus = bonus += 2;
}

double totalNum = bonus + number;

Console.WriteLine(bonus);
Console.WriteLine(totalNum);