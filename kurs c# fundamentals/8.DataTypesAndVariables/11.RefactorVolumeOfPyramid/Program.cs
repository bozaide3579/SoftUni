﻿double lenght, width, height = 0;

Console.Write("Length: ");

lenght = double.Parse(Console.ReadLine());

Console.Write("Width: ");

width = double.Parse(Console.ReadLine());

Console.Write("Height: ");

height = double.Parse(Console.ReadLine());

double volume = (lenght * width * height) / 3;

Console.Write($"Pyramid Volume: {volume:f2}");