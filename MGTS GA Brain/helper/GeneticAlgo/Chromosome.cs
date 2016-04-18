using MGTS_GA_Brain.Handlers;
using MGTS_GA_Brain.helper.errorcalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.GeneticAlgo
{
    public class Chromosome
    {
        private double[] genes;
        private int fitness;
        public Chromosome(double[] genes)
        {
            this.genes = genes;
        }

        public double[] GetGenes()
        {
            return genes;
        }

        public void SetGenes(double[] genes)
        {
            this.genes = genes;
        }

        public int GetFitness()
        {
            //if (isFitnessChanged)
            //    RecalculateFitness();
            return fitness;
        }

        public int RecalculateFitness()
        {
            //Todo
            double[] outputArray = new double[Helper.inputArray.Length / 2];
            for (int i = 0; i < Helper.inputArray.Length / 2; i++)
            {
                if (i <= genes[3] + 1)
                    outputArray[i] = Helper.inputArray[i];
                else
                    outputArray[i] = MackeyGlassEquation.GetValue(ref genes, ref Helper.inputArray, i - 1);
            }
            double error = NMSE.calculate(ref Helper.inputArray, ref outputArray) * 100;
            fitness = (int)(100 - error);
            
            return fitness;
        }

        public double[] GetOutputArray()
        {
            double[] outputArray = new double[Helper.inputArray.Length];
            for (int i = 0; i < Helper.inputArray.Length; i++)
            {
                if (i <= genes[3] + 1)
                    outputArray[i] = Helper.inputArray[i];
                else
                    outputArray[i] = MackeyGlassEquation.GetValue(ref genes, ref Helper.inputArray, i - 1);
            }
            return outputArray;
        }

        public override string ToString()
        {
            return genes.ToString();
        }
    }
}
