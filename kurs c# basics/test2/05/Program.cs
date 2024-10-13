

string input = Console.ReadLine();
int kids = 0;
int adults = 0;

int sweaters = 0;
int toys = 0;

while (input != "Christmas")
{
    int age = int.Parse(input);

    if (age <= 16)
    {
        kids++;
        toys++;
    }
    else if (age > 16)
    {
        adults++;
        sweaters++;
    }

    input = Console.ReadLine();
}

if (input == "Christmas")
{
    Console.WriteLine($"Number of adults: {adults}");
    Console.WriteLine($"Number of kids: {kids}");
    Console.WriteLine($"Money for toys: {kids*5}");
    Console.WriteLine($"Money for sweaters: {adults*15}");
}