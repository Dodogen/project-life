using System;
using System.Collections.Generic;
using System.Linq;
using PL.Core.Constants;
using static PL.Core.Extensions.EnumerableExt;

namespace PL.Core.Models
{
	public class Genome
	{
		private List<int> _genes;

		public Genome(int length)
		{
			_genes = CreateRandomIntegerArray(length);
		}
		public Genome(int length, Genome g1, Genome g2, double mutationChance)
		{

			_genes = CreateMixedGenome(g1,g2).ToList();

			if (new Random().NextDouble() <= mutationChance)
			{
				MutateGene();
			}
		}

		private List<int> CreateRandomIntegerArray(int len)
		{
			var array = new List<int>(len);

			for (int i = 0; i < len; i++)
			{
				Random r = new Random();
				array.Add(r.Next(0, BotPropertiesValues.GENOME_LENGTH));
			}

			return array;
		}

		private IEnumerable<int> CreateMixedGenome(Genome g1, Genome g2)
		{
			var len = g1._genes.Count;

			var gens1 = new List<int>(g1._genes);
			var gens2 = new List<int>(g2._genes);
			
			return gens1.Concat(gens2).PickRandom(len);
		}

		public void MutateGene()
		{
			_genes[new Random().Next(0, BotPropertiesValues.GENOME_LENGTH)] = new Random().Next(0, BotPropertiesValues.GENOME_LENGTH);
		}

		public int this[int i]
		{
			get => _genes[i % _genes.Count];
			set => _genes[i % _genes.Count] = value;
		} 
	}
}