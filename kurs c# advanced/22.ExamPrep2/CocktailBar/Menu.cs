using System.Reflection;
using System.Text;

namespace CocktailBar
{
	public class Menu
	{
		public Menu(int barCapacity)
		{
			this.Cocktails = new List<Cocktail>();
			this.BarCapacity = barCapacity;
		}

		public List<Cocktail> Cocktails { get; }
		public int BarCapacity { get; }


		public void AddCocktail(Cocktail cocktail)
		{
			if (this.Cocktails.Count < this.BarCapacity
				&& !this.Cocktails.Any(c => c.Name == cocktail.Name))
			{
				this.Cocktails.Add(cocktail);
			}
			else
			{
				return;
			}
		}

		public bool RemoveCocktail(string name)
		{
			return this.Cocktails.RemoveAll(c => c.Name == name) > 0;
		}


		public Cocktail? GetMostDiverse()
		{
			return this.Cocktails.MaxBy(c => c.Ingredients.Count);
		}

		public string Details(string cocktailName)
		{
			return this.Cocktails.Single(c => c.Name == cocktailName).ToString();
		}

		public string GetAll()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("All Cocktails:");

			bool isFirst = true;
			foreach (Cocktail cocktail in this.Cocktails.OrderBy(c => c.Name))
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.AppendLine();
				}

				sb.Append(cocktail.Name);
			}

			return sb.ToString().Trim();
		}
	}
}
