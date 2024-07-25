using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Windows;
using System.Windows.Media;
using PL.Core.Enumerations;

namespace PL.Core.Models
{
	public class Bot
	{
		private Point _coordinates;
		private uint _energy;
		private uint _age;
		private BotTypes _type;
		private Color _color;
		private Genome _genome;
		private Directions _direction;
		private List<NutritionMethods> _nutritionMethods;

		Bot()
		{

		}

		Bot(Bot b1, Bot b2)
		{

		}
	}
}
