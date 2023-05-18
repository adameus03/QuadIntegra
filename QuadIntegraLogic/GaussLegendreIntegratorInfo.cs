using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraLogic
{
    public class GaussLegendreIntegratorInfo : IntegratorInfo
    {
        private int quadratureNodesNumber;
        public GaussLegendreIntegratorInfo(QuadIntegraAbstractLogicAPI logicAPI, int quadratureNodesNumber) : base(logicAPI) {
            this.quadratureNodesNumber = quadratureNodesNumber;
        }

        public int QuadratureNodesNumber => this.quadratureNodesNumber;
    }
}
