
internal class Program
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        int num;
        string input = Console.ReadLine().Trim();

        while (input != "stop") 
        {

            num = int.Parse(Console.ReadLine().Trim());

            if (dictionary.ContainsKey(input))
            {
                dictionary[input] += num;
            }
            else
            {
                 dictionary.Add(input, num);
            }

            input = Console.ReadLine();
        }

        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}
