using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraLogic
{
    public class GaussLegendreIntegrator : Integrator
    {
        GaussLegendreIntegratorInfo integratorInfo;
        private GaussLegendreIntegrator(GaussLegendreIntegratorInfo integratorInfo) : base((x) => 0, 0, 0, 0) {
            this.integratorInfo = integratorInfo;
        }
        public GaussLegendreIntegrator(Func<double, double> f, double a, double b, double epsilon, GaussLegendreIntegratorInfo integratorInfo) : base(f, a, b, epsilon)
        {
            this.integratorInfo = integratorInfo;
        }
        protected override double Kernel(double a, double b)
        {
            double sum = 0;
            (double, double)[] data = integratorInfo.LogicAPI.DataAPI.GetGLQuadratureData(integratorInfo.QuadratureNodesNumber, a, b); 
            for(int i=0; i<integratorInfo.QuadratureNodesNumber; i++)
            {
                sum += data[i].Item1 * base.f(data[i].Item2);
            }
            return sum;
        }
    }
}
