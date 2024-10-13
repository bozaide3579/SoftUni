
internal class Program
{
    static void Main(string[] args)
    {
        List<string> list = Console.ReadLine()
            .Split()
            .Where(x => x.Length % 2 == 0)
            .ToList();


        foreach (string s in list)
        {
            Console.WriteLine(s);
        }
    }
}
