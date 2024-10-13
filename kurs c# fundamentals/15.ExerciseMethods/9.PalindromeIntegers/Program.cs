class Program
{
    static void Main()
    {
        while (true)
        {

            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }


           
            if (IsPalindrome(input))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false); ;
            }





        }
    }

     static bool IsPalindrome(string number)
    {
        for (int i = 0; i < number.Length / 2; i++) 
        {
            if (number[i] == number[number.Length - i - 1]) 
            { 
                return true; 
            }
        }
        return false;
    }
}


