using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem {
    partial class CTSP_BranchAndBound {

        private class CBranch {
            public CBranch _parentBranch;
            public int _branchlevel;
            public int _vertex;
            public int _cost;
            public int _lowerBound;
            public bool _pruned;
            public List<int> _partialRoute;
            public List<CBranch> _childrenBranches;

            public CBranch (ref CBranch parentBranch, int branchlevel, int vertex, int cost, int lowerBound, List<int> partialRoute, bool pruned = false) {
                _parentBranch = parentBranch;
                _branchlevel = branchlevel;
                _vertex = vertex;
                _cost = cost;
                _lowerBound = lowerBound;
                _pruned = pruned;
                _partialRoute = partialRoute;
                _childrenBranches = new List<CBranch>();
            }

            public CBranch (int branchlevel, int vertex, int cost, int lowerBound, List<int> partialRoute, bool pruned = false) {
                _branchlevel = branchlevel;
                _vertex = vertex;
                _cost = cost;
                _lowerBound = lowerBound;
                _pruned = pruned;
                _partialRoute = partialRoute;
                _childrenBranches = new List<CBranch>();
            }
        }

        private const int _PERCUP = 18;

        private CTSP_UpperBound _TSPupperBound;

        private CTSP_Distances _distances;
        private int _upperBound;
        private int _numVertex;
        private int _bestCost;

        private List<int> _optimalRoute;

        private CBranch _tree;

        public int bestCost
        {
            get { return _bestCost; }
        }

        public List<int> optimalRoute
        {
            get { return _optimalRoute; }
        }

        public CTSP_BranchAndBound (ref CTSP_Distances distances, int upperBound, int numVertex) {
            _distances = distances;
            _upperBound = upperBound + ((upperBound * _PERCUP) / 100);
            _numVertex = numVertex;
            _bestCost = int.MaxValue;

            _optimalRoute = new List<int>();

            _tree = new CBranch(-1,-1, 0, _upperBound, new List<int>());

            _TSPupperBound = new CTSP_UpperBound(ref _distances);
        }

        public void run () {
            BranchAndBound(_tree, 0);
        }

        private void BranchAndBound (CBranch parentbranch, int level) {
            if (parentbranch._pruned)
                return;

            if (level == _numVertex) {
                //getRoute(ref parentbranch);

                parentbranch._partialRoute.Add(parentbranch._partialRoute[0]);

                parentbranch._cost += _distances.Matrix[parentbranch._partialRoute[parentbranch._partialRoute.Count - 2], parentbranch._partialRoute[parentbranch._partialRoute.Count - 1]];

                if (_bestCost > parentbranch._cost) {
                    _bestCost = parentbranch._cost;
                    _optimalRoute = parentbranch._partialRoute;
                }
            }                

            int savelevel = level;

            for (int i = 0; i < _numVertex; i++) {
                if (!_TSPupperBound.isVisited(parentbranch._partialRoute, i)) {

                    List<int> partialroute = parentbranch._partialRoute.GetRange(0, parentbranch._partialRoute.Count);
                    partialroute.Add(i);

                    int cost = 0;
                    if (parentbranch._vertex != -1)
                        cost = parentbranch._cost + _distances.Matrix[parentbranch._vertex, i];

                    //int lowerbound = cost + KruskalBound(ref partialroute);
                    int lowerbound = _TSPupperBound.run(partialroute);
                    bool pruned = (lowerbound > _upperBound ? true : false);

                    parentbranch._childrenBranches.Add(new CBranch(ref parentbranch, level, i, cost, lowerbound, partialroute, pruned));
                }
            }

            foreach (CBranch branch in parentbranch._childrenBranches) {
                if (!branch._pruned) {
                    BranchAndBound(branch, level + 1);

                    level = savelevel;
                }                    
            }
        }

        private void getRoute (ref CBranch lastbranch) {

            List<int> route = new List<int>();

            CBranch currentBranch = lastbranch;
            while (currentBranch != null) {

                route.Add(currentBranch._vertex);

                currentBranch = currentBranch._parentBranch;
            }

            route.Reverse();
            route.Add(route[0]);

            int totalCost = lastbranch._cost + _distances.Matrix[route[route.Count - 2], route[route.Count - 1]];
            //lastbranch._childrenBranches.Add(ref lastbranch, route.Count, route[route.Count - 1], totalCost, totalCost, partialroute, pruned)

            if (_bestCost > totalCost) {
                _bestCost = totalCost;
            }
        }

        private int KruskalBound (ref List<int> partialRoute) {
            List<List<int>> Kruskalrun = Kruskal(_distances, ref partialRoute);

            int KruskalSum = 0;
            foreach (List<int> fil in Kruskalrun) {
                foreach (int col in fil) {
                    KruskalSum += col;
                }
            }

            return KruskalSum;
        }

        private List<List<int>> Kruskal (CTSP_Distances distances, ref List<int> partialroute) {
            CTSP_Distances adyacencia = distances;
            List<List<int>> arbol = new List<List<int>>();
            List<int> pertenece = new List<int>(); // indica a que árbol pertenece el nodo

            for (int i = 0; i < _numVertex; i++) {
                pertenece.Add(i);
                arbol.Add(new List<int>());
                for (int j = 0; j < _numVertex; j++) {

                    if (partialroute.Count > i  && partialroute[i] == j)
                        adyacencia.Matrix[i, j] = 0;

                    arbol[i].Add(0);
                }
                    
            }

            int nodoA = 0;
            int nodoB = 0;
            int arcos = 1;
            while (arcos < _numVertex) {
                // Encontrar  el arco mínimo que no forma ciclo y guardar los nodos y la distancia.
                int min = int.MaxValue;
                for (int i = 0; i < _numVertex; i++)
                    for (int j = 0; j < _numVertex; j++)
                        if (min > adyacencia.Matrix[i,j] && adyacencia.Matrix[i, j] != 0 && pertenece[i] != pertenece[j]) {
                            min = adyacencia.Matrix[i, j];
                            nodoA = i;
                            nodoB = j;
                        }

                // Si los nodos no pertenecen al mismo árbol agrego el arco al árbol mínimo.
                if (pertenece[nodoA] != pertenece[nodoB]) {
                    arbol[nodoA][nodoB] = min;
                    arbol[nodoB][nodoA] = min;

                    // Todos los nodos del árbol del nodoB ahora pertenecen al árbol del nodoA.
                    int temp = pertenece[nodoB];
                    pertenece[nodoB] = pertenece[nodoA];
                    for (int k = 0; k < _numVertex; k++)
                        if (pertenece[k] == temp)
                            pertenece[k] = pertenece[nodoA];

                    arcos++;
                }
            }

            return arbol;
        }

    }
}
