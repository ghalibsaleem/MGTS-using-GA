using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.errorcalculator
{
    public class NMSE
    {
        public static double calculate(ref double[] main, ref double[] expected)
        {
            double nmse = 0;
            if (main != null && expected != null)
            {
                double mean = centraltendencies.Mean.calculate(expected);
                double numerator = 0, denomenator = 0;
                for (int i = 0; i < expected.Length; i++)
                {
                    numerator += Math.Pow(main[i] - expected[i], 2);
                    denomenator += Math.Pow(main[i] - mean, 2);
                }
                nmse = numerator / denomenator;
            }  
            return nmse;
        }


    }
}
