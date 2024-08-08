using System.Windows;
using PL.Core.Constants;

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
