using System.Text;
using System.Xml.Linq;

namespace CreaturesOfTheCode
{
    public class MythicalCreaturesHub
    {
        public List<Creature> Creatures { get;}
        public int Capacity { get;}

        public MythicalCreaturesHub(int capacity)
        {
            Capacity = capacity;
            Creatures = new List<Creature>();
        }


        public void AddCreature(Creature creature)
        {
            if (Creatures.Count < Capacity)
            {
                if (!Creatures.Any(c => c.Name.Equals(creature.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    Creatures.Add(creature);
                }
            }
        }

        public bool RemoveCreature(string name)
        {
			return this.Creatures.RemoveAll(c => c.Name == name) > 0;
		}

        public Creature GetStrongestCreature()
        {
			return Creatures.OrderByDescending(c => c.Health).First();
		}

        public string Details(string creatureName)
        {
			var creature = Creatures.FirstOrDefault(c => c.Name.Equals(creatureName, StringComparison.OrdinalIgnoreCase));
			if (creature != null)
			{
				return creature.ToString();
			}
			return $"Creature with the name {creatureName} not found.";
		}

        public string GetAllCreatures()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine ("Mythical Creatures:");

            bool isFirst = true;
            foreach (Creature creature in Creatures.OrderBy(c => c.Name))
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sb.AppendLine();
                }

                sb.Append($"{creature.Name} -> {creature.Kind}");
            }

            return sb.ToString().Trim();
		}

	}
}
