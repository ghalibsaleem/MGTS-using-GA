using MGTS_GA_Brain.Handlers;
using MGTS_GA_Brain.helper.GeneticAlgo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper
{
    public class Helper
    {
        static public double[] inputArray;
        static public double[] initialArray = null;

        private static double[] genes = new double[] { 0.01, 1, 0.9, 20, 10, 0.005 };

        public static void CalulateInitialArray()
        {
            if(inputArray != null && initialArray == null)
            {
                initialArray = new double[Helper.inputArray.Length];
                for (int i = 0; i < Helper.inputArray.Length; i++)
                {
                    if (i <= genes[3] + 1)
                        initialArray[i] = Helper.inputArray[i];
                    else
                        initialArray[i] = MackeyGlassEquation.GetValue(ref genes, ref Helper.inputArray, i - 1);
                }
                
            }
        }

        public static void FinalizeIt(Chromosome elite)
        {
            CalulateInitialArray();
            FileHandler.WriteToFile(inputArray, initialArray, elite.GetOutputArray());
            FileHandler.WriteToFile(elite.GetGenes(), "Elite");
        }
    }
}
