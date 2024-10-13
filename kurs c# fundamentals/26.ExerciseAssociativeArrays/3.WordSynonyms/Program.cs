
internal class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {

            string word = Console.ReadLine();
            string synonym = Console.ReadLine();

            if (!wordSynonyms.ContainsKey(word))
            {
                wordSynonyms.Add(word, new List<string>());
            }

            wordSynonyms[word].Add(synonym);
        }

        foreach (var wordSynonym in wordSynonyms)
        {
            Console.WriteLine($"{wordSynonym.Key} - {String.Join(", ", wordSynonym.Value)}");
        }



    }
}
