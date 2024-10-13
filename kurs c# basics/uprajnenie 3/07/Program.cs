
string month = Console.ReadLine();
int nights = int.Parse(Console.ReadLine());
double sPrice = 0;
double aPrice = 0;
string type = string.Empty;

if (month == "May" || month == "October")
{
    
            sPrice = 50;
            if (nights > 7 && nights < 14)
            {
                sPrice = sPrice * 0.95;
            }
            else if (nights > 14)
                sPrice = sPrice * 0.70;
            

       
            aPrice = 65;
            if (nights > 14)
            {
                aPrice = aPrice * 0.90;
            }
           
    
  
}
else if (month == "June" || month == "September")
{
 
            sPrice = 75.20;
            if (nights > 14)
            {
                sPrice = sPrice * 0.80;
            }
           

       
            aPrice = 68.70;
            if (nights > 14)
            {
                aPrice = aPrice * 0.90;
            }
     
   
  

}
else if (month == "July" || month == "August")
{
 
            sPrice = 76.00;
           
         
       
            aPrice = 77.00;
            if (nights > 14)
            {
                aPrice = aPrice * 0.90;
            }
         
            
    
}
    Console.WriteLine($"Apartment: {aPrice * nights:f2} lv.");
    Console.WriteLine($"Studio: {sPrice * nights:f2} lv.");


