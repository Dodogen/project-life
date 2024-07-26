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
		private Field _field;
		private Point _coordinates;
		private uint _energy; // gen randomly from 0 to 100
		private uint _age = 0; // 0 from start
		private BotTypes _type; // UNUSED
		private Color _color; // or green on mixed from parents
		private Genome _genome;
		private Directions _direction;
		private List<NutritionMethods> _nutritionMethods;
		private int _currentGenomePoint = 0;

		public Bot(Point coords) // create default "plant"-bot
		{
			_coordinates = coords;
			_energy = (uint)GetRandomNumber(0, 100);
			_nutritionMethods = GetNutritionMethods(new[] { NutritionMethods.Photosynthesis }).ToList();
			_color = SetColor();
			_genome = new Genome(BotConstants.GENOME_LENGTH);
			_direction = Directions.NoDirection;
		}

		public Bot(Bot father, Bot mother)
		{
			_coordinates = father._coordinates;
			_energy = (father._energy + mother._energy) / 2;
			_nutritionMethods = GetNutritionMethods((father._nutritionMethods).Concat(mother._nutritionMethods))
				.ToList();
			_color = SetColor();
			_genome = new Genome(BotConstants.GENOME_LENGTH);
			_direction = Directions.NoDirection;
		}


		private int GetRandomNumber(int start, int inclusiveEnd) =>
			new Random().Next(start, inclusiveEnd + 1);

		private Color SetColor()
		{
			//calculate relative step for every color
			var step = (double)255 / _nutritionMethods.Count;

			(double redSum, double greenSum, double blueSum) = (0, 0, 0);
			foreach (var method in _nutritionMethods)
			{
				switch (method)
				{
					case (NutritionMethods.Photosynthesis):
					{
						greenSum += step;
						blueSum += step;
						break;
					}

					case (NutritionMethods.Herbivorous):
					{
						greenSum += step;
						break;
					}

					case (NutritionMethods.Carnivorous):
					{
						redSum += step;
						break;
					}

					case (NutritionMethods.Scavenger):
					{
						blueSum += step;
						break;
					}

					case (NutritionMethods.Omnivorous):
					{
						redSum += step;
						greenSum += step;
						blueSum += step;
						break;
					}
				}
			}

			int r = (int)redSum.Clamp(0, 255);
			int g = (int)greenSum.Clamp(0, 255);
			int b = (int)blueSum.Clamp(0, 255);

			return Color.FromRgb((byte)r, (byte)g, (byte)b);
		}

		private IEnumerable<NutritionMethods> GetNutritionMethods(IEnumerable<NutritionMethods> source)
		{
			var len = new Random().Next(1, Enum.GetNames(typeof(NutritionMethods)).Length + 1);
			return source.PickRandom(len);
		}

		#region Bot commands

		private void Move()
		{
			throw new NotImplementedException();
		}

		private void Mutate()
		{
			throw new NotImplementedException();
		}

		private void Eat()
		{
			throw new NotImplementedException();
		}

		private void Photosynthesize()
		{
			throw new NotImplementedException();
		}

		private void Ignore()
		{
			throw new NotImplementedException();
		}

		private void CheckAround()
		{
			throw new NotImplementedException();
		}

		private void Rotate()
		{
			throw new NotImplementedException();
		}

		private void CreateChild()
		{
			throw new NotImplementedException();
		}

		private bool TrySuicide()
		{
			throw new NotImplementedException();
		}

		private void StealGene()
		{
			throw new NotImplementedException();
		}

		private void StealEnergy()
		{
			throw new NotImplementedException();
		}

		public void Next()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
