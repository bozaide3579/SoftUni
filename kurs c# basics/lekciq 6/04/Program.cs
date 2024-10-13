int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
int magic = int.Parse(Console.ReadLine());

int counter = 0;
bool isFound = false;

for (int i = start; i <= end; i++)
{
    for (int j = start; j <= end; j++)
    {
        counter++;

        if (i + j == magic)
        {
            Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magic})");
            isFound = true;
            break;
        }

    }

    if (isFound)
    {
        break;
    }

}

if (!isFound)
{
    Console.WriteLine($"{counter} combinations - neither equals {magic}");

}
