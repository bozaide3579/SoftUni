



int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();


while (array.Length > 1)
{
    int[] condenced = new int[array.Length - 1];
    for (int i = 0; i < array.Length - 1; i++)
    {
        condenced[i] = array[i] + array[i + 1];
    }
    array = condenced;
}

Console.WriteLine(array[0]);