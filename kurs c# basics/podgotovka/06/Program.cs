


int countOfBread = int.Parse(Console.ReadLine());

int bestChef = 0;
string bestChefName = "";

for (int i = 0; i < countOfBread; i++)
{
    string nameOfChef = Console.ReadLine(); 
    string input = Console.ReadLine();

    int allPoints = 0;
    

    while (input != "Stop")
    {
        int currentPoints = int.Parse(input);
        allPoints += currentPoints;


        input = Console.ReadLine();
    }

    Console.WriteLine($"{nameOfChef} has {allPoints} points.");


    if (allPoints > bestChef)
    {
        bestChefName = nameOfChef;
        bestChef = allPoints;
        Console.WriteLine($"{nameOfChef} is the new number 1!");
    }

}

Console.WriteLine($"{bestChefName} won competition with {bestChef} points!");