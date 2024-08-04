using NUnit.Framework.Constraints;
using PL.Core.Enumerations;
using PL.Core.Models;

namespace PL.Core.Tests
{
	public class BotTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CreateBotAndCheckProperties_SuccessfullyCreated()
		{
			Bot bot = new Bot(default, new Coordinates2D(1, 1));
			Assert.That(bot.Coords == new Coordinates2D(1,1), "Coordinates are not equal");
			Assert.That(bot.Age == 0, "Age are not equal to 0");
			Assert.That(bot.Energy >= 0 && bot.Energy <=100, $"Energy not in [0..100]. Actual is {bot.Energy}");
			Assert.That(bot.Nutrition.Count() == 1 && bot.Nutrition.Contains(NutritionMethods.Photosynthesis),
				$"Default bot nutrition not only 1 photosynthesis. Actual is {string.Join(", ",bot.Nutrition)}");
		}

		[Test]
		public void CreateBotWrong_ExceptionThrowed()
		{
			Assert.Throws<ArgumentException>(() => new Bot(default, new Coordinates2D(-1, -1)));
		}
	}
}