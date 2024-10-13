
using System.Reflection;

internal class Program
{
    static void Main(string[] args)
    {
        int students = int.Parse(Console.ReadLine());
        int lectures = int.Parse(Console.ReadLine());
        int bonus = int.Parse(Console.ReadLine());

        double maxBonus = 0;
        int maxAttendances = 0;

        for (int i = 0; i < students; i++)                                                                  
        {
            int attendances = int.Parse(Console.ReadLine());

            double totalBonus = (double)attendances / lectures * (5 + bonus);

            if (totalBonus > maxBonus)
            {
                maxBonus = totalBonus;
                maxAttendances = attendances;
            }
        }


        Console.WriteLine($"Max Bonus: {maxBonus}.");
        Console.WriteLine($"The student has attended {maxAttendances} lectures.");
    }
}
