double record = double.Parse(Console.ReadLine());
double meters = double.Parse(Console.ReadLine());  
double secForM = double.Parse(Console.ReadLine());

double timeForSwim = meters * secForM;
double delay = Math.Floor (meters / 15);
double finalTime = timeForSwim + (delay * 12.5);

if (finalTime < record)
{
    Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
}
else
{
    Console.WriteLine($"No, he failed! He was {finalTime - record:f2} seconds slower.");
}



