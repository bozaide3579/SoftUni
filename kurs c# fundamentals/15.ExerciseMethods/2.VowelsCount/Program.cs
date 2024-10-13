class Program
{
    static void Main()
    {

        string input = Console.ReadLine();


        NumOfVowels(input);


    }

    private static void NumOfVowels(string input)
    {
        int count = 0;
        string vowels = "aeiouAEIOU";
       
        for (int i = 0; i < input.Length; i++)
        {
            if (vowels.IndexOf(input[i]) >= 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}