using System.Threading.Channels;

namespace AutomotiveRepairShop
{
	public class Vehicle
	{


		public string VIN { get; }
		public int Mileage { get; }
		public string Damage { get; }

		public Vehicle(string vin, int mileage, string damage)
		{
			this.VIN = vin;
			this.Mileage = mileage;
			this.Damage = damage;
		}

		public override string ToString()
		{
			return $"Damage: {this.Damage}, Vehicle: {this.VIN} ({this.Mileage} km)".ToString().Trim();
		} 
	}
}
