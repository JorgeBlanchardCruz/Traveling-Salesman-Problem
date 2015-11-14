using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        private CTSP_Distances _distances;

        private CTSP_UpperBound _upperBound;



        public string makeFromFile (ref Stream file) {
            try {

                _distances = new CTSP_Distances();

                XmlDocument Reader = new XmlDocument();
                Reader.Load(file);

                XmlNode root = Reader.DocumentElement;

                int numVertex = root.SelectNodes("//graph//vertex").Count;
                _distances.newMatrix(numVertex);

                int numRow = 0;
                int numEdge = 0;
                XmlNodeList Vertexlist1 = root.SelectNodes("//graph//vertex//edge");
                foreach (XmlNode Vertex in Vertexlist1) {

                    if (isChangeRow(numEdge, numVertex))
                        numRow++;

                    if (isVertexItself(numEdge, numVertex, numRow)) {
                        _distances.Matrix[numRow, Convert.ToInt32(VertexPositionRelativeRow(numEdge, numVertex))] = 0;

                        numEdge++;
                    }

                    decimal cost = getCost(Vertex.Attributes[0].Value);
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
            return (Convert.ToDecimal(numRow) == VertexPositionRelativeRow_ ? true : false);
        }

        private decimal VertexPositionRelativeRow (int numEdge, int numVertex) {
            return (Convert.ToDecimal(numEdge) / Convert.ToDecimal(numVertex));
        }

        private decimal getCost (string value) {
            value = value.Replace('.', ',');
            value = value.Remove(value.LastIndexOf('e'), value.Count() - value.LastIndexOf('e'));
            return Convert.ToDecimal(value);
        }

        public void exec_UpperBound () {
            _upperBound = new CTSP_UpperBound();

            _upperBound.make(ref _distances);

        }


    }
}
