﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
using PL.Core.Constants;
using PL.Core.Extensions;

namespace PL.Core.Models
{
	public class Field
	{
		private Bitmap _bmpImage;
		private int _height;
		private int _width;
		private List<Bot> _bots;
		private int currentFrame = 0;

		//!TODO add season, daytime, color filter

		public Bot Bots { get; set; }

		public BitmapImage Map
		{
			get => _bmpImage.ConvertToBitmapImage();
		}

		public Field(BitmapImage bmpImg)
		{
			_bmpImage = bmpImg.ConvertToBmp();
			_height = _bmpImage.Height;
			_width = _bmpImage.Width;
			CreateBots();
		}

		public void Update()
		{
			UpdateBots();
			if (currentFrame == WorldConstants.DRAWING_FRAME)
			{
				currentFrame = 0;
				Redraw();
			}
		}

		private void Redraw()
		{
			var newBmp = new Bitmap(_width, _height);
			RedrawBots(newBmp);
			_bmpImage = newBmp;
		}

		//creation chance 1 to 8
		private void CreateBots()
		{
			Random r = new Random();
			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					if (r.Next(0, 8) == 0)
					{
						var bot = new Bot(this,new Coordinates2D(j, i));
						_bots.Add(bot);
						_bmpImage.SetPixel(j,i,bot.Color);
					}
				}
			}
		}

		private void UpdateBots()
		{
			foreach (var bot in _bots)
			{
				bot.Next();
			}
		}

		private void RedrawBots(Bitmap bmp)
		{
			foreach (var bot in _bots)
			{
				var x = bot.Coords.X;
				var y = bot.Coords.Y;
				bmp.SetPixel((int)x,(int)y, bot.Color);
			}
		}

		public Bot this[int x, int y]
		{
			get => _bots.
			Find(b => (int)b.Coords.X == x && (int)b.Coords.Y == y);

			set => _bots.Add(value);
		}

		public void KillBot(Bot bot)
		{
			_bots.Remove(bot);
		}
		
		public void AddBot(Bot bot)
		{
			_bots.Add(bot);
		}
	}
}