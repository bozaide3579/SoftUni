

using System.ComponentModel;

int n = int.Parse(Console.ReadLine());

int startChar = 97;
int endchar = startChar + n;

for (int i = startChar; i < endchar; i++)
{
    for (int j = startChar; j < endchar; j++)
    {
        for (int k = startChar; k < endchar; k++)
        {
            Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
        } 
    }
}