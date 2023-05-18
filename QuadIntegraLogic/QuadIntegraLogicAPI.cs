using QuadIntegraData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraLogic
{
    internal class QuadIntegraLogicAPI : QuadIntegraAbstractLogicAPI
    {
        public QuadIntegraLogicAPI(QuadIntegraData.QuadIntegraAbstractDataAPI dataAPI) : base(dataAPI) { }

        public override double Integrate<TIntegrator>(int functionIndex, double integrationLeftBound, double integrationRightBound, double desiredAccuracy, IntegratorInfo? integratorInfo = null)
        {
            Integrator integrator;
            if (typeof(SimpsonIntegrator) == typeof(TIntegrator))
            {
                integrator = new SimpsonIntegrator(base.dataAPI.GetFunction(functionIndex), integrationLeftBound, integrationRightBound, desiredAccuracy);
            }
            else if (typeof(GaussLegendreIntegrator) == typeof(TIntegrator))
            {
                if (integratorInfo == null) throw new NullReferenceException();
                else integrator = new GaussLegendreIntegrator(base.dataAPI.GetFunction(functionIndex), integrationLeftBound, integrationRightBound, desiredAccuracy, (GaussLegendreIntegratorInfo)integratorInfo);
            }
            else throw new TypeAccessException();

            return integrator.Integrate();
        }
    }
}
