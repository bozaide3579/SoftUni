

class Program
{
    static void Main()
    {

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());


        PrintSmallestNum(a,b,c);

        
    }

    private static void PrintSmallestNum(int a, int b, int c)
    {
        int smallest = a;

        if (b < smallest)
        {
            smallest = b;
        }

        if (c < smallest)
        {
            smallest = c;
        }

        Console.WriteLine(smallest);
    }


}