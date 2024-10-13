double taxPerYear = double.Parse(Console.ReadLine());

double shoes = taxPerYear - (taxPerYear * 0.4);

double outfit = shoes - (shoes * 0.2);

double ball = outfit * 0.25;

double accessories = ball * 0.2;

double price = taxPerYear + shoes + outfit + ball + accessories;

Console.WriteLine(price);