
using System.Text;

/*
heVVodar!gniV
ChangeAll:|:V:|:l
Reverse:|:!gnil
InsertSpace:|:5
Reveal

Hiware?uiy
ChangeAll:|:i:|:o
Reverse:|:?uoy
Reverse:|:jd
InsertSpace:|:3
InsertSpace:|:7
Reveal

 */


internal class Program
{
    static void Main()
    {

        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder(text);

        string input;
        while ((input = Console.ReadLine()) != "Reveal") 
        {
            string[] splittedInput = input.Split(":|:");

            if (splittedInput[0] == "InsertSpace")
            {
                int index = int.Parse(splittedInput[1]);

                result.Insert(index, " ");

                Console.WriteLine(result);
            }
            else if (splittedInput[0] == "Reverse")
            {
                string substring = splittedInput[1];

                if (result.ToString().Contains(substring))
                {
                    int startIndex = result.ToString().IndexOf(substring);
                    char[] charArray = substring.ToCharArray();
                    Array.Reverse(charArray);
                    string reversed = new string(charArray);

                    result.Remove(startIndex, substring.Length);

                    result.Append(reversed);

                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (splittedInput[0] == "ChangeAll")
            {
                string substring = splittedInput[1];
                string replacement = splittedInput[2];

                result.Replace(substring, replacement);

                Console.WriteLine(result);
            }
        }

        Console.WriteLine($"You have a new text message: {result}");


    }
}
