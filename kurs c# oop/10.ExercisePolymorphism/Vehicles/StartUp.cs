using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles
{
	public class StartUp
	{
		public static void Main()
		{
			IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();
			IVehicleFactory factory = new VehicleFactory();

			IEngine engine = new Engine(reader, writer, factory);

			engine.Run();
        }
	}
}
