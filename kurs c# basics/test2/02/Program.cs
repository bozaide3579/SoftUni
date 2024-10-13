

double width = double.Parse(Console.ReadLine());

double lenght = double.Parse(Console.ReadLine());   

double height = double.Parse(Console.ReadLine());   

double avgHeight = double.Parse(Console.ReadLine());    


double spaceship = width * lenght * height;

double room = (avgHeight + 0.40) * 2 * 2;

double t = Math.Floor(spaceship / room);

if  (t >= 3 && t <= 10)
{
    Console.WriteLine($"The spacecraft holds {t} astronauts.");
}
else if (t < 3)
{
    Console.WriteLine("The spacecraft is too small.");
}
else
{
    Console.WriteLine("The spacecraft is too big.");
}