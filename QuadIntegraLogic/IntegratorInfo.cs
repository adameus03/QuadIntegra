using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraLogic
{
    public abstract class IntegratorInfo
    {
        protected QuadIntegraAbstractLogicAPI logicAPI;
        public IntegratorInfo(QuadIntegraAbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
        }
        public QuadIntegraAbstractLogicAPI LogicAPI => this.logicAPI;
    }
}
