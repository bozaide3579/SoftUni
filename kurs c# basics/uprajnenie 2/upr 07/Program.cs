double budget = double.Parse(Console.ReadLine());
int gpuAmount = int.Parse(Console.ReadLine());
int cpuAmount = int.Parse(Console.ReadLine());
int ramAmount = int.Parse(Console.ReadLine());

double gpuPrice = 250 * gpuAmount;
double cpuPrice = (gpuPrice * 0.35) * cpuAmount;
double ramPrice = (gpuPrice * 0.1) * ramAmount;

double price = gpuPrice + cpuPrice + ramPrice;

if (gpuAmount > cpuAmount)
{
    price = price * 0.85;
}

if (budget >= price)
{
    Console.WriteLine($"You have {budget - price:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {price - budget:f2} leva more!");
}