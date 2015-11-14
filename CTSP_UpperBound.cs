using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Salesman_Problem {
    partial class CTSP_UpperBound {

        private CTSP_Distances _distances;

        private List<int> _route;
        private decimal _upperBound;

        public CTSP_UpperBound () {
            _distances = null;
            _route = new List<int>();
            _upperBound = decimal.MaxValue;
        }

        public void make (ref CTSP_Distances distances) {
            _distances = distances;

            _upperBound = 0;

            exec_NearestNeighbour();
        }

        public void exec_NearestNeighbour () {

            Random random = new Random();

            int currentVertex = random.Next(0, _distances.NumNodes);

            _route.Add(currentVertex);

            for (int iteration = 0; iteration < _distances.NumNodes - 1; iteration++) {

                int nearbyUnvisitedVertex = find_nearbyUnvisitedVertex(currentVertex);
                _upperBound += _distances.Matrix[currentVertex, nearbyUnvisitedVertex];

                currentVertex = nearbyUnvisitedVertex;

                _route.Add(currentVertex);
            }
        }


        private int find_nearbyUnvisitedVertex (int currentVertex) {

            int nearbyUnvisitedVertex = 0;
            decimal shortestEdge = Decimal.MaxValue;  
                      
            for (int vertex = 0; vertex < _distances.NumNodes; vertex++) {
                if (!isVertexItself(currentVertex, vertex) && !isVisited(vertex))
                    if (_distances.Matrix[currentVertex, vertex] < shortestEdge) {

                        nearbyUnvisitedVertex = vertex;
                        shortestEdge = _distances.Matrix[currentVertex, vertex];                        
                    }
            }

            return nearbyUnvisitedVertex;
        }

        private bool isVertexItself (int vertex1, int vertex2) {
            return (vertex1 == vertex2 ? true : false);
        }

        private bool isVisited (int vertex) {
            foreach (int item in _route)
                if (vertex == item)
                    return true;

            return false;
        }


    }
}
