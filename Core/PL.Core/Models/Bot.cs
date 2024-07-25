using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using PL.Core.Constants;
using PL.Core.Enumerations;
using PL.Core.Extensions;

namespace PL.Core.Models
{
	public class Bot
	{
		private Point _coordinates;
		private uint _energy; // gen randomly from 0 to 100
		private uint _age; // 0 from start
		private BotTypes _type; // Plant is default
		private Color _color;
		private Genome _genome;
		private Directions _direction;
		private List<NutritionMethods> _nutritionMethods;

		Bot(Point coords)
		{
			_coordinates = coords;
			_energy = (uint)GetRandomNumber(0, 100);
			_age = 0;
			_type = BotTypes.Plant;
			_color = SetColor();
			_genome = new Genome(BotConstants.GENOME_LENGTH);
			_direction = Directions.NoDirection;
			_nutritionMethods = GetNutritionMethods(new [] {NutritionMethods.Photosynthesis}).ToList();
		}

		Bot(Bot b1, Bot b2)
		{

		}

		private int GetRandomNumber(int start, int inclusiveEnd) =>
			new Random().Next(start, inclusiveEnd + 1);

		private Color SetColor()
		{
			switch (_type)
			{
				case (BotTypes.Plant):
				{
					return Colors.ForestGreen;
				}

				case (BotTypes.Animal):
				{
					return Colors.DarkRed;
				}

				case (BotTypes.Stone):
				{
					return Colors.DimGray;
				}

				case (BotTypes.Corpse):
				{
					return Colors.Black;
				}

				default: return Colors.White;
			}
		}

		private IEnumerable<NutritionMethods> GetNutritionMethods(IEnumerable<NutritionMethods> source)
		{
			var len = new Random().Next(1, Enum.GetNames(typeof(NutritionMethods)).Length + 1);
			return source.PickRandom(len);
		}

		//methods
		//move
		//setcolor(c1,c2)
		//GetNutritionMethods(b1 b2)

	}
}
