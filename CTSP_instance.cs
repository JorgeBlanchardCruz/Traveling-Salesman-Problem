using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        private CTSP_Distances Distances;

        public string makeFromFile (ref Stream file) {
            try {

                Distances = new CTSP_Distances();

                XmlDocument Reader = new XmlDocument();
                Reader.Load(file);

                XmlNode root = Reader.DocumentElement;

                int numNodes = root.SelectNodes("//graph//vertex").Count;
                Distances.Matrix = new decimal[numNodes, numNodes];

                int numRow = 0;
                int numEdge = 0;
                XmlNodeList nodelist1 = root.SelectNodes("//graph//vertex//edge");
                foreach (XmlNode node in nodelist1) {

                    if (isChangeRow(numEdge, numNodes))
                        numRow++;

                    if (isNodeItself(numEdge, numNodes, numRow)) {
                        Distances.Matrix[numRow, Convert.ToInt32(nodePositionRelativeRow(numEdge, numNodes))] = 0;

                        numEdge++;
                    }

                    decimal cost = getCost(node.Attributes[0].Value);
                    Distances.Matrix[numRow, Convert.ToInt32(node.FirstChild.Value)] = cost;

                    numEdge++;
                }

                return string.Empty;
            } catch (Exception e) {
                return e.Message;
            }
        }

        private bool isChangeRow (int numEdge, int numNodes) {
            return ((numEdge % numNodes) == 0 && numEdge != 0 ? true : false);
        }

        private bool isNodeItself (int numEdge, int numNodes, int numRow) {
            decimal nodePositionRelativeRow_ = nodePositionRelativeRow(numEdge, numNodes);
            return (Convert.ToDecimal(numRow) == nodePositionRelativeRow_ ? true : false);
        }

        private decimal nodePositionRelativeRow (int numEdge, int numNodes) {
            return (Convert.ToDecimal(numEdge) / Convert.ToDecimal(numNodes));
        }

        private decimal getCost (string value) {
            value = value.Replace('.', ',');
            value = value.Remove(value.LastIndexOf('e'), value.Count() - value.LastIndexOf('e'));
            return Convert.ToDecimal(value);
        }


    }
}
