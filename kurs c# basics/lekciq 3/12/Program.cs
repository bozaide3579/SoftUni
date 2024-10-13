string city = Console.ReadLine();
double sales = double.Parse(Console.ReadLine());
double commission = 0;
bool error = false;

if (city == "Sofia")
{
    if (sales >= 0 && sales <= 500)
    {
        commission = sales * 0.05;
    }
    else if (sales <= 1000)
    {
        commission = sales * 0.07;
    }
    else if (sales <= 10000)
    {
        commission = sales * 0.08;
    }
    else if (sales > 10000)
    {
        commission = sales * 0.12;
    }
    else
    {
        error = true;
    }

}


else if (city == "Varna")
{
    if (sales >= 0 && sales <= 500)
    {
        commission = sales * 0.045;
    }
    else if (sales <= 1000)
    {
        commission = sales * 0.075;
    }
    else if (sales <= 10000)
    {
        commission = sales * 0.1;
    }
    else if (sales > 10000)
    {
        commission = sales * 0.13;
    }
    else
    {
        error = true;
    }
}


else if (city == "Plovdiv")
{
    if (sales >= 0 && sales <= 500)
    {
        commission = sales * 0.055;
    }
    else if (sales > 500 && sales <= 1000)
    {
        commission = sales * 0.08;
    }
    else if (sales > 1000 && sales <= 10000)
    {
        commission = sales * 0.12;
    }
    else if (sales > 10000)
    {
        commission = sales * 0.145;
    }
    else
    {
        error = true;
    }

}
else
{
    error = true;
}
if (error)
{
    Console.WriteLine("error");
}
else
{
    Console.WriteLine($"{commission:f2}");
}