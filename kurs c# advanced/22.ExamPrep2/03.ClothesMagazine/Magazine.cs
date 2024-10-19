using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
	public class Magazine
	{
		public string Type { get; }
		public int Capacity { get; }
		public List<Cloth> Clothes { get; }

		public Magazine(string type, int capacity)
		{
			Type = type;
			Capacity = capacity;
			Clothes = new List<Cloth>();
		}


		public void AddCloth(Cloth cloth)
		{
			if (Clothes.Count < Capacity)
			{
				Clothes.Add(cloth);
			}
		}

		public bool RemoveCloth(string color)
		{
			if (Clothes.RemoveAll(c => c.Color == color) > 0)
			{
				return true;
			}
			return false;
		}

		public Cloth GetSmallestCloth()
		{
			return Clothes.OrderBy(c => c.Size).First();
		}

		public Cloth GetCloth(string color)
		{
			return Clothes.FirstOrDefault(c => c.Color == color)!;
		}

		public int GetClothCount()
		{
			return Clothes.Count;
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{Type} magazine contains:");

			bool isFirst = true;
			foreach (var c in Clothes.OrderBy(c => c.Size))
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.AppendLine();
				}

				sb.Append($"{c}");
			}

			return sb.ToString().Trim();
		}
	}
}
