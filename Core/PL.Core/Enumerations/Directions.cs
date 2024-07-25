using System.Windows;

namespace PL.Core.Enumerations
{
	public enum Directions
	{
		BottomRight,
		Right,
		TopRight,
		Top,
		TopLeft,
		Left,
		BottomLeft,
		Bottom,
	}

	public static class DirectionsExtension
	{
		public static Point Value(this Directions dir)
		{
			switch (dir)
			{
				case Directions.BottomRight:
				{
					return new Point(1, -1);
				};

				case Directions.Right:
				{
					return new Point(1, 0);
				};

				case Directions.TopRight:
				{
					return new Point(1, 1);
				};

				case Directions.Top:
				{
					return new Point(0, 1);
				};

				case Directions.TopLeft:
				{
					return new Point(-1, 1);
				};

				case Directions.Left:
				{
					return new Point(-1, 0);
				};

				case Directions.BottomLeft:
				{
					return new Point(-1, -1);
				};

				case Directions.Bottom:
				{
					return new Point(0, -1);
				};

				default:
				{
					return new Point(0, 0);
				}
			}
		}
	}
}