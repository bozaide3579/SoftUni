using System.Xml;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] travel = input.Split("||");
        int fuel = int.Parse(Console.ReadLine());
        int ammo = int.Parse(Console.ReadLine());

        for (int i = 0; i < travel.Length; i++)
        {
            string[] commands = travel[i].Split();
            string move = commands[0];

            if (move == "Travel")
            {
                int num = int.Parse(commands[1]);
                if (fuel >= num)
                {
                    fuel -= num;
                    Console.WriteLine($"The spaceship travelled {num} light-years.");
                }
                else
                {
                    Console.WriteLine("Mission failed.");
                    return;
                }
            }
            else if (move == "Enemy")
            {
                int num = int.Parse(commands[1]);
                if (ammo >= num)
                {
                    ammo -= num;
                    Console.WriteLine($"An enemy with {num} armour is defeated.");
                }
                else
                {
                    if (fuel >= num * 2)
                    {

                        fuel -= num * 2;
                        Console.WriteLine($"An enemy with {num} armour is outmaneuvered.");

                    }
                    else
                    {

                        Console.WriteLine("Mission failed.");
                        return;

                    }
                }
            }
            else if (move == "Repair")
            {
                int num = int.Parse(commands[1]);
                fuel += num;
                ammo += num * 2;
                Console.WriteLine($"Ammunitions added: {num * 2}.");
                Console.WriteLine($"Fuel added: {num}.");
            }
            else if (move == "Titan")
            {
                Console.WriteLine("You have reached Titan, all passengers are safe.");
                return;
            }

        }
    }
}