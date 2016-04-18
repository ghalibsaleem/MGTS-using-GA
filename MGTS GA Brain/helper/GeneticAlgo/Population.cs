using MGTS_GA_Brain.Handlers;
using MGTS_GA_Brain.helper.errorcalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MGTS_GA_Brain.helper.GeneticAlgo
{
    public class Population
    {
        public Chromosome[] chromosomes;

        private const int initialPopulation = 10000;

        private Chromosome inititialChromosome = new Chromosome(new double[] { 0.01, 1, 0.9, 20, 10, 0.005 });

        public Population()
        {
            this.chromosomes = null;
            
        }

        public  Population InitializePopulation(string filePath)
        {
            //Todo
            List<double> inputList = FileHandler.getResult(filePath);
            Helper.inputArray = inputList.ToArray<double>();
            //FileHandler.WriteToFile(Helper.inputArray);
            inputList.Clear();
            this.chromosomes = new Chromosome[Helper.inputArray.Length / 2];
            double[] prevGenes = inititialChromosome.GetGenes();
            for (int i = 0; i < Helper.inputArray.Length / 2 ; i++)
            {
                try
                {
                    double x1 = MackeyGlassEquation.GetValue(ref prevGenes, ref Helper.inputArray, i + 100);
                    double error = Error.CalculateError(Helper.inputArray[i], x1);
                    Error.UpdateValueByError(ref prevGenes, error);
                    double[] newGenes = new double[6];
                    prevGenes.CopyTo(newGenes, 0);
                    chromosomes[i] = new Chromosome(newGenes);
                }
                catch(Exception)
                {
                }
                
            }
            CalculateFitnesses();
            SortChromosomesByFistness();
            return this;
        }

        public void CalculateFitnesses()
        {
            foreach (var item in chromosomes)
            {
                item.RecalculateFitness();
            }
            
        }
        
        public void SortChromosomesByFistness()
        {
            if (chromosomes == null)
                return;
            chromosomes = chromosomes.OrderByDescending(sim => sim.GetFitness()).ToArray<Chromosome>();
        }

    }
}
