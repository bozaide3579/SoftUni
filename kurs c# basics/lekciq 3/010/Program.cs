
double num = double.Parse(Console.ReadLine());

bool isValid = num >= 100 && num <= 200 || num == 0;

if (!isValid)
{
    Console.WriteLine("invalid");
}

