using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.errorcalculator
{
    public class Error
    {
        public static double CalculateError(double initial,double final)
        {
            return (final - initial) / final;
        }

        public static void UpdateValueByError(ref double[] genes, double error)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = genes[i] - error * genes[i];
            }
        }
    }
}
