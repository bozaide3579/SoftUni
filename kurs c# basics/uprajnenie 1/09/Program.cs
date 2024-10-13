double lenght = double.Parse(Console.ReadLine());
double widh  = double.Parse(Console.ReadLine());    
double height  = double.Parse(Console.ReadLine());  
double percent = double.Parse(Console.ReadLine())/100;  

double aquarium = lenght * widh * height;

double liters = aquarium * 0.001;

double waterNeeded = liters * (1 - percent);

Console.WriteLine(waterNeeded);


