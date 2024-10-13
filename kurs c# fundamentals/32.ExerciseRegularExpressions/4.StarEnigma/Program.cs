
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{

    class Message
    {
        public string PlanetName;
        public uint Population;
        public string Attack;
        public uint Soldiers;

        public Message(string planetName, uint population, string attack, uint soldiers)
        {
            PlanetName = planetName;
            Population = population;
            Attack = attack;
            Soldiers = soldiers;
        }
    }

    static void Main(string[] args)
    {
        List<Message> messages = new List<Message>();

        int messageCount = int.Parse(Console.ReadLine());

        string starPattern = @"[STARstar]";

        for (int i = 0; i < messageCount; i++)
        {
            string encryptMsg = Console.ReadLine();

            int drecryptionKey = Regex.Matches(encryptMsg, starPattern).Count;

            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < encryptMsg.Length; j++)
            {
                sb.Append((char)(encryptMsg[j] - drecryptionKey));
            }

            string decryptedMsg = sb.ToString();  
            string msgPattern = @"\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*\:[^\@\-\!\:\>]*?(?<population>\d+)[^\@\-\!\:\>]*\!(?<type>A|D)\![^\@\-\!\:\>]*\-\>[^\@\-\!\:\>]*?(?<soldiers>\d+)";

            Match match = Regex.Match(decryptedMsg, msgPattern);

            if (!match.Success)
            {
                continue;
            }

            string planetName = match.Groups["planet"].Value;
            uint population = uint.Parse(match.Groups["population"].Value);
            string attack = match.Groups["type"].Value;
            uint soldiers = uint.Parse(match.Groups["soldiers"].Value);

            Message message = new Message(planetName, population, attack, soldiers);

            messages.Add(message);

        }

        List<Message> messageTyped = messages
            .Where(m => m.Attack == "A")
            .OrderBy(m => m.PlanetName) 
            .ToList();

        Console.WriteLine($"Attacked planets: {messageTyped.Count}");
        messageTyped.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));

        messageTyped = messages
            .Where(m => m.Attack == "D")
            .OrderBy(m => m.PlanetName)
            .ToList();

        Console.WriteLine($"Destroyed planets: {messageTyped.Count}");
        messageTyped.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));
    }
}
