

using System.ComponentModel.Design;

int people = int.Parse(Console.ReadLine());

int back = 0;
int chest = 0;
int legs = 0;
int abs = 0;
int shake = 0;
int bar = 0;

for (int i = 0; i < people; i++)
{
    string activity = Console.ReadLine();

    if (activity == "Back")
    {
        back++;
    }
    else if (activity == "Chest")
    {
        chest++;
    }
    else if (activity == "Legs")
    {
        legs++;
    }
    else if (activity == "Abs")
    {
        abs++;
    }
    else if (activity == "Protein shake")
    {
        shake++;
    }
    else if (activity == "Protein bar")
    {
        bar++;
    }

}

double train = (back + chest + legs + abs) / (double)people * 100;

double protein = (shake + bar) / (double)people * 100;

Console.WriteLine($"{back} - back");
Console.WriteLine($"{chest} - chest");
Console.WriteLine($"{legs} - legs");
Console.WriteLine($"{abs} - abs");
Console.WriteLine($"{shake} - protein shake");
Console.WriteLine($"{bar} - protein bar");
Console.WriteLine($"{train:f2}% - work out");
Console.WriteLine($"{protein:f2}% - protein");