
internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split(" -> ");

            string companyName = arguments[0];
            string id = arguments[1];

            if (!companies.ContainsKey(companyName))
            {
                companies.Add(companyName, new List<string>());
            }

            if (!companies[companyName].Contains(id))
            {
                companies[companyName].Add(id);
            }

        }

        foreach (var pair in companies)
        {
            Console.WriteLine(pair.Key);

            foreach (string id in pair.Value)
            {
                Console.WriteLine($"-- {id}");
            }
        }
    }
}
