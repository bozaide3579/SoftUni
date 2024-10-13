


double baseNum = double.Parse(Console.ReadLine());

double pow = double.Parse(Console.ReadLine());    

double result = RaisedNum(baseNum, pow);

Console.WriteLine(result);


double RaisedNum(double baseNum,  double pow)
{

    double result = 0;

    return Math.Pow(baseNum, pow);
}