using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem {
    partial class CTSP_BranchAndBound {

        private class CBranch {            
            public int _vertex;
            public int _lowerBound;
            public bool _pruned;
            public List<CBranch> _childrenBranches;

            public CBranch (int vertex, int lowerBound, bool pruned = false) {
                _vertex = vertex;
                _lowerBound = lowerBound;
                _pruned = pruned;
                _childrenBranches = new List<CBranch>();
            }
        }


        private CTSP_Distances _distances;
        private readonly List<int> _greedyBestRoute;
        private int _upperBound;
        private int _numVertex;

        private CBranch _tree;

        public CTSP_BranchAndBound (ref CTSP_Distances distances, List<int> greedyBestRoute, int upperBound, int numVertex) {
            _distances = distances;
            _greedyBestRoute = greedyBestRoute;
            _upperBound = upperBound;
            _numVertex = numVertex;

            _tree = new CBranch(-1, _upperBound);
        }

        public void run () {
            BranchAndBound(_tree);
        }

        private void BranchAndBound (CBranch parentbranch) {
            if (parentbranch._pruned)
                return;

            for (int i = 0; i < _greedyBestRoute.Count - 1; i++) {
                int lowerbound = KruskalBound();
                bool pruned = (lowerbound > _upperBound ? true : false);
                parentbranch._childrenBranches.Add(new CBranch(_greedyBestRoute[i], lowerbound, pruned));
            }

            foreach (CBranch branch in parentbranch._childrenBranches) {
                if (!branch._pruned)
                    BranchAndBound(branch);
            }
        }

        private int KruskalBound () {
            List<List<int>> Kruskalrun = Kruskal(ref _distances);

            int KruskalSum = 0;
            foreach (List<int> fil in Kruskalrun) {
                foreach (int col in fil) {
                    KruskalSum += col;
                }
            }

            return KruskalSum;
        }

        private List<List<int>> Kruskal (ref CTSP_Distances adyacencia) {
            List<List<int>> arbol = new List<List<int>>();
            List<int> pertenece = new List<int>(); ; // indica a que árbol pertenece el nodo

            for (int i = 0; i < _numVertex; i++) {
                pertenece.Add(i);
                arbol.Add(new List<int>());
                for (int j = 0; j < _numVertex; j++)
                    arbol[i].Add(0);
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
