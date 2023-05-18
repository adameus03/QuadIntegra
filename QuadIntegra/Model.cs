using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegra
{
    internal class Model
    {
        private double leftBound = -1;
        private double rightBound = 1;
        private double accuracy = 0.01;
        private int quadNodesNumber = 3;
        private int functionIndex = 0;
        private double integralValue;

        QuadIntegraLogic.QuadIntegraAbstractLogicAPI logicAPI;
        public Model(QuadIntegraLogic.QuadIntegraAbstractLogicAPI? logicAPI = null)
        {
            this.logicAPI = logicAPI ?? QuadIntegraLogic.QuadIntegraAbstractLogicAPI.CreateInstance();
        }

        public void CalculateIntegralSimpson()
        {
            this.integralValue = this.logicAPI.Integrate<QuadIntegraLogic.SimpsonIntegrator>(functionIndex, leftBound, rightBound, accuracy);
        }

        public void CalculateIntegralGaussLegendre()
        {
            QuadIntegraLogic.IntegratorInfo integratorInfo = new QuadIntegraLogic.GaussLegendreIntegratorInfo(this.logicAPI, quadNodesNumber);
            this.integralValue = this.logicAPI.Integrate<QuadIntegraLogic.GaussLegendreIntegrator>(functionIndex, leftBound, rightBound, accuracy, integratorInfo);
        }

        public Func<double, double> FetchFunction()
        {
            return this.logicAPI.Function(this.functionIndex);
        }

        /*public (double, double)[] FetchNodesGaussLegendre()
        {
            return this.logicAPI.GetNodes(this.quadNodesNumber, this.leftBound, this.rightBound);
        }*/


        public double LeftBound { get => leftBound; set => leftBound = value; }
        public double RightBound { get => rightBound; set => rightBound = value; }
        public double Accuracy { get => accuracy; set => accuracy = value; }
        public int QuadNodesNumber { get => quadNodesNumber; set=>quadNodesNumber = value; }
        public int FunctionIndex { get => functionIndex; set => functionIndex = value; }

        public double IntegralValue { get => integralValue; }
    }
}
