using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = System.Windows.Point;


namespace PL.Core.Extensions
{
	public static class PointExt
	{
		public static Point Add(this Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}
	}
}
