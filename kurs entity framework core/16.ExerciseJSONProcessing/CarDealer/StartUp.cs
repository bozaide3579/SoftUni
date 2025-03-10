﻿using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.DynamicProxy.Generators;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarDealer
{
	public class StartUp
	{
		public static void Main()
		{
			CarDealerContext context = new CarDealerContext();

			//ImportSuppliers
			//string suppliersString = File.ReadAllText("../../../Datasets/suppliers.json");
			//Console.WriteLine(ImportSuppliers(context, suppliersString));

			//ImportParts
			//string partsString = File.ReadAllText("../../../Datasets/parts.json");
			//Console.WriteLine(ImportParts(context, partsString));

			//ImportCars
			string carsString = File.ReadAllText("../../../Datasets/cars.json");
			Console.WriteLine(ImportCars(context, carsString));
		}

		public static string ImportSuppliers(CarDealerContext context, string inputJson)
		{
			List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

			context.Suppliers.AddRange(suppliers);
			context.SaveChanges();

			return $"Successfully imported {suppliers.Count}.";
		}

		public static string ImportParts(CarDealerContext context, string inputJson)
		{
			// 1. Deserialize to List of parts
			var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

			// 2. Get list of valid ids 
			var validSupplierIds = context.Suppliers
				.Select(x => x.Id)
				.ToArray();

			// 3. Filter Parts based on valid ids
			var partsWithValidSupplierIds = parts
				.Where(p => validSupplierIds.Contains(p.SupplierId))
				.ToArray();

			context.Parts.AddRange(partsWithValidSupplierIds);
			context.SaveChanges();

			return $"Successfully imported {partsWithValidSupplierIds.Length}.";
		}

		public static string ImportCars(CarDealerContext context, string inputJson)
		{
			var carsDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

			var cars = new HashSet<Car>();
			var partsCars = new HashSet<PartCar>();

			foreach (var carDto in carsDtos)
			{
				var newCar = new Car()
				{
					Make = carDto.Make,
					Model = carDto.Model,
					TraveledDistance = carDto.TraveledDistance
				};

				cars.Add(newCar);
				foreach (var partId in carDto.PartsId.Distinct())
				{
					partsCars.Add(new PartCar()
					{
						Car = newCar,
						PartId = partId
					});
				}
			}
			context.Cars.AddRange(cars);
			context.PartsCars.AddRange(partsCars);

			context.SaveChanges();

			return $"Successfully imported {cars.Count}.";
		}

	}
}