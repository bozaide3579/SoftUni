

int people = int.Parse(Console.ReadLine()); 

double fee  = double.Parse(Console.ReadLine()); 

double sunbedPrice = double.Parse(Console.ReadLine());  

double unbrellaPrice = double.Parse(Console.ReadLine());

double allTicketPrice = people * fee;

double allUnbrellaPrice = Math.Ceiling(people / 2.0) * unbrellaPrice;

double allSunbedPrice = Math.Ceiling(people * 0.75) * sunbedPrice;

Console.WriteLine($"{allTicketPrice + allSunbedPrice + allUnbrellaPrice:f2} lv.");