double pen = double.Parse(Console.ReadLine());
double pen1 = 5.80;
double marker = double.Parse(Console.ReadLine());
double marker1 = 7.20;
double liters = double.Parse(Console.ReadLine());
double liters1 = 1.20;
double discount = double.Parse(Console.ReadLine())/100;

double price = (pen * pen1) + (marker * marker1) + (liters * liters1);

double finalPrice = price - (price * discount);

Console.WriteLine(finalPrice);


