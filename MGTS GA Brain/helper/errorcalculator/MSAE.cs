using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.errorcalculator
{
    public class MSAE
    {
        public static double calculate(double[] main, double[] expected)
        {
            double nmse = 0;
            if (main != null && expected != null)
                if (main.Length == expected.Length)
                {
                    for (int i = 0; i < main.Length; i++)
                    {
                        nmse += Math.Abs(main[i] - expected[i]);
                    }
                    nmse /= main.Length;
                }
            return nmse;
        }
    }
}
