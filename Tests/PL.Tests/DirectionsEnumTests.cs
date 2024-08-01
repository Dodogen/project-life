using System.Drawing;
using PL.Core.Enumerations;

namespace PL.Core.Tests
{
	[TestFixture]
	public class DirectionEnumTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Value_GetFromDirection_Returned()
		{
			Assert.That(true,"bottom right correct",Directions.BottomRight, new Point(1,-1));
			Assert.That(true,"top right correct",Directions.TopRight, new Point(1,0));
			Assert.That(true,"top correct",Directions.Top, new Point(0,1));
			Assert.That(true,"top left correct",Directions.TopLeft, new Point(-1,1));
			Assert.That(true,"left correct",Directions.Left, new Point(-1,0));
			Assert.That(true,"bottom left correct",Directions.BottomLeft, new Point(-1,-1));
			Assert.That(true,"bottom correct",Directions.Bottom, new Point(0,-1));
			Assert.That(true,"no dir correct",Directions.NoDirection, new Point(0,0));
		}


		[TestCase(Directions.NoDirection, Directions.NoDirection)]
		[TestCase(Directions.BottomRight, Directions.Right)]
		[TestCase(Directions.Right, Directions.TopRight)]
		[TestCase(Directions.TopRight, Directions.Top)]
		[TestCase(Directions.Top, Directions.TopLeft)]
		[TestCase(Directions.TopLeft, Directions.Left)]
		[TestCase(Directions.Left, Directions.BottomLeft)]
		[TestCase(Directions.BottomLeft, Directions.BottomLeft)]
		[TestCase(Directions.BottomLeft, Directions.Bottom)]
		public void RotateLeft_Rotate_SuccessfullyRotated(Directions start, Directions rotated)
		{
			Assert.That(true,
				Enum.GetName(start) + " rotated to " + Enum.GetName(rotated),
				start.RotateLeft(),
				rotated);
		}


		[TestCase(Directions.NoDirection, Directions.NoDirection)]
		[TestCase(Directions.BottomRight, Directions.Bottom)]
		[TestCase(Directions.Right, Directions.BottomRight)]
		[TestCase(Directions.TopRight, Directions.Right)]
		[TestCase(Directions.Top, Directions.TopRight)]
		[TestCase(Directions.TopLeft, Directions.Top)]
		[TestCase(Directions.Left, Directions.BottomLeft)]
		[TestCase(Directions.BottomLeft, Directions.Left)]
		[TestCase(Directions.Bottom, Directions.BottomLeft)]
		public void RotateRight_Rotate_SuccessfullyRotated(Directions start, Directions rotated)
		{
			Assert.That(true,
				Enum.GetName(start) + " rotated to " + Enum.GetName(rotated),
				start.RotateRight(),
				rotated);
		}

	}
}