string input = Console.ReadLine();
double bankAcc = 0;

while (input != "NoMoreMoney")
{
    double currentInput = double.Parse(input);

    if (currentInput < 0)
    {
        Console.WriteLine("Invalid operation!");
        break;
    }

    bankAcc += currentInput;
    Console.WriteLine($"Increase: {currentInput:f2}");

    input = Console.ReadLine();

}

Console.WriteLine($"Total: {bankAcc:f2}");