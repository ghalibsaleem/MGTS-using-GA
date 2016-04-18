using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.helper.maths
{
    public class RungeKutta
    {
        /// <summary>
        /// Method to calculate the range Kutta 4 for mackey time series
        /// </summary>
        /// <param name="xt"> x at instant t , i.e. x(t) (current value of x)</param>
        /// <param name="xt_tau">x at instant (t-tau) , i.e. x(t-tau)</param>
        /// <param name="h"> it as the delta time</param>
        /// <param name="a">intial time period</param>
        /// <param name="b">final 
        /// </param>
        /// <param name="t">current time</param>
        /// <returns></returns>
        public static double Calculate(double xt, double xt_tau, double h, double a, double b,double t)
        {
            double k1 = h * MackeyEquation(xt, xt_tau, a, b);
            double k2 = h * MackeyEquation(X(t + 0.5 * k1), xt_tau, a, b);
            double k3 = h * MackeyEquation(X(t + 0.5 * k2), xt_tau, a, b);
            double k4 = h * MackeyEquation(X(t + 0.5 * k3), xt_tau, a, b);
            return xt + k1 + k2 + k3 + k4;
        }

        private static double MackeyEquation(double xt, double xt_tau,double a, double b)
        {
            return (a * xt_tau)/(1 + Math.Pow(xt_tau,10)) - b * xt;
        }
        private static double X(double t)
        {
            return 0;
        }
    }
}
