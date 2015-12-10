namespace Traveling_Salesman_Problem {
    partial class CTSP_Distances {

        private int[,] _Matrix;
        private int _numVertex;

        public int[,] Matrix {
            get { return _Matrix; }
        }

        public int NumNodes {
            get { return _numVertex; }
        }


        public CTSP_Distances () {
        }

        public void newMatrix(int numVertex) {
            _numVertex = numVertex;
            _Matrix = new int[numVertex, numVertex];
        }

    }
}
