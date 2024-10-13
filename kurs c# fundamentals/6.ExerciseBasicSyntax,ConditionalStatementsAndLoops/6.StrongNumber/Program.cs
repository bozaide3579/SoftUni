

using System.Reflection;

int number = int.Parse(Console.ReadLine());
int numCopy = number;
int factorialSum = 0;


while (numCopy > 0)
{
    int digit = numCopy % 10;
    numCopy /= 10;

    int factorial = 1;

    for (int i = 1; i <= digit; i++)
    {
        factorial *= i;
    }

    factorialSum += factorial;
}

string isStrongNum = factorialSum == number ? "yes" : "no";
Console.WriteLine(isStrongNum);