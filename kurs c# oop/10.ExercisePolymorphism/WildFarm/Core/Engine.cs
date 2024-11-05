using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
	public class Engine : IEngine
	{
		private IReader _reader;
		private IWriter _writer;

		private IAnimalFactory _animalFactory;
		private IFoodsFactory _foodsFactory;

		ICollection<IAnimal> _animals;
		public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodsFactory foodsFactory)
		{
			this._reader = reader;
			this._writer = writer;
			this._animalFactory = animalFactory;
			this._foodsFactory = foodsFactory;

			_animals = new List<IAnimal>();
		}
		public void Run()
		{
			string command = null;
			while ((command = _reader.ReadLine()) != "End")
			{
				IAnimal animal = CreateAnimal(command);
				IFood food = CreateFood();

				_writer.WriteLine(animal.ProduceSound());

				bool isEaten = animal.Eat(food);

				if (!isEaten)
				{
					_writer.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
				}

				_animals.Add(animal);

			}

			foreach (IAnimal animal in _animals)
			{
				_writer.WriteLine(animal.ToString());
			}
		}

		private IAnimal CreateAnimal(string command)
		{
			string[] animalTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			IAnimal animal = _animalFactory.CreateAnimal(animalTokens);

			return animal;
		}

		private IFood CreateFood()
		{
			string[] foodTokens = _reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

			string foodType = foodTokens[0];
			int quantity = int.Parse(foodTokens[1]);

			IFood food = _foodsFactory.CreateFood(foodType, quantity);

			return food;
		}
	}
}
