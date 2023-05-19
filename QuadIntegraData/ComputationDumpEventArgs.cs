using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraData
{
    public class ComputationDumpEventArgs : EventArgs
    {
        private string line;
        public ComputationDumpEventArgs(string line)
        {
            this.line = line;
        }
        public string Line => this.line;
    }
}
