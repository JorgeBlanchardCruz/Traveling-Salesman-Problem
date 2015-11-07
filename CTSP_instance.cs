using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        public CTSP_instance () {

        }

        public string makeFromFile (ref Stream file) {
            try {

                XmlDocument Reader = new XmlDocument();
                Reader.Load(file);

                XmlNodeList nodelist1 = Reader.SelectNodes("/vertex");
                foreach (var node in nodelist1) {

                    XmlNodeList nodelist2 = Reader.SelectNodes("/vertex/edge");
                    foreach (var childnode in nodelist2) {


                    }


                }




                return string.Empty;
            } catch (Exception e) {
                return e.Message;
            }
        }


    }
}
