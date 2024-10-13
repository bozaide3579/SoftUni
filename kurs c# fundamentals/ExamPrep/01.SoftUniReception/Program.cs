
using System.ComponentModel;
using System.Threading.Channels;

internal class Program
{
    static void Main()
    {
        int emp1 = int.Parse(Console.ReadLine());
        int emp2 = int.Parse(Console.ReadLine());
        int emp3 = int.Parse(Console.ReadLine());

        int students = int.Parse(Console.ReadLine());
        int totalRate = emp1 + emp2 + emp3;
        int time = 0;
        int hoursWorked = 0;

        while (students > 0)
        {
            if (hoursWorked > 0 && hoursWorked % 3 == 0)
            {
                time++;
                hoursWorked = 0;
                continue;
            }

            students -= totalRate;
            hoursWorked++;
            time++;

        }

        Console.WriteLine($"Time needed: {time}h.");
    }


}