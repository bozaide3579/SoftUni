string shape = Console.ReadLine();


if (shape == "square")
{
    double sqareSide = double.Parse(Console.ReadLine());

    double sFace = sqareSide * sqareSide;

    Console.WriteLine($"{sFace:f3}");
}
else if (shape == "rectangle")
{
    double rectSide1 = double.Parse(Console.ReadLine());

    double rectSide2 = double.Parse(Console.ReadLine());

    double rectFace = rectSide1 * rectSide2;

    Console.WriteLine($"{rectFace:f3}");
}
else if (shape == "circle")
{
    double circleRadius = double.Parse(Console.ReadLine());

    double circleFace = Math.PI * (circleRadius * circleRadius);

    Console.WriteLine( $"{circleFace:f3}");
}
else if (shape == "triangle")
{
    double triangleL = double.Parse(Console.ReadLine());    

    double trinagleH = double.Parse(Console.ReadLine());    

    double trinagleFace = 0.5 * triangleL * trinagleH;

    Console.WriteLine($"{trinagleFace:f3}");
}