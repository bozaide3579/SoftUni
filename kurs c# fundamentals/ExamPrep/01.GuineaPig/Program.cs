﻿
internal class Program
{
    static void Main(string[] args)
    {
        double food = double.Parse(Console.ReadLine());
        double hay = double.Parse(Console.ReadLine());
        double cover = double.Parse(Console.ReadLine());
        double weight = double.Parse(Console.ReadLine());
        int days = 30;


        for (int i = 1; i <= days; i++) 
        {
            food -= 0.3;
            if (food < 0)
            {
                Console.WriteLine("Merry must go to the pet store!");
                break;
            }
            
            if (i % 2 == 0)
            {
                hay -= food * 0.05;
                if (hay < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    break;
                }
            }

            if (i % 3 == 0)
            {
                cover -= weight / 3;
                if (cover < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    break;
                }
            }
        }

        if (food >= 0 && hay >= 0 && cover >= 0)
        {
        Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");

        }
    }
}
