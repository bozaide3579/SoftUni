﻿
using System.ComponentModel.Design;

PrintGrade(double.Parse(Console.ReadLine()));
void PrintGrade (double grade)
{
    string[] grades = new string[] { "Fail", "Poor", "Good", "Very good", "Excellent" };

    int index = 0;
    if (grade >= 2 && grade < 3)
    {
        index = 0;
    }
    else if (grade < 3.5)
    {
        index = 1;
    }
    else if (grade < 4.5)
    {
        index = 2;
    }
    else if (grade < 5.5)
    {
        index = 3;
    }
    else
    {
        index = 4;
    }
    Console.WriteLine(grades[index]);


}