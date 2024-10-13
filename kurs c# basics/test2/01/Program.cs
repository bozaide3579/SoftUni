

double page = double.Parse(Console.ReadLine()); 

double korica = double.Parse(Console.ReadLine());   

double discount = double.Parse(Console.ReadLine()); 

double desiner = double.Parse(Console.ReadLine());  

double price = double.Parse(Console.ReadLine());

double bookprice = page * 899 + korica * 2;

double discountedBook = (bookprice - (bookprice * discount/100));

double discountedBook2 = discountedBook + desiner;

double finalp = (discountedBook2 - (discountedBook2 * price/100));

Console.WriteLine($"Avtonom should pay {finalp:f2} BGN.");

