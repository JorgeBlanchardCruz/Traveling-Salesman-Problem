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

        public List<int> Route {
            get { return _route; }
        }

        public decimal upperBound {
            get { return _upperBound; }
        }

        public CTSP_UpperBound () {
            _distances = null;
            _route = new List<int>();
            _upperBound = decimal.MaxValue;
        }

        public void make (ref CTSP_Distances distances) {
            _distances = distances;

            _upperBound = 0;

            exec_NearestNeighbour();

            _2opt();
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

        private void _2opt () {

            bool impovement = true;
            decimal best_distance = 0;
            while (impovement) {

                impovement = false;

                best_distance = calculateTotalDistance(_route);

                impovement = _2opt_interation(best_distance);
            }

            _upperBound = best_distance;
        }

        private decimal calculateTotalDistance(List<int> route) {
            decimal distance = 0;

            for (int i = 1; i < route.Count; i++)
                distance += _distances.Matrix[route[i - 1], route[i]];

            return distance;
        }

        private bool _2opt_interation (decimal best_distance) {
            for (int i = 0; i < _route.Count - 1; i++) {
                for (int k = i + 1; k < _route.Count; k++) {

                    List<int> new_route = _2optSwap(_route, i, k);

                    decimal new_distance = calculateTotalDistance(new_route);

                    if (new_distance < best_distance) {
                        _route = new_route;
                        return true;
                    }

                }
            }

            return false;
        }

        private List<int> _2optSwap (List<int> existing_route, int i, int k) {
            List<int> new_route = new List<int>();

            //1.take route[1] to route[i - 1] and add them in order to new_route
            for (int n = 0; n < i; n++) 
                new_route.Add(existing_route[n]);

            //2.take route[i] to route[k] and add them in reverse order to new_route
            for (int n = k; n >= i; n--)
                new_route.Add(existing_route[n]);

            //3. take route[k+1] to end and add them in order to new_route
            for (int n = k+1; n < existing_route.Count; n++)
                new_route.Add(existing_route[n]);

            return new_route;

        }


    }
}
