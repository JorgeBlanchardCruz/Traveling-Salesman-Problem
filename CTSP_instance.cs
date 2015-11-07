using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Salesman_Problem {
    class CTSP_instance {

        public CTSP_instance () {

        }

        public string makeFromFile (ref Stream file) {
            try {

                using (StreamReader reader = new StreamReader(file)) {


                }
                file.Close();

                return string.Empty;
            } catch (Exception e) {
                return e.Message;
            }
        }
    }
}
