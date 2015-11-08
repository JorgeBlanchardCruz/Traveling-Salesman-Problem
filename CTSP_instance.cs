using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        private decimal[,] _TSPValues;

        public CTSP_instance () {
        }

        public string makeFromFile (ref Stream file) {
            try {

                XmlDocument Reader = new XmlDocument();
                Reader.Load(file);

                XmlNode root = Reader.DocumentElement;                

                int numNodes = root.SelectNodes("//graph//vertex").Count;
                _TSPValues = new decimal[numNodes, numNodes];

                int numRow = 0;
                int numEdge = 0;
                XmlNodeList nodelist1 = root.SelectNodes("//graph//vertex//edge");
                foreach (XmlNode node in nodelist1) {

                    if (changeRow(numEdge, numNodes))
                        numRow++;
                    
                    if (nodeItself(numEdge, numNodes, numRow)) {
                        _TSPValues[numRow, Convert.ToInt32(nodePositionRelativeRow(numEdge, numNodes))] = 0;

                        numEdge++;
                    }

                    decimal cost = getCost(node.Attributes[0].Value);
                    _TSPValues[numRow, Convert.ToInt32(node.FirstChild.Value)] = cost;

                    numEdge++;
                }

                return string.Empty;
            } catch (Exception e) {
                return e.Message;
            }
        }

        private bool changeRow (int numEdge, int numNodes) {
            return ((numEdge % numNodes) == 0 && numEdge != 0 ? true : false);
        }

        private bool nodeItself (int numEdge, int numNodes, int numRow) {
            decimal nodePositionRelativeRow_ = nodePositionRelativeRow(numEdge, numNodes);
            return (Convert.ToDecimal(numRow) == nodePositionRelativeRow_ ? true : false);
        }

        private decimal nodePositionRelativeRow (int numEdge, int numNodes) {
            return (Convert.ToDecimal(numEdge) / Convert.ToDecimal(numNodes));
        }

        private decimal getCost(string value) {
            value = value.Replace('.', ',');
            value = value.Remove(value.LastIndexOf('e'), value.Count() - value.LastIndexOf('e'));
            return Convert.ToDecimal(value);
        }


    }
}
