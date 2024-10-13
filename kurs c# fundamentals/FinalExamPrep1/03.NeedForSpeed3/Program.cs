
internal class Program
{
    class Car
    {
        public string Name;
        public int Milage;
        public int Fuel;

        public Car(string name, int milage, int fuel)
        {
            Name = name;
            Milage = milage;
            Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Milage} kms, Fuel in the tank: {Fuel} lt.";
        }

    }
    static void Main()
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] splittedInput = Console.ReadLine().Split("|");
            string name = splittedInput[0];
            int milage = int.Parse(splittedInput[1]);
            int fuel = int.Parse(splittedInput[2]);

            Car car = new Car(name, milage, fuel);

            cars.Add(name, car);
        }

        string input;
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] arguments = input.Split(" : ");


            if (arguments[0] == "Drive")
            {
                string name = arguments[1];
                int distance = int.Parse(arguments[2]);
                int fuel = int.Parse(arguments[3]);

                Car car = cars[name];

                if (car.Fuel < fuel)
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }
                else
                {
                    car.Milage += distance;
                    car.Fuel -= fuel;
                    Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                    if (car.Milage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car.Name}!");
                        cars.Remove(car.Name);
                    }
                }
            }
            else if (arguments[0] == "Refuel")
            {
                string name = arguments[1];
                int fuel = int.Parse(arguments[2]);

                Car car = cars[name];

                if (car.Fuel + fuel > 75)
                {
                    fuel = 75 - car.Fuel;

                }

                car.Fuel += fuel;
                Console.WriteLine($"{car.Name} refueled with {fuel} liters");

            }
            else if (arguments[0] == "Revert")
            {
                string name = arguments[1];
                int km = int.Parse(arguments[2]);

                Car car = cars[name];

                if (car.Milage - km < 10000)
                {
                    car.Milage = 10000;
                }
                else
                {
                    car.Milage -= km;
                    Console.WriteLine($"{car.Name} mileage decreased by {km} kilometers");
                }
            }
        }

        foreach (var (_, car) in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}
