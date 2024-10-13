using static System.Formats.Asn1.AsnWriter;

string actor = Console.ReadLine();
double points = double.Parse(Console.ReadLine());
int numberOfJudges = int.Parse(Console.ReadLine());

for (int i = 1; i <= numberOfJudges; i++)
{
    string judgeName = Console.ReadLine();
    double judgePoints = double.Parse(Console.ReadLine());

    points += ((judgeName.Length * judgePoints) / 2);
    if (points >= 1250.5)
    {
        break;
    }
}
if (points > 1250.5)
{
    Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {points:f1}!");
}
else
{
    Console.WriteLine($"Sorry, {actor} you need {(1250.5 - points):f1} more!");
}