int n = int.Parse(Console.ReadLine());

int[] wagons = new int[n];

int sum = 0;
for (int i = 0; i < n ; i++)
{
    wagons[i] = int.Parse(Console.ReadLine());
    Console.Write(wagons[i] + " ");
    sum += wagons[i];
}
Console.WriteLine();
Console.WriteLine(sum);