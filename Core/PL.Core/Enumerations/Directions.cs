using Point = System.Windows.Point;


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
		NoDirection,
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
				}

				case Directions.Right:
				{
					return new Point(1, 0);
				}

				case Directions.TopRight:
				{
					return new Point(1, 1);
				}

				case Directions.Top:
				{
					return new Point(0, 1);
				}

				case Directions.TopLeft:
				{
					return new Point(-1, 1);
				}

				case Directions.Left:
				{
					return new Point(-1, 0);
				}

				case Directions.BottomLeft:
				{
					return new Point(-1, -1);
				}

				case Directions.Bottom:
				{
					return new Point(0, -1);
				}

				default:
				{
					return new Point(0, 0);
				}
			}
		}

		public static Directions RotateLeft(this Directions dir)
		{
			if (dir == Directions.NoDirection) return dir;

			if ((int)dir == 7) return (Directions)0;

			return (Directions)(int)++dir;
		}

		public static Directions RotateRight(this Directions dir)
		{
			if (dir == Directions.NoDirection) return dir;

			if ((int)dir == 0) return (Directions)7;

			return (Directions)(int)--dir;
		}

		//public static Directions RotateDirection(Directions direction, RotationDirection rotationDirection)
		//{
		//	if (direction == Directions.NoDirection)
		//	{
		//		throw new NotImplementedException();
		//	}
		//	return (Directions)(((int)direction + (int)rotationDirection + 8) % 8);

	}
}