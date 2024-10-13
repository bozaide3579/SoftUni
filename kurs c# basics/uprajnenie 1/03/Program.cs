double deposit = double.Parse(Console.ReadLine());
int term = int.Parse(Console.ReadLine());   
double rate  = double.Parse(Console.ReadLine())/100;

double sum;

sum = deposit + term * (deposit * rate / 12);

Console.WriteLine(sum);


