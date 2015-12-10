using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem {
    partial class CTSP_BranchAndBound {

        private class CBranch {
            public List<int> _Route;
            public int _lowerBound;
            public bool _pruned;

            public CBranch (int vertex) {
                _Route = new List<int>();
                _Route.Add(vertex);

                _pruned = false;
            }
        }


        private CTSP_Distances _distances;
        private readonly List<int> _greedyBestRoute;
        private int _upperBound;
        private int _numVertex;

        private List<CBranch> _branches;

        public CTSP_BranchAndBound (ref CTSP_Distances distances, List<int> greedyBestRoute, int upperBound, int numVertex) {
            _distances = distances;
            _greedyBestRoute = greedyBestRoute;
            _upperBound = upperBound;
            _numVertex = numVertex;

            _branches = new List<CBranch>();
        }

        public void make () {
            for (int i = 0; i < _greedyBestRoute.Count - 1; i++) {
                _branches.Add(new CBranch(_greedyBestRoute[i]));
                _branches[i]._lowerBound = Kruskal();                
            }

            for (int i = 0; i < _greedyBestRoute.Count - 1; i++) {
                BranchAndBound(1);
            }            

            // luego toca comprobar que branch tiene menor coste y esa será la solución al problema

        }

        private void BranchAndBound (int vertex) {
            if (vertex == _numVertex - 1)
                return;

            for (int i = 0; i < _greedyBestRoute.Count - 1; i++) {

                if (_branches[i]._pruned)
                    return;

                if (vertex == _branches[i]._Route.Count)
                    _branches[i]._Route.Add(vertex);
                else
                    _branches[i]._Route[vertex] = _greedyBestRoute[i];

                _branches[i]._lowerBound = Kruskal();

                if (_branches[i]._lowerBound > _upperBound)
                    _branches[i]._pruned = true;

                BranchAndBound(vertex + 1);
            }
        }

        private int Kruskal () {
            Random random = new Random();

            return random.Next(_upperBound / 2, _upperBound * 2); ;
        }
    }
}
