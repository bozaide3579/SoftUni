using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
	public class Engine : IEngine
	{
		private IReader reader;
		private IWriter writer;
		private IVehicleFactory factory;

		private ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory factory)
        {
            this.reader = reader;
			this.writer = writer;
			this.factory = factory;

			vehicles = new List<IVehicle>();
        }

        public void Run()
		{
			vehicles.Add(Create());
			vehicles.Add(Create());

			int commandsCount = int.Parse(reader.ReadLine());

			for (int i = 0; i < commandsCount; i++)
			{
				string[] commandTokens = reader.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				string command = commandTokens[0];
				string vehicleType = commandTokens[1];

				IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

				if (command == "Drive")
				{
					double distance = double.Parse(commandTokens[2]);

					bool isDriven = vehicle.Drive(distance);

                    if (isDriven)
                    {
						writer.WriteLine($"{vehicleType} travelled {distance} km");
                    }
					else
					{
						writer.WriteLine($"{vehicleType} needs refueling");
					}
                }
				else if (command == "Refuel")
				{
					double amount = double.Parse(commandTokens[2]);

					vehicle.Refuel(amount);
				}
			}

			foreach (var vehicle in vehicles)
			{
				writer.WriteLine(vehicle.ToString());
			}
		}
		private IVehicle Create()
		{
			string[] tokens = reader.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			IVehicle vehicle = factory.CreateVehicle(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));

			return vehicle;
		}
	}
}
