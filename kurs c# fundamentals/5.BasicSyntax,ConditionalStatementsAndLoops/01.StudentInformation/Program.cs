string name = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
float grade = float.Parse(Console.ReadLine());

Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade:f2}");