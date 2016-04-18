using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.centraltendencies
{
    public class Mean
    {
        public static double calculate(double[] input)
        {
            double mean = 0;
            for(int i = 0; i < input.Length; i++)
            {
                mean += input[i];
            }
            if(input.Length != 0)
                mean /= input.Length;
            return mean;
        }
    }
}
