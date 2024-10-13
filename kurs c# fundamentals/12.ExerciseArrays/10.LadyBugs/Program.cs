

int fieldLength = int.Parse(Console.ReadLine());
int[] bugPlaces = Console.ReadLine().Split().Select(int.Parse).ToArray();

int[] field = new int[fieldLength];

for (int i = 0; i < bugPlaces.Length; i++)
{
    int bugIndex = bugPlaces[i];
    if (bugIndex >=0 && bugIndex <= field.Length - 1)
    {
        field[bugIndex] = 1;
    }
    
}



string input;
while ((input = Console.ReadLine()) != "end")
{
    string[] elements = input.Split();
    int bugIndex = int.Parse(elements[0]);
    string direction = elements[1];
    int flyLength = int.Parse(elements[2]);

    if (bugIndex < 0 || bugIndex > field.Length - 1 || field[bugIndex] == 0)
    {
        continue;
    }

    field[bugIndex] = 0;
    int lastFieldIndex = field.Length - 1;

    if (direction == "right")
    {
        int landIndex = bugIndex + flyLength;

        if (landIndex > lastFieldIndex)
        {
            continue;
        }

        if (field[landIndex] == 1)
        {
            while (field[landIndex] == 1)
            {
                landIndex += flyLength;
                if (landIndex > lastFieldIndex)
                {
                    break;
                }
            }
        }
        if (landIndex <= lastFieldIndex)
        {
            field[landIndex] = 1;
        }
    }
    else if (direction == "left")
    {
        int landIndex = bugIndex - flyLength;

        if (landIndex < 0)
        {
            continue;
        }

        if (field[landIndex] == 1)
        {
            while (field[landIndex] == 1)
            {
                landIndex -= flyLength;
                if (landIndex < 0)
                {
                    break;
                }
            }
        }
        if (landIndex >= 0)
        {
            field[landIndex] = 1;
        }
    }
}


Console.WriteLine(string.Join(" ", field));

