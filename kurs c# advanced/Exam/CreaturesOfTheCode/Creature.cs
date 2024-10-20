using System.Text;

namespace CreaturesOfTheCode
{
    public class Creature
    {
		public Creature(string name, string kind, int health, string abilities)
		{
			Name = name;
			Kind = kind;
			Health = health;
			Abilities = abilities.Split(", ").ToList();
		}

		public string Name { get; }
        public string Kind { get; }
        public int Health { get; }
        public List<string> Abilities { get; }


		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{Name} ({Kind}) has {Health} HP");
			sb.Append($"Abilities: {string.Join(", ", Abilities)}");

			return sb.ToString();
		}
	}
}
