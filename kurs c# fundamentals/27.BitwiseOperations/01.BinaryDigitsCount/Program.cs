
internal class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        int digit = int.Parse(Console.ReadLine());
        int count = 0;

        while (num != 0)
        {

            int left = num % 2;
            if (left == digit)
            {
                count++;
            }
            num = num / 2;
        }

        Console.WriteLine(count);
    }
}
