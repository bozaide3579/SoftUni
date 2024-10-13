using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;

double cpu = double.Parse(Console.ReadLine());

double gpu =  double.Parse(Console.ReadLine()); 

double ram  = double.Parse(Console.ReadLine()); 

int ramNum = int.Parse(Console.ReadLine());

double discount = double.Parse(Console.ReadLine());

double cpu2 = cpu * 1.57;

double gpu2 = gpu * 1.57;

double ram2 = ram * ramNum;

double cpu3 = (cpu - (cpu * discount / 100));

double gpu3 = (gpu - (gpu * discount / 100));

double finalp = cpu3 + gpu3 + ram2;

Console.WriteLine($"Money needed - {finalp} leva.");



