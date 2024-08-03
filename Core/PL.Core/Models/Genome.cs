using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using PL.Core.Constants;
using static PL.Core.Extensions.EnumerableExt;

namespace PL.Core.Models
{
	public class Genome
	{
		private int[] _genes;

		public IEnumerable<int> Genes => _genes;

		public Genome(int length)
		{
			_genes = CreateRandomIntegerArray(length);
		}

		public Genome(Genome g1, Genome g2, double mutationChance)
		{
			_genes = CreateMixedGenome(g1,g2).ToArray();

			if (new Random().NextDouble() <= mutationChance)
			{
				MutateGene();
			}
		}

		private int[] CreateRandomIntegerArray(int len)
		{
			var array = new int[len];

			for (int i = 0; i < len; i++)
			{
				Random r = new Random();
				array[i] = r.Next(0, BotConstants.GENOME_LENGTH);
			}

			return array;
		}

		private IEnumerable<int> CreateMixedGenome(Genome g1, Genome g2)
		{
			var len = g1._genes.Length;

			var gens1 = new List<int>(g1._genes);
			var gens2 = new List<int>(g2._genes);
			
			return gens1.Concat(gens2).PickRandom(len);
		}

		public void MutateGene()
		{
			int mutatedIndex = new Random().Next(0, this._genes.Length);

			while (true)
			{
				int newGene = new Random().Next(0, BotConstants.GENOME_LENGTH);
				if (newGene != _genes[mutatedIndex])
				{
					_genes.SetValue(newGene, mutatedIndex);
					return;
				}
			}

		}

		public int this[int i]
		{
			get => _genes[i % _genes.Length];
			set => _genes[i % _genes.Length] = value;
		} 
	}
}