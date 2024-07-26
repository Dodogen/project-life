using System;
using System.Collections.Generic;
using PL.Core.Constants;

namespace PL.Core.Models
{
	public class Genome
	{
		private List<int> _genes;

		public Genome(int length)
		{
			_genes = CreateRandomIntegerArray(length);
		}

		private List<int> CreateRandomIntegerArray(int len)
		{
			var array = new List<int>(len);
			for (int i = 0; i < len; i++)
			{
				Random r = new Random();
				array[i] = r.Next(0, BotConstants.GENOME_LENGTH);
			}

			return array;
		}

		public void Mutate()
		{
			_genes[new Random().Next(0, BotConstants.GENOME_LENGTH)] = new Random().Next(0, BotConstants.GENOME_LENGTH);
		}

		public int this[int i] => _genes[i];

	}
}