
int students = int.Parse(Console.ReadLine());

int s1 = 0;
int s2 = 0;
int s3 = 0;
int s4 = 0;

double avg = 0;    

for (int i = 1; i <= students; i++)
{
    double grade = double.Parse(Console.ReadLine());

    avg += grade;

    if(grade <= 2.99)
    {
        s1++;
    }
    else if (grade >= 3.00 && grade <= 3.99)
    {
        s2++;
    }
    else if (grade >= 4.00 && grade <= 4.99)
    {
        s3++;
    }
    else
    {
        s4++;
    }

}

double s4p = ((double)s4 / students) * 100;
double s3p = ((double)s3 / students) * 100;
double s2p = ((double)s2 / students) * 100;
double s1p = ((double)s1 / students) * 100;   


Console.WriteLine($"Top students: {s4p:f2}%");
Console.WriteLine($"Between 4.00 and 4.99: {s3p:f2}%");
Console.WriteLine($"Between 3.00 and 3.99: {s2p:f2}%");
Console.WriteLine($"Fail: {s1p:f2}%");
Console.WriteLine($"Average: {(double)avg/students:f2}");
