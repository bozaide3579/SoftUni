using NUnit.Framework;
using System;
using System.Linq;

namespace SocialMediaManager.Tests
{
	public class Tests
	{
		private InfluencerRepository repository;

		[SetUp]
		public void Setup()
		{
			repository = new InfluencerRepository();
		}

		[Test]
		public void Constructor_Should_Initialize_Repository()
		{
			Assert.IsNotNull(repository.Influencers);
			Assert.AreEqual(0, repository.Influencers.Count);
		}

		[Test]
		public void RegisterInfluencer_Should_Add_Influencer_When_Valid()
		{
			Influencer influencer = new Influencer("john_doe", 1000);
			string result = repository.RegisterInfluencer(influencer);

			Assert.AreEqual(1, repository.Influencers.Count);
			Assert.IsTrue(repository.Influencers.Contains(influencer));
			Assert.AreEqual("Successfully added influencer john_doe with 1000", result);
		}

		[Test]
		public void RegisterInfluencer_Should_Throw_ArgumentNullException_When_Null()
		{
			Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(null));
		}

		[Test]
		public void RegisterInfluencer_Should_Throw_InvalidOperationException_When_Username_Already_Exists()
		{
			Influencer influencer = new Influencer("john_doe", 1000);
			repository.RegisterInfluencer(influencer);

			Influencer duplicate = new Influencer("john_doe", 2000);

			var ex = Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(duplicate));
			Assert.AreEqual("Influencer with username john_doe already exists", ex.Message);
		}

		[Test]
		public void RemoveInfluencer_Should_Return_True_When_Influencer_Exists()
		{
			Influencer influencer = new Influencer("john_doe", 1000);
			repository.RegisterInfluencer(influencer);

			bool result = repository.RemoveInfluencer("john_doe");

			Assert.IsTrue(result);
			Assert.AreEqual(0, repository.Influencers.Count);
		}

		[Test]
		public void RemoveInfluencer_Should_Return_False_When_Influencer_Does_Not_Exist()
		{
			bool result = repository.RemoveInfluencer("nonexistent_user");

			Assert.IsFalse(result);
		}

		[Test]
		public void RemoveInfluencer_Should_Throw_ArgumentNullException_When_Username_Is_Null_Or_Whitespace()
		{
			Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(null));
			Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer("   "));
		}

		[Test]
		public void GetInfluencerWithMostFollowers_Should_Return_Correct_Influencer()
		{
			Influencer influencer1 = new Influencer("john_doe", 1000);
			Influencer influencer2 = new Influencer("jane_doe", 2000);
			Influencer influencer3 = new Influencer("alex_smith", 1500);

			repository.RegisterInfluencer(influencer1);
			repository.RegisterInfluencer(influencer2);
			repository.RegisterInfluencer(influencer3);

			Influencer mostFollowers = repository.GetInfluencerWithMostFollowers();

			Assert.AreEqual(influencer2, mostFollowers);
		}

		[Test]
		public void GetInfluencerWithMostFollowers_Should_Throw_Exception_When_Repository_Is_Empty()
		{
			var ex = Assert.Throws<IndexOutOfRangeException>(() => repository.GetInfluencerWithMostFollowers());
			Assert.AreEqual("Index was outside the bounds of the array.", ex.Message);
		}


		[Test]
		public void GetInfluencer_Should_Return_Correct_Influencer()
		{
			Influencer influencer = new Influencer("john_doe", 1000);
			repository.RegisterInfluencer(influencer);

			Influencer result = repository.GetInfluencer("john_doe");

			Assert.AreEqual(influencer, result);
		}

		[Test]
		public void GetInfluencer_Should_Return_Null_When_Influencer_Does_Not_Exist()
		{
			Influencer result = repository.GetInfluencer("nonexistent_user");

			Assert.IsNull(result);
		}
	}
}
