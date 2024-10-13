double nylon = double.Parse(Console.ReadLine());
double nylonP = (nylon + 2) * 1.50;

double paint = double.Parse(Console.ReadLine());
double paintP = (paint + (0.1 * paint)) * 14.50;

double devider = double.Parse(Console.ReadLine());
double deviderP = (devider * 5.00);

double bag = 0.40;


double matrerialP = (nylonP + paintP + deviderP + bag);

double laborT = double.Parse(Console.ReadLine());
double laborP = (matrerialP * 0.3 ) * laborT;

double price = matrerialP + laborP;

Console.WriteLine(price);


