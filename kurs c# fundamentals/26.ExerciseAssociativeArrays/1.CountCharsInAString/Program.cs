
internal class Program
{
    static void Main()
    {

        string inputString = Console.ReadLine();


        Dictionary<char, int>  charCount = new Dictionary<char, int>();

        foreach (char c in inputString)
        {
            if (c != ' ')
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
        }

        foreach (var entry in charCount)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}
