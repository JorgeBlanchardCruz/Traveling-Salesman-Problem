﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Traveling_Salesman_Problem {
    partial class CTSP_Distances {

        private decimal[,] _Matrix;
        private int _numVertex;

        public decimal[,] Matrix {
            get { return _Matrix; }
        }

        public int NumNodes {
            get { return _numVertex; }
        }


        public CTSP_Distances () {
        }

        public void newMatrix(int numVertex) {
            _numVertex = numVertex;
            _Matrix = new decimal[numVertex, numVertex];
        }

    }
}
