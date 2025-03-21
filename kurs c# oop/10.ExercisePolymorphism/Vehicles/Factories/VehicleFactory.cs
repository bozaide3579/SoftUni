﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
	public class VehicleFactory : IVehicleFactory
	{
		public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
		{
			switch (type)
			{
				case "Car": return new Car(fuelQuantity, fuelConsumption);
				case "Truck":return new Truck(fuelQuantity, fuelConsumption);
				default: throw new ArgumentException("Invalid vehicle type");
					
			}
		}
	}
}
