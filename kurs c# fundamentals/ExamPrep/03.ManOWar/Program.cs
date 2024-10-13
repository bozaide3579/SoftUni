using System;

namespace _03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHp = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] commands = input.Split();


                if (commands[0] == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int damage = int.Parse(commands[2]);

                    if (index >= 0 && index < warShip.Count)
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }

                }
                else if (commands[0] == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int damage = int.Parse(commands[3]);

                    if (startIndex >= 0 && startIndex < pirateShip.Count &&
                        endIndex >= 0 && endIndex < pirateShip.Count &&
                        startIndex <= endIndex)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }

                }
                else if (commands[0] == "Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHp)
                        {
                            pirateShip[index] = maxHp;
                        }
                    }
                }
                else if (commands[0] == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < maxHp * 0.2)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
            }


            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");

        }
    }
}