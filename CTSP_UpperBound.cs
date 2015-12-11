using System;
using System.Collections.Generic;

namespace Traveling_Salesman_Problem {
    partial class CTSP_UpperBound {

        private const int NUMNearestNeighbour = 50;

        private CTSP_Distances _distances;

        private List<int> _route;
        private int _upperBound;

        public List<int> Route {
            get { return _route; }
        }

        public int upperBound {
            get { return _upperBound; }
        }

        public CTSP_UpperBound (ref CTSP_Distances distances) {
            _distances = distances;
            _route = new List<int>();
            _upperBound = int.MaxValue;
        }

        public void run () {
            _route = exec_NearestNeighbour(getRandomFirstVertex());
            int best_distance = calculateTotalDistance(_route);

            for (int i = 1; i < NUMNearestNeighbour; i++) {
                List<int> new_route = exec_NearestNeighbour(getRandomFirstVertex());

                int new_distance = calculateTotalDistance(new_route);               

                if (new_distance < best_distance) {
                    best_distance = new_distance;
                    _route = new_route;
                }
            }            

            _2opt();
        }

        private List<int> getRandomFirstVertex () {
            Random random = new Random();
            int firstVertex = random.Next(0, _distances.NumNodes);

            List<int> new_route = new List<int>();
            new_route.Add(firstVertex);

            return new_route;
        }

        public int run (List<int> partialroute) {
            List<int> new_route = partialroute.GetRange(0, partialroute.Count); ;
            _route = exec_NearestNeighbour(new_route);
            //_2opt();

            return calculateTotalDistance(_route);
        }

        private List<int> exec_NearestNeighbour (List<int> new_route) {

            int currentVertex = new_route[new_route.Count - 1];

            for (int iteration = 0; iteration < _distances.NumNodes - 1; iteration++) {

                int nearbyUnvisitedVertex = find_nearbyUnvisitedVertex(new_route, currentVertex);

                currentVertex = nearbyUnvisitedVertex;

                new_route.Add(currentVertex);
            }

            new_route.Add(new_route[0]);

            return new_route;
        }

        private int find_nearbyUnvisitedVertex (List<int> route, int currentVertex) {

            int nearbyUnvisitedVertex = 0;
            int shortestEdge = int.MaxValue;  
                      
            for (int vertex = 0; vertex < _distances.NumNodes; vertex++) {
                if (!isVertexItself(currentVertex, vertex) && !isVisited(route, vertex))
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

        public bool isVisited (List<int> route, int vertex) {
            foreach (int item in route)
                if (vertex == item)
                    return true;

            return false;
        }

        private void _2opt () {

            bool impovement = true;
            int best_distance = 0;
            while (impovement) {

                impovement = false;

                best_distance = calculateTotalDistance(_route);

                impovement = _2opt_interation(best_distance);
            }

            _upperBound = best_distance;
        }

        public int calculateTotalDistance(List<int> route) {
            int distance = 0;

            for (int i = 1; i < route.Count; i++)
                distance += _distances.Matrix[route[i - 1], route[i]];

            return distance;
        }

        private bool _2opt_interation (int best_distance) {
            for (int i = 0; i < _route.Count - 2; i++) {
                for (int k = i + 1; k < _route.Count - 1; k++) {

                    List<int> new_route = _2optSwap(_route, i, k);

                    int new_distance = calculateTotalDistance(new_route);

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
            for (int n = k+1; n < existing_route.Count - 1; n++)
                new_route.Add(existing_route[n]);

            new_route.Add(new_route[0]);

            return new_route;

        }


    }
}
