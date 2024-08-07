using System;
using System.Collections.Generic;
using System.Linq;
using PL.Core.Constants;
using PL.Core.Enumerations;
using PL.Core.Extensions;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;


namespace PL.Core.Models
{
	public class Bot
	{
		private Field _field;
		private Point _coordinates;
		private uint _energy; // gen randomly from 0 to 100
		private uint _age = 0; // 0 from start
		private Color _color; // or green on mixed from parents
		private Genome _genome;
		private Directions _direction;
		private List<NutritionMethods> _nutritionMethods;
		private int _currentGenomePointer = 0;

		#region properties

		public Point Coords => _coordinates;

		public uint Energy
		{
			get => _energy;
			set => _energy = value.Clamp((uint)0,(uint)100);
		}

		public uint Age => _age;
		public Color Color => _color;
		public Point MovementDirection => _direction.Value();
		public IEnumerable<NutritionMethods> Nutrition => _nutritionMethods;

		#endregion

		public Bot(Field field, Point coords) // create default "plant"-bot
		{
			_field = field;
			_coordinates = coords;
			_energy = (uint)(new Random().Next(0, 100));
			_nutritionMethods = GetNutritionMethods(new[] { NutritionMethods.Photosynthesis }).ToList();
			_color = SetColor();
			_genome = new Genome(BotPropertiesValues.GENOME_LENGTH);
			_direction = ChooseRandomDirection();
			_field = field;
		}

		public Bot(Field field, Bot father, Bot mother, double mutationChance)
		{
			_field = field;
			_field.KillBot(father);
			_coordinates = father._coordinates;
			_energy = (father._energy + mother._energy) / 2;
			_nutritionMethods = GetNutritionMethods((father._nutritionMethods).Concat(mother._nutritionMethods))
				.ToList();
			_color = SetColor();
			_genome = new Genome(BotPropertiesValues.GENOME_LENGTH, father._genome, mother._genome, mutationChance);
			_direction = ChooseRandomDirection();
		}

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

			//int r = (int)redSum.Clamp(0, 255);
			//int g = (int)greenSum.Clamp(0, 255);
			//int b = (int)blueSum.Clamp(0, 255);

			//return Color.FromArgb(r,g, b);

			return Color.FromArgb((int)redSum, (int)greenSum, (int)blueSum);
		}

		private IEnumerable<NutritionMethods> GetNutritionMethods(IEnumerable<NutritionMethods> source)
		{
			var len = new Random().Next(1, Enum.GetNames(typeof(NutritionMethods)).Length + 1);
			return source.PickRandom(len);
		}

		#region Bot commands

		private Directions ChooseRandomDirection()
		{
			throw new NotImplementedException();
		}
		
		private void Move()
		{
			_coordinates.Add(_direction.Value());
			_energy -= BotPropertiesValues.MOVEMENT_ENERGY_LOSES;
		}

		private void Mutate()
		{
			var randomIndex = (new Random()).Next(0, BotPropertiesValues.GENOME_LENGTH);
			var randomGeneValue = (new Random()).Next(0, BotPropertiesValues.GENOME_LENGTH);
			_genome[randomIndex] = randomGeneValue;
			_energy -= BotPropertiesValues.MUTATION_ENERGY_LOSES;
		}

		private void Eat()
		{
			var bots = CheckBotsAround();

			if (bots.Count != 0)
			{
				var randomBot = bots.PickRandom();
				Energy += randomBot.Energy / 2;
				_field.KillBot(randomBot);
			}

			Energy -= BotPropertiesValues.EATING_ENERGY_LOSES;
		}

		private void Photosynthesize()
		{
			Energy += BotPropertiesValues.PHOTOSYNTHESIZE_ENERGY_ADD;
		}

		private void Ignore()
		{
			Energy -= BotPropertiesValues.IGNORING_ENERGY_LOSES;
			throw new NotImplementedException();
		}

		private List<Bot> CheckBotsAround()
		{
			var bots = new List<Bot>();

			for (int y = -1; y < 2; y++)
			{
				for (int x = -1; x < 2; x++)
				{
					if (x == 0 && y == 0) continue;
					var checkedBot = _field[(int)_coordinates.X + x, (int)_coordinates.Y + y];
					if (!checkedBot.Equals(default(Bot)))
					{
						bots.Add(checkedBot);
					}
				}
			}

			return bots;
		}

		private List<Point> CheckFreeSpaceAround()
		{
			var points = new List<Point>();

			for (int y = -1; y < 2; y++)
			{
				for (int x = -1; x < 2; x++)
				{
					if (x == 0 && y == 0) continue;
					var checkedPoint = _field[(int)_coordinates.X + x, (int)_coordinates.Y + y];
					if (checkedPoint.Equals(default(Bot)))
					{
						points.Add(new Point((int)_coordinates.X + x, (int)_coordinates.Y + y));
					}
				}
			}

			return points;
		}


		private void Rotate()
		{
			var res = new Random().Next(0, 2);
			if(res == 0)
			{
				_direction.RotateLeft();
			}
			else
			{
				_direction.RotateRight();
			}

			Energy -= BotPropertiesValues.ROTATION_ENERGY_LOSES;
		}

		private void CreateChild(double mutationChance)
		{
			var parentCandidates = CheckBotsAround();

			if (parentCandidates.Count != 0 && Energy >= BotPropertiesValues.BIRTH_ENERGY_LOSES)
			{
				var otherParent = parentCandidates.PickRandom();

				var childBot = new Bot(_field, otherParent, this, mutationChance);
				_field.AddBot(childBot);

				Energy -= BotPropertiesValues.BIRTH_ENERGY_LOSES;
			}
		}

		private void ModifyCurrentGenomeNumber(int step)
		{
			_currentGenomePointer += step;
		}

		#endregion

		public void Next()
		{
			bool canExit = false;

			for (int i = 0; i < BotPropertiesValues.REPEATS_MAX_COUNT; i++)
			{
				switch (_genome[_currentGenomePointer])
				{
					case 0:
					case 2:
					case 6:
					{
						Move();
						break;
					}

					case 12:
					{
						if (Nutrition.Contains(NutritionMethods.Photosynthesis))
						{
							Photosynthesize();
						}
						else
						{
							Eat();
						}

						canExit = true;
						break;
					}

					case 13:
					case 15:
					case 18:
					{
						Rotate();
						break;
					}

					case 24:
					{
						CreateChild(BotPropertiesValues.MUTATION_CHANCE);
						canExit = true;
						break;
					}

					case 30:
					{
						Mutate();
						canExit = true;
						break;
					}

					default:
					{
						ModifyCurrentGenomeNumber(_currentGenomePointer + i);
						break;
					}
				}

				if (canExit == true)
				{
					ModifyCurrentGenomeNumber(1);
					break;
				}
			}
		}
	}
}
