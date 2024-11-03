using MilitaryElite.Interfaces;
using System.Diagnostics;

namespace MilitaryElite
{
	public class Program
	{
		public static void Main()
		{
			Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

			string input = Console.ReadLine();
			while (input != "End")
			{
				string[] data = input
					.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				ISoldier? soldier = null;
				if (data[0] == "Private")
				{
					soldier = CreatePrivate(data);
				}
				else if (data[0] == "LieutenantGeneral")
				{
					soldier = CreateLieutenantGeneral(data, soldiers);
				}
				else if (data[0] == "Engineer")
				{
					soldier = CreateEngineer(data);
				}
				else if (data[0] == "Commando")
				{
					soldier = CreateCommando(data);
				}
				else if (data[0] == "Spy")
				{
					soldier = CreateSpy(data);
				}

				if (soldier != null)
				{
					soldiers[soldier.Id] = soldier;

                    Console.WriteLine(soldier);
                }

				input = Console.ReadLine();
			}

		}
		private static Private CreatePrivate(string[] data)
		{
			return new Private(int.Parse(data[1]), data[2], data[3], decimal.Parse(data[4]));
		}

		private static LieutenantGeneral CreateLieutenantGeneral (string[] data, Dictionary<int, ISoldier> allSoldiers)
		{
			IEnumerable<ISoldier> privates = data.Skip(5).Select(int.Parse).Select(id => allSoldiers[id]);
			return new LieutenantGeneral(int.Parse(data[1]), data[2], data[3], decimal.Parse(data[4]), privates);
		}

		private static Engineer? CreateEngineer(string[] data)
		{
			if (!CorpsIsValid(data[5])) return null;

			List<IRepair> repairs = new List<IRepair>();
			for(int i = 6; i < data.Length; i += 2)
			{
				Repair currentRepair = new Repair(data[i], int.Parse(data[i + 1]));
				repairs.Add(currentRepair);
			}

			return new Engineer(int.Parse(data[1]), data[2], data[3], decimal.Parse(data[4]), data[5], repairs);
		}

		private static Commando? CreateCommando(string[] data)
		{
			if (!CorpsIsValid(data[5])) return null;

			List<IMission> missions = new List<IMission>();
			for(int i = 6;i < data.Length; i += 2)
			{
				if (!MissionStateIsValid(data[i + 1])) continue;

				Mission currentMission = new Mission(data[i], data[i + 1]);
				missions.Add(currentMission);
			}

			return new Commando(int.Parse(data[1]), data[2], data[3], decimal.Parse(data[4]), data[5], missions);
		}

		private static Spy CreateSpy(string[] data)
		{
			return new Spy(int.Parse(data[1]), data[2], data[3], int.Parse(data[4]));
		}

		private static bool CorpsIsValid(string corps)
		{
			return corps == "Airforces" || corps == "Marines";
		}

		private static bool MissionStateIsValid(string state)
		{
			return state == "InProgress" || state == "Finished";
		}
	}
}
