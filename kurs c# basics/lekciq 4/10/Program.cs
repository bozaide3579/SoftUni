


int n = int.Parse(Console.ReadLine());
int even = 0;
int odd = 0;


for (int i = 1; i <= n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    if (i % 2 == 0)
    {
        even += currentNum;
    }
    else
    {
        odd += currentNum;
    }
  
}


if (odd == even)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {even}");
}
else
{
    int diff = Math.Abs(even - odd);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {diff}");
}