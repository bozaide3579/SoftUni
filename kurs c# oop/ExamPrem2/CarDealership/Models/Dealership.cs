using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
	public class Dealership : IDealership
	{
		public IRepository<IVehicle> Vehicles { get; } = new VehicleRepository();
		public IRepository<ICustomer> Customers { get; } = new CustomerRepository();
	}
}
