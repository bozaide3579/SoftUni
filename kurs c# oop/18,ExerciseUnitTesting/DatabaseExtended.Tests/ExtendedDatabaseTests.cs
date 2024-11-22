namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
	using System.Collections.Generic;
	using System.Linq;
	using System;
	using ExtendedDatabase;

	[TestFixture]
	public class ExtendedDatabaseTests
	{
		private const int MaxDatabaseSize = 16;

		[TestCaseSource(nameof(GetValidDatabaseSizes))]
		public void DatabaseShouldBeInitializedCorrectly(int n)
		{
			Person[] data = GenerateRandomArray(n);

			Database database = new Database(data);

			AssertCorrectContent(database, data);
		}

		[Test]
		public void AddShouldWorkCorrectly()
		{
			Person[] data = GenerateRandomArray(MaxDatabaseSize);
			Database database = new Database();

			for (int i = 0; i < MaxDatabaseSize; i++)
			{
				database.Add(data[i]);
				AssertCorrectContent(database, data.Take(i + 1).ToArray());
			}
		}

		[Test]
		public void RemoveShouldWorkCorrectly()
		{
			Person[] data = GenerateRandomArray(MaxDatabaseSize);

			Database database = new Database(data.ToArray());

			for (int i = 0; i < MaxDatabaseSize; i++)
			{
				database.Remove();
				AssertCorrectContent(database, data.Take(MaxDatabaseSize - (i + 1)).ToArray());
			}
		}

		[Test]
		public void AddOffLimitShouldThrowAnExeption()
		{
			Database database = new Database(GenerateRandomArray(MaxDatabaseSize));

			Assert.Throws<InvalidOperationException>(
				() => database.Add(GenerateRandomPerson())
			);
		}

		[Test]
		public void AddUserWithDuplicateIdShouldThrowAnExeption()
		{

		}

		[Test]
		public void RemoveFromEmptyDatabaseShouldThrowAnExeption()
		{
			Database database = new Database();

			Assert.Throws<InvalidOperationException>(() => database.Remove());
		}

		public static IEnumerable<object[]> GetValidDatabaseSizes()
		{
			for (int i = 0; i <= MaxDatabaseSize; i++)
				yield return new object[] { i };
		}

		private static Person[] GenerateRandomArray(int n)
		{
			Person[] result = new Person[n];
			for (int i = 0; i < n; i++) 
				result[i] = GenerateRandomPerson();

			return result;
		}

		private static Person GenerateRandomPerson()
		=> new Person(Random.Shared.NextInt64(), GenerateRandomString());

		private static (char Begin, int Lenght)[] _characterGroups = { ('a', 26), ('A', 26), ('0', 10) };

		private static string GenerateRandomString()
		{
			char[] content = new char[Random.Shared.Next(5, 30)];

			for (int i = 0; i < content.Length; i++)
			{
				int randomGroupIndex = Random.Shared.Next(_characterGroups.Length);
				content[i] = (char)(_characterGroups[randomGroupIndex].Begin + Random.Shared.Next(_characterGroups[randomGroupIndex].Lenght));
			}

			return new string(content);	
		}

		

		private static void AssertCorrectContent(Database database, Person[] expectedData)
		{
			Assert.That(database.Count, Is.EqualTo(expectedData.Length));

			for (int i = 0; i < expectedData.Length; i++)
			{
				Person findResult1 = database.FindById(expectedData[i].Id);
				Assert.That(findResult1, Is.Not.Null);
				Assert.That(findResult1, Is.SameAs(expectedData[i]));

				Person findResult2 = database.FindByUsername(expectedData[i].UserName);
				Assert.That(findResult2 , Is.Not.Null);
				Assert.That(findResult2, Is.SameAs(expectedData[i]));
			}
		}
	}
}