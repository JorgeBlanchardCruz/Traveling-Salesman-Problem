using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Traveling_Salesman_Problem {
    class CTSP_Distances {

        private decimal[,] _Matrix;

        public decimal[,] Matrix {
            get { return _Matrix; }
            set { _Matrix = value; }
        }

        public CTSP_Distances () {

        }

    }
}
