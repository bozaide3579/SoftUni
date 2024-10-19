using System.Text;

namespace SharkTaxonomy
{
	public class Classifier
	{
		public int Capacity { get; }
		public List<Shark> Species { get; }
		public int GetCount => this.Species.Count;

		public Classifier(int capacity)
		{
			Capacity = capacity;
			Species = new List<Shark>();
		}

		public void AddShark(Shark shark)
		{
			if (this.Species.Count < Capacity
				&& !this.Species.Any(s => s.Kind == shark.Kind))
			{
				Species.Add(shark);
			}
		}

		public bool RemoveShark(string kind)
		{
			Shark? remove = this.Species.FirstOrDefault(s => s.Kind == kind);
			if (remove is null)
			{
				return false;
			}

			return this.Species.Remove(remove);
		}

		public Shark GetLargestShark()
		{
			return this.Species.OrderByDescending(s => s.Length).First();
		}

		public double GetAverageLength()
		{
			return this.Species.Average(s => s.Length);
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{this.GetCount} sharks classified:");

			foreach (Shark shark in this.Species)
			{
				sb.AppendLine();
				sb.Append(shark.Kind);
			}

			return sb.ToString();
		}
	}
}
