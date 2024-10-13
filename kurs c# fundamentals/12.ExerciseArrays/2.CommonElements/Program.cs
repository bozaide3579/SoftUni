

string[] array1 = Console.ReadLine().Split(" ");
string[] array2 = Console.ReadLine().Split(" ");

for (int i = 0; i < array1.Length; i++)
{
    for (int j = 0; j < array2.Length; j++)
    {
        if (array1[i] == array2[j])
        {
            Console.Write(array1[i] + " ");
        }
    }
}
