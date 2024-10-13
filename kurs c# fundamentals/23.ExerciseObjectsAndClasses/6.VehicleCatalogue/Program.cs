
using System.Xml;

internal class Program
{
    public enum CarType
    {
        Car,
        Truck
    }

    public class Car
    {
        public CarType Type;
        public string Model;
        public string Colour { get; set; }
        public decimal HP { get; set; }

        public Car(string type, string model, string colour, string hp)
        {
            Type = type.ToLower() == "car" ? CarType.Car : CarType.Truck;
            Model = model;
            Colour = colour;
            HP = decimal.Parse(hp);
        }

        public override string ToString()
        {
            return $"Type: {Type}\nModel: {Model}\nColor: {Colour}\nHorsepower: {HP}";
        }
    }

    static void Main(string[] args)
    {

        List<Car> catalogue = new List<Car>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();

            string type = arguments[0];
            string model = arguments[1];
            string colour = arguments[2];
            string hp = arguments[3];

            Car car = new Car(type, model, colour, hp);
            catalogue.Add(car);
        }


        while ((input = Console.ReadLine()) != "Close the Catalogue")
        {
            string carModel = input;

            Car foundCar = catalogue.Find(c => c.Model == carModel);

            if (foundCar != null)
            {
                string result = foundCar.ToString();
                Console.WriteLine(result);
            }
        }

        decimal avgHp = catalogue
            .Where(car => car.Type == CarType.Car)
            .Select(car => car.HP)
            .DefaultIfEmpty(0)
            .Average();

        Console.WriteLine($"Cars have average horsepower of: {avgHp:f2}.");

        avgHp = catalogue
            .Where(car => car.Type == CarType.Truck)
            .Select(car => car.HP)
            .DefaultIfEmpty(0)
            .Average();

        Console.WriteLine($"Trucks have average horsepower of: {avgHp:f2}.");
    }
}
