
internal class Program
{
	class Hero
	{
		public string Name { get; set; }
		public int Hp { get; set; }
		public int Mp { get; set; }

		public Hero(string name, int hp, int mp)
		{
			Name = name;
			Hp = hp;
			Mp = mp;
		}
	}
	static void Main()
	{
		Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
		int n = int.Parse(Console.ReadLine());

		for (int i = 0; i < n; i++)
		{
			string HeroInput = Console.ReadLine();
			string[] splittedInput = HeroInput.Split(" ");

			string heroName = splittedInput[0];
			int hp = int.Parse(splittedInput[1]);
			int mp = int.Parse(splittedInput[2]);

			if (hp > 100)
			{
				hp = 100;
			}
			if (mp > 200)
			{
				mp = 200;
			}

			Hero hero = new Hero(heroName, hp, mp);
			heroes.Add(heroName, hero);
		}

		string input;
		while ((input = Console.ReadLine()) != "End")
		{
			string[] splittedInput = input.Split(" - ");
			string name = splittedInput[1];

			if (splittedInput[0] == "CastSpell")
			{
				int mp = int.Parse(splittedInput[2]);
				string spell = splittedInput[3];

				if (heroes[name].Mp >= mp)
				{
					heroes[name].Mp -= mp;
					Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name].Mp} MP!");
				}
				else
				{
					Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
				}
			}
			else if (splittedInput[0] == "TakeDamage")
			{
				int damage = int.Parse(splittedInput[2]);
				string attacker = splittedInput[3];

				heroes[name].Hp -= damage;

				if (heroes[name].Hp > 0)
				{
					Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].Hp} HP left!");
				}
				else
				{
                    Console.WriteLine($"{name} has been killed by {attacker}!");
					heroes.Remove(name);
                }
			}
			else if (splittedInput[0] == "Recharge")
			{
				int mp = int.Parse(splittedInput[2]);
				int initalMp = heroes[name].Mp;

				heroes[name].Mp += mp;
				if (heroes[name].Mp > 200)
				{
					heroes[name].Mp = 200;
				}

                Console.WriteLine($"{name} recharged for {heroes[name].Mp - initalMp} MP!");
            }
			else if (splittedInput[0] == "Heal")
			{
				int hp = int.Parse(splittedInput[2]);
				int initalHp = heroes[name].Hp;

				heroes[name].Hp += hp;
				if (heroes[name].Hp > 100)
				{
					heroes[name].Hp = 100;
				}

				Console.WriteLine($"{name} healed for {heroes[name].Hp - initalHp} HP!");
            }
		}

		foreach (var hero in heroes)
		{
            Console.WriteLine(hero.Value.Name);
            Console.WriteLine($"  HP: {hero.Value.Hp}");
            Console.WriteLine($"  MP: {hero.Value.Mp}");
        }
	}
}

/*
 
2
Solmyr 85 120
Kyrre 99 50
Heal - Solmyr - 10
Recharge - Solmyr - 50
TakeDamage - Kyrre - 66 - Orc
CastSpell - Kyrre - 15 - ViewEarth
End

 */