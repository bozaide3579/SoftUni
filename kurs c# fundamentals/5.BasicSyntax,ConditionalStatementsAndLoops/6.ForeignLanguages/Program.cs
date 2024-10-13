string country = Console.ReadLine();

if (country == "Spain" || country == "Argentina" || country == "Mexico")
{
    Console.WriteLine("Spanish");
}
else if (country == "England" || country == "USA")
{
    Console.WriteLine("English");
}
else
{
    Console.WriteLine("unknown");
}