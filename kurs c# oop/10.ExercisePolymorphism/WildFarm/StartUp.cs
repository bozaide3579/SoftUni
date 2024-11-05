using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace WildFarm
{
	public class StartUp
	{
		public static void Main()
		{
			IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();
			IAnimalFactory animalFactory = new AnimalFactory();
			IFoodsFactory foodsFactory = new FoodFactory();

			IEngine engine = new Engine(reader, writer, animalFactory, foodsFactory);

			engine.Run();
		}
	}
}
