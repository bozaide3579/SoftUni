
using System.Threading;
using System.Xml;

internal class Program
{
    static void Main(string[] args)
    {

        int health = 100;
        int bitcoins = 0;
        int currentHealth = health;
        int bestRoom = 0;

        string input = Console.ReadLine();
        string[] rooms = input.Split('|');

        for (int i = 0; i < rooms.Length; i++)
        {
            string room = rooms[i];
            string[] commands = room.Split();
            string command = commands[0];
            int num = int.Parse(commands[1]);

            if (command == "potion")
            {
                if ((currentHealth + num) > health)
                {
                    int amountHealed = health - currentHealth;
                    currentHealth = health;
                    Console.WriteLine($"You healed for {amountHealed} hp.");
                }
                else
                {
                    currentHealth += num;
                    Console.WriteLine($"You healed for {num} hp.");
                }
                Console.WriteLine($"Current health: {currentHealth} hp.");

            }
            else if (command == "chest")
            {
                bitcoins += num;
                Console.WriteLine($"You found {num} bitcoins.");
            }
            else
            {
                currentHealth -= num;
                if (currentHealth <= 0)
                {
                    Console.WriteLine($"You died! Killed by {command}.");
                    Console.WriteLine($"Best room: {bestRoom + 1}");
                    return;
                }
                else
                {
                    Console.WriteLine($"You slayed {command}.");
                }
            }
            bestRoom = i + 1;
        }
        Console.WriteLine("You've made it!");
        Console.WriteLine($"Bitcoins: {bitcoins}");
        Console.WriteLine($"Health: {currentHealth}");

    }
}
