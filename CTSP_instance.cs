using System;
using System.IO;
using System.Xml;


namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        private CTSP_Distances _distances;

        private CTSP_UpperBound _upperBound;

        private CTSP_BranchAndBound _branchAndBound;


        public CTSP_UpperBound upperBound
        {
            get { return _upperBound; }
        }
        
        public CTSP_BranchAndBound branchAndBound
        {
            get { return _branchAndBound; }
        }

        private int _numVertex;

        public string makeFromFile (ref Stream file) {
            try {

                _distances = new CTSP_Distances();

                XmlDocument Reader = new XmlDocument();
                Reader.Load(file);

                XmlNode root = Reader.DocumentElement;

                _numVertex = root.SelectNodes("//graph//vertex").Count;
                _distances.newMatrix(_numVertex);

                int numRow = 0;
                int numEdge = 0;
                XmlNodeList Vertexlist1 = root.SelectNodes("//graph//vertex//edge");
                foreach (XmlNode Vertex in Vertexlist1) {

                    if (isChangeRow(numEdge, _numVertex))
                        numRow++;

                    if (isVertexItself(numEdge, _numVertex, numRow)) {
                        _distances.Matrix[numRow, Convert.ToInt32(VertexPositionRelativeRow(numEdge, _numVertex))] = 0;  
                        numEdge++;
                    }

                    int cost = getCost(Vertex.Attributes[0].Value);
                    _distances.Matrix[numRow, Convert.ToInt32(Vertex.FirstChild.Value)] = cost;

                    numEdge++;
                }

                return string.Empty;
            } catch (Exception e) {
                return e.Message;
            }
        }

        private bool isChangeRow (int numEdge, int numVertex) {
            return ((numEdge % numVertex) == 0 && numEdge != 0 ? true : false);
        }

        private bool isVertexItself (int numEdge, int numVertex, int numRow) {
            decimal VertexPositionRelativeRow_ = VertexPositionRelativeRow(numEdge, numVertex);
            return (numRow == VertexPositionRelativeRow_ ? true : false);
        }

        private decimal VertexPositionRelativeRow (int numEdge, int numVertex) {
            return (Convert.ToDecimal(numEdge) / Convert.ToDecimal(numVertex));
        }

        private int getCost (string value) {
            value = value.Replace('.', ',');
            Double tempvalue = new Double();
            tempvalue = Convert.ToDouble(value);
            //value = value.Remove(value.LastIndexOf('e'), value.Count() - value.LastIndexOf('e'));
            return Convert.ToInt32(tempvalue);
        }

        public void exec_UpperBound () {
            _upperBound = new CTSP_UpperBound(ref _distances);
            _upperBound.run();
        }

        public void exec_BranchAndBound () {
            _branchAndBound = new CTSP_BranchAndBound(ref _distances, _upperBound.upperBound, _numVertex);
            _branchAndBound.run();
        }

    }
}
