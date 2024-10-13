int pages = int.Parse(Console.ReadLine());  
int pagesPerH = int.Parse(Console.ReadLine());  
int timeLimit = int.Parse(Console.ReadLine());

int day = pages / pagesPerH;

Console.WriteLine(day/timeLimit);