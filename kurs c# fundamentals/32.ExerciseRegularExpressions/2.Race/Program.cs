
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{

    class Participants
    {
        public string Name;

        public uint Distance;


        public Participants(string name)
        {
            Name = name;
        }
    }
    static void Main()
    {

        Dictionary<string ,Participants> participants = new Dictionary<string ,Participants>();

        string[] participantsArr = Console.ReadLine().Split(", ");

        for (int i = 0; i < participantsArr.Length; i++)
        {
            participants.Add(participantsArr[i], new Participants(participantsArr[i]));

        }

        string digitPattern = @"\d";
        string letterPattern = @"[A-Za-z]+";


        string input;
        while ((input = Console.ReadLine()) != "end of race")
        {
            StringBuilder name = new StringBuilder();

            foreach (Match match in Regex.Matches(input, letterPattern))
            {
                name.Append(match.Value);
            }

            uint distance = 0;

            foreach (Match match in Regex.Matches(input, digitPattern))
            {
                distance += uint.Parse(match.Value);
            }

            string nameAsStr = name.ToString();
            if (participants.ContainsKey(nameAsStr))
            {
                participants[nameAsStr].Distance += distance;          
            }
        }

        var orderedParticipants = participants
            .Select(participantPair => participantPair.Value)
            .OrderByDescending(participant => participant.Distance)
            .Take(3)
            .ToList();

        Console.WriteLine($"1st place: {orderedParticipants[0].Name}");
        Console.WriteLine($"2nd place: {orderedParticipants[1].Name}");
        Console.WriteLine($"3rd place: {orderedParticipants[2].Name}");
    }
}
