namespace CarManufacturer
{
	public class StartUp
	{
		public static void Main()
		{
			//Car car = new Car()
			//{
			//	Make = "Mercedes",
			//	Model = "S-class",
			//	Year = 2010,
			//	FuelQuantity = 1000,
			//	FuelConsumption = 10
			//};

			//car.Drive(55);

			//Console.WriteLine(car.WhoAmI());

			//car.Drive(100);

			Car defaultCar = new Car();
			Console.WriteLine(defaultCar.WhoAmI());

			Car car = new Car("BMW", "5", 2012);
            Console.WriteLine(car.WhoAmI());

            Car fullCar = new Car("BMW", "5", 2012, 150, 25);
            Console.WriteLine(fullCar.WhoAmI());

			Tire[] tires = new Tire[2]
			{
				new Tire (2012, 3),
				new Tire (2012, 2)
			};

			Engine engine = new Engine(250, 3000);

			Car enginedCar = new Car("BMW", "5", 2012, 150, 25, engine, tires);
            Console.WriteLine(enginedCar.WhoAmI());

        }
	}
}
