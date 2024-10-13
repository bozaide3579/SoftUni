

using System.Diagnostics.CodeAnalysis;

int n = int.Parse(Console.ReadLine());  
int sum = 0;


for (int i = 1; i <= n; i++)
{
    char letter  = char.Parse(Console.ReadLine());

    Convert.ToInt32(letter);

    sum += letter;

}

Console.WriteLine(sum);