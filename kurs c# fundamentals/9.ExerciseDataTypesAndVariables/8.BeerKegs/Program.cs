

int numOfKegs = int.Parse(Console.ReadLine());

string biggestKegName = "";
double biggestKegVolume = 0;

for (int i = 1; i <= numOfKegs; i++)
{

string model = Console.ReadLine();
double radius = double.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());

    double volume = Math.PI * (Math.Pow(radius, 2)) * height;

    if (biggestKegVolume < volume)
    {
        biggestKegVolume = volume;
        biggestKegName = model;
    }
}

Console.WriteLine(biggestKegName);


