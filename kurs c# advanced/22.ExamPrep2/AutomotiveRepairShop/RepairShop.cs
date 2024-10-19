using System;
using System.Reflection;
using System.Text;

namespace AutomotiveRepairShop
{
	public class RepairShop
	{

		public int Capacity { get; }
		public List<Vehicle> Vehicles { get; }


		public RepairShop(int capacity)
		{
			this.Capacity = capacity;
			this.Vehicles = new List<Vehicle>();
		}


		public void AddVehicle(Vehicle vehicle)
		{
			if (Vehicles.Count < Capacity)
			{
				Vehicles.Add(vehicle);
			}
		}

		public bool RemoveVehicle(string vin)
		{
			return Vehicles.RemoveAll(v => v.VIN == vin) > 0;
		}

		public int GetCount()
		{
			return Vehicles.Count;
		}

		public Vehicle GetLowestMileage()
		{
			return Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Vehicles in the preparatory:");

			bool isFirst = true;
			foreach (var car in Vehicles)
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.AppendLine();
				}

				sb.Append($"{car}");
			}

			return sb.ToString().Trim();
		}
	}
}
