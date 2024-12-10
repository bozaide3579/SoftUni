using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
	public class Tests
	{
		private League league;
		[SetUp]
		public void Setup()
		{
			league = new League();
		}

		[Test]
		public void InitaializeLeagueSetsCapacityCorrectly()
		{
			Assert.AreEqual(10, league.Capacity);
			Assert.AreEqual(0, league.Teams.Count);
		}

		[Test]
		public void AddTeamWhenMaxCapacity()
		{
			for (int i = 0; i < league.Capacity; i++)
			{
				league.AddTeam(new Team(i.ToString()));
			}

			var exeption = Assert.Throws<InvalidOperationException>(() =>
			{
				league.AddTeam(new Team("test"));
			});

			Assert.AreEqual("League is full.", exeption.Message);
		}

		[Test]
		public void AddTeamWhenTeamExists()
		{
			league.AddTeam(new Team("test"));

			var exeption = Assert.Throws<InvalidOperationException>(() =>
			{
				league.AddTeam(new Team("test"));
			});

			Assert.AreEqual("Team already exists.", exeption.Message);
		}

		[Test]
		public void AddTeamWorks()
		{
			league.AddTeam(new Team("test"));

			Assert.AreEqual(1, league.Teams.Count);
			Assert.That(league.Teams[0].Name == "test");
		}

		[Test]
		public void RemoveTeamWhenTeamDoesntExistReturnsFalse()
		{
			league.AddTeam(new Team("test"));
			bool result = league.RemoveTeam("None");

			Assert.AreEqual(1, league.Teams.Count);
			Assert.AreEqual(false, result);
		}

		[Test]
		public void RemoveTeamWhenTeamExistReturnsTrue()
		{
			league.AddTeam(new Team("test"));
			bool result = league.RemoveTeam("test");

			Assert.AreEqual(0, league.Teams.Count);
			Assert.AreEqual(true, result);
		}

		[Test]
		public void PlayMatchWhenAwayTeamDoesNotExistsThrow()
		{
			league.AddTeam(new Team("home team"));
			league.AddTeam(new Team("away team"));

			var exeption = Assert.Throws<InvalidOperationException>(() =>
			{
				league.PlayMatch("home team", "none", 2, 3);
			});

			Assert.AreEqual("One or both teams do not exist.", exeption.Message);

		}

		[Test]
		public void PlayMatchWhenHomeTeamDoesNotExistsThrow()
		{
			league.AddTeam(new Team("home team"));
			league.AddTeam(new Team("away team"));

			var exeption = Assert.Throws<InvalidOperationException>(() =>
			{
				league.PlayMatch("none", "away team", 2, 3);
			});

			Assert.AreEqual("One or both teams do not exist.", exeption.Message);

		}

		[Test]
		public void PlayMatchWhenDrawAddsPoints()
		{
			Team homeTeam = new Team("home team");
			Team awayTeam = new Team("away team");
			league.AddTeam(homeTeam);
			league.AddTeam(awayTeam);

			league.PlayMatch("home team", "away team", 3, 3);

			Assert.AreEqual(1, homeTeam.Draws);
			Assert.AreEqual(1, awayTeam.Draws);

		}

		[Test]
		public void PlayMatchWhenHomeWinsAddsPoints()
		{
			Team homeTeam = new Team("home team");
			Team awayTeam = new Team("away team");
			league.AddTeam(homeTeam);
			league.AddTeam(awayTeam);

			league.PlayMatch("home team", "away team", 5, 3);

			Assert.AreEqual(1, homeTeam.Wins);
			Assert.AreEqual(1, awayTeam.Loses);

		}

		[Test]
		public void PlayMatchWhenAwayWinsAddsPoints()
		{
			Team homeTeam = new Team("home team");
			Team awayTeam = new Team("away team");
			league.AddTeam(homeTeam);
			league.AddTeam(awayTeam);

			league.PlayMatch("home team", "away team", 1, 3);

			Assert.AreEqual(1, homeTeam.Loses);
			Assert.AreEqual(1, awayTeam.Wins);

		}

		[Test]
		public void GetTeamInfoWhenTeamDoesNotExistThrows()
		{
			league.AddTeam(new Team("home team"));

			var exeption = Assert.Throws<InvalidOperationException>(() =>
			{
				league.GetTeamInfo("None");
			});

			Assert.AreEqual("Team does not exist.", exeption.Message);

		}

		[Test]
		public void GetTeamInfoWorksCorrectly()
		{
			var team = new Team("home team");
			league.AddTeam(team);

			string result = league.GetTeamInfo("home team");


			Assert.AreEqual(team.ToString(), result);

		}
	}
}