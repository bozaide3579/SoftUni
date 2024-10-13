
string show = Console.ReadLine();
int episodeTime = int.Parse(Console.ReadLine());
double breakLenght = double.Parse(Console.ReadLine());

double lunch = breakLenght * 0.125 ;
double chill = breakLenght * 0.25;

double timeLeft = breakLenght - (lunch + chill);

if (timeLeft >= episodeTime)
{
    Console.WriteLine($"You have enough time to watch {show} and left with {Math.Ceiling(timeLeft - episodeTime)} minutes free time.");
}
else
{
    Console.WriteLine($"You don't have enough time to watch {show}, you need {Math.Ceiling(episodeTime - timeLeft)} more minutes.");
}