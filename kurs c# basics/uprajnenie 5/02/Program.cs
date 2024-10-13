int badGrades = int.Parse(Console.ReadLine());

int sum = 0;
int count = 0;
int failedCount = 0;    

string input = Console.ReadLine();  
string lastEx = string .Empty;
int grade;

while (input != "Enough")
{
    lastEx = input;
    grade = int.Parse(Console.ReadLine());  

    if (grade <= 4)
    {
        failedCount++;
        if (failedCount == badGrades)
        {
            Console.WriteLine($"You need a break, {failedCount} poor grades.");
            break;
        }
    }
    count++;
    sum += grade;

    input =Console.ReadLine();
}

if (input == "Enough")
{
    Console.WriteLine($"Average score: {(double)sum/ count:f2}");
    Console.WriteLine($"Number of problems: {count}");
    Console.WriteLine($"Last problem: {lastEx}");

}

