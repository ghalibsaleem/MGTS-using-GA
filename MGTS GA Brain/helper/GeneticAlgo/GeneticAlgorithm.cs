using MGTS_GA_Brain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.GeneticAlgo
{
    public static class GeneticAlgorithm
    {
        private static Population populationProp;

        public static Population population
        {
            get { return populationProp; }
            set { populationProp = value; }
        }

        public static void CrossOver(Population nextGeneration)
        {
            var temp = Split(nextGeneration.chromosomes, nextGeneration.chromosomes.Length / 2).ToArray();
            var firstHalf = temp[0];
            var secondHalf = temp[1];
            secondHalf = secondHalf.Reverse();
            Random rnd = new Random();
            int length = secondHalf.Count();
            for (int j = 0; j < length; j++)
            {

                
                double[] newGenes = new double[6];
                for (int i = 0; i < 6; i++)
                {
                    int rndNo = rnd.Next(0, 2);
                    if (rndNo == 1)
                        newGenes[i] = firstHalf.ElementAt(j).GetGenes()[i];
                    else
                        newGenes[i] = secondHalf.ElementAt(j).GetGenes()[i];
                }
                secondHalf.ElementAt(j).SetGenes(newGenes);
                secondHalf.ElementAt(j).RecalculateFitness();
            }
            firstHalf = firstHalf.Concat(secondHalf);
            population.chromosomes = firstHalf.ToArray();
        }

        public static void Mutate(Population nextGeneration)
        {
            var temp = Split(nextGeneration.chromosomes, nextGeneration.chromosomes.Length / 2).ToArray();
            var firstHalf = temp[0];
            var secondHalf = temp[1];
            secondHalf = secondHalf.Reverse();
            Random rnd = new Random();
            int length = secondHalf.Count();
            for (int j = 0; j < length; j++)
            {

               
                double[] newGenes = new double[6];
                for (int i = 0; i < 6; i++)
                {
                    
                    newGenes[i] = (firstHalf.ElementAt(j).GetGenes()[i] + secondHalf.ElementAt(j).GetGenes()[i]) / 2;
                    
                }
                secondHalf.ElementAt(j).SetGenes(newGenes);
                secondHalf.ElementAt(j).RecalculateFitness();
            }
            firstHalf = firstHalf.Concat(secondHalf);
            population.chromosomes = firstHalf.ToArray();
        }

        public static void Evolve()
        {
            Population nextGeneration = population;
            Mutate(nextGeneration);
            population.SortChromosomesByFistness();
            CrossOver(nextGeneration);
            population.SortChromosomesByFistness();
        }

        public static Chromosome GetEliteChromosome()
        {
            return population.chromosomes[0];
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    }
}
