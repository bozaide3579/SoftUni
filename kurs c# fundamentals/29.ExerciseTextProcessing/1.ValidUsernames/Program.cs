
internal class Program
{
    static void Main(string[] args)
    {



        string[] usernames = Console.ReadLine().Split(", ");

        foreach (string username in usernames)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {

                bool isValid = username.All(symbol => char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_');

                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
