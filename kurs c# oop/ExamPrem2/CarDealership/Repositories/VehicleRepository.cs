using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
	public class VehicleRepository : IRepository<IVehicle>
	{
		private readonly Dictionary<string, IVehicle> _vehicles = new Dictionary<string, IVehicle>();

        public IReadOnlyCollection<IVehicle> Models => this._vehicles.Values;

		public void Add(IVehicle vehicle)
		{
			_vehicles[vehicle.Model] = vehicle;
		}

		public bool Exists(string text)
		{
			return _vehicles.ContainsKey(text);
		}

		public IVehicle Get(string text)
		{
			if (!Exists(text)) return null;
			return _vehicles[text];
		}

		public bool Remove(string text)
		{
			return _vehicles.Remove(text);
		}
	}
}
