
using System.Xml;

char n = char.Parse(Console.ReadLine());

if (char.IsUpper(n))
{
    Console.WriteLine("upper-case");
}
else if (char.IsLower(n))
{
    Console.WriteLine("lower-case");
}