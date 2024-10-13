using System.Transactions;

double n1 = double.Parse(Console.ReadLine());
double n2 = double.Parse(Console.ReadLine());   
char operation = char.Parse(Console.ReadLine());


if (operation == '+' || operation == '-' || operation == '*')
{
    double result = 0;
    string evenOrOdd = "odd";

    switch (operation)
    {
        case '+':
            result = n1 + n2;
            break;
        case '-':
            result = n1 - n2;
            break;
        case '*':
            result = n1 * n2;
            break;
    }
    if (result % 2 == 0)
        evenOrOdd = "even";

    Console.WriteLine($"{n1} {operation} {n2} = {result} - {evenOrOdd}");
}
else if  (operation == '/' || operation == '%')
{
    if (n2 == 0)
    {
        Console.WriteLine($"Cannot divide {n1} by zero");
    }
    else if (operation == '/' || operation == '%')
    {
        double result = 0;  
        
        switch (operation)
        {
            case '/':
                result = n1 / n2;
                Console.WriteLine($"{n1} {operation} {n2} = {result:f2}");
                break;
            case '%':
                result = n1 % n2;
                Console.WriteLine($"{n1} % {n2} = {result}");
                break;
        }
    }
}