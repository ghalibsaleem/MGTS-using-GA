using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper
{
    public class MackeyGlassEquation
    {
        public static double GetValue(ref double[] genes,ref double[] inputArray,int t)
        {
            double x1 = 0,temp1,temp2,temp3;
            if (t >= genes[3])
            {
                x1 = genes[2] * inputArray[t];
                temp1 = (genes[0] * inputArray[t - (int)genes[3]]);
                temp2 =   Math.Pow(inputArray[t - (int)genes[3]], genes[4]);
                temp3 = genes[1] + temp2;
                x1 += temp1 / temp3;
            }
               
            else if (t == genes[3])
                x1 = genes[2] * inputArray[t] + (genes[0] * genes[5]) / (genes[1] + Math.Pow(genes[5], genes[4]));
            else
                throw new InvalidInputException("the value of t is Invalid");
            return x1;
        }
    }
}
