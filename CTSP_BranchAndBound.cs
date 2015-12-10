using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem {
    partial class CTSP_BranchAndBound {

        private CTSP_Distances _distances;
        private int _upperBound;

        public CTSP_BranchAndBound (ref CTSP_Distances distances, int upperBound) {
            _distances = distances;
            _upperBound = upperBound;
        }

        public void make () {

        }


    }
}
