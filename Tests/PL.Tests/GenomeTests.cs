using PL.Core.Models;

namespace PL.Core.Tests
{
	public class GenomeTests
	{
		[Test]
		public void GenomeConstructor_CheckIfMixedGenomeContainsCorrectValues_Created()
		{
			Genome g1 = new Genome(10);
			Genome g2 = new Genome(10);
			Genome mixedGenome = new Genome(g1, g2, 0);

			//check if mixed contain elements from g1 and g2
			var exceptedFrom_g1 = mixedGenome.Genes.Except(g1.Genes);
			var exceptedFrom_g1g2 = exceptedFrom_g1.Except(g2.Genes);

			Assert.That(exceptedFrom_g1g2.Count() == 0,
				$"excepted array contain element not included in g1 and g2 genomes\n" +
				$"g1 = {string.Join(", ", g1.Genes)}\n" +
				$"g2 = {string.Join(", ", g2.Genes)}\n" +
				$"mixed = {string.Join(", ", mixedGenome.Genes)}\n" +
				$"add excepted = {string.Join(", ", exceptedFrom_g1g2)}\n");
		}

		[Test]
		public void MutateGene_CheckIfRandomGenomeElementChanged_Changed()
		{

			Genome g1 = new Genome(10);
			var g1Genes = new int[g1.Genes.Count()];
			Array.Copy(g1.Genes.ToArray(), g1Genes, g1Genes.Length);

			g1.MutateGene();

			Assert.That(!g1Genes.SequenceEqual(g1.Genes),
				"mutated and original genes are equal\n" +
				$"original = {string.Join(", ", g1Genes)}\n" +
				$"mutated  = {string.Join(", ", g1.Genes)}\n");
		}
	}
}