double cpu = double.Parse(Console.ReadLine());

double gpu = double.Parse(Console.ReadLine());

double ram = double.Parse(Console.ReadLine());  

int numOfRam = int.Parse(Console.ReadLine());

double discount = double.Parse(Console.ReadLine());

double numgpu = (gpu - (gpu * discount));

double numcpu =  (cpu - (cpu * discount));

double numram = ram * numOfRam;

double finalP = (numcpu + numgpu + numram) * 1.57;

Console.WriteLine($"Money needed - {finalP:f2} leva.");

