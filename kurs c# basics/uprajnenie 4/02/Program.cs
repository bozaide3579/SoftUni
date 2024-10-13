int n = int.Parse(Console.ReadLine());
int max = int.MinValue;
int sum = 0;

for (int i = 1; i <= n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    sum += currentNum;
    if (currentNum > max)
    {
        max = currentNum;
    }
}

sum -= max;

if (max == sum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {sum}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(sum - max)}");
}
