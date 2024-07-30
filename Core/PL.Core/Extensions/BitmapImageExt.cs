using System.Drawing;
using System.Windows.Media.Imaging;

namespace PL.Core.Extensions
{
	public static class BitmapImageExt
	{
		public static Bitmap ConvertToBmp(this BitmapImage im)
		{
			return new Bitmap(im.StreamSource);
		}

	}
}
