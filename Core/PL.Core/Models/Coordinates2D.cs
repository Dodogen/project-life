namespace PL.Core.Models
{
	public struct Coordinates2D
	{
		public int X;
		public int Y;

		public Coordinates2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Coordinates2D operator +(Coordinates2D p1, Coordinates2D p2)
		{
			return new Coordinates2D(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Coordinates2D operator -(Coordinates2D p1, Coordinates2D p2)
		{
			return new Coordinates2D(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static bool operator ==(Coordinates2D p1, Coordinates2D p2)
		{
			return p1.X == p2.X && p1.Y == p2.Y;
		}

		public static bool operator !=(Coordinates2D p1, Coordinates2D p2)
		{
			return !(p1 == p2);
		}
	}
}
