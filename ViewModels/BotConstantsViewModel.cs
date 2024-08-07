using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Core.Constants;
using static PL.Core.Constants.BotPropertiesValues;

namespace project_life.ViewModels
{
	public class BotConstantsViewModel : BaseViewModel
	{
		private double _mutationChance = BotPropertiesValues.MUTATION_CHANCE;

		public double MutationChance
		{
			get => _mutationChance;
			set
			{
				_mutationChance = value;
				BotPropertiesValues.MUTATION_CHANCE = value;
				OnPropertyChanged("MutationChance");
			}
		}
	}
}
