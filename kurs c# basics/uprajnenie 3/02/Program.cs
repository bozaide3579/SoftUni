
int degrees = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();

string shoes = string.Empty;
string outfit = string.Empty;

if (timeOfDay == "Morning")
{
    if (degrees <= 18)
    {
        shoes = "Sneakers";
        outfit = "Sweatshirt";
    }
    else if (degrees <= 24)
    {
        shoes = "Moccasins";
        outfit = "Shirt";
    }
    else
    {
        shoes = "Sandals";
        outfit = "T-Shirt";
    }
}
else if (timeOfDay == "Afternoon")
{
    if (degrees <= 18)
    {
        shoes = "Moccasins";
        outfit = "Shirt";
    }
    else if (degrees <= 24)
    {
        shoes = "Sandals";
        outfit = "T-Shirt";
    }
    else
    {
        shoes = "Barefoot";
        outfit = "Swim Suit";
    }
}
else if (timeOfDay == "Evening")
{
    shoes = "Moccasins";
    outfit = "Shirt";

}
Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");