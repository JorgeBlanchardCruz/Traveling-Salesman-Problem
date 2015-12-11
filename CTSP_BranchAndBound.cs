using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem {
    partial class CTSP_BranchAndBound {

        private class CBranch {            
            public int _vertex;
            public int _cost;
            public int _lowerBound;
            public bool _pruned;
            public List<int> _partialRoute;
            public List<CBranch> _childrenBranches;

            public CBranch (int vertex, int cost, int lowerBound, List<int> partialRoute, bool pruned = false) {
                _vertex = vertex;
                _cost = cost;
                _lowerBound = lowerBound;
                _pruned = pruned;
                _partialRoute = partialRoute;
                _childrenBranches = new List<CBranch>();
            }
        }


        private CTSP_UpperBound _TSPupperBound;

        private CTSP_Distances _distances;
        private int _upperBound;
        private int _numVertex;

        private CBranch _tree;

        public CTSP_BranchAndBound (ref CTSP_Distances distances, int upperBound, int numVertex) {
            _distances = distances;
            _upperBound = upperBound + ((upperBound * 20) / 100);
            _numVertex = numVertex;

            _tree = new CBranch(-1, 0, _upperBound, new List<int>());

            _TSPupperBound = new CTSP_UpperBound(ref _distances);
        }

        public void run () {
            BranchAndBound(_tree);
        }

        private void BranchAndBound (CBranch parentbranch) {
            if (parentbranch._pruned)
                return;

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

                    parentbranch._childrenBranches.Add(new CBranch(i, cost, lowerbound, partialroute, pruned));
                }
            }

            foreach (CBranch branch in parentbranch._childrenBranches) {
                if (!branch._pruned) {
                    BranchAndBound(branch);
                }
                    
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
