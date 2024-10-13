

using System.Diagnostics.CodeAnalysis;

int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();    


int evenSum = 0;
int oddSum = 0;

for (int i = 0; i < array.Length; i++)
{
    int num = array[i];
    if (num % 2 == 0)
    {
        evenSum += num;
    }
    else if (num % 2 == 1)
    {
        oddSum += num;
    }
         
}

Console.WriteLine(evenSum - oddSum);