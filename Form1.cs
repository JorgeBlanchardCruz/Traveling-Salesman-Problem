using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traveling_Salesman_Problem {
    public partial class Form1 : Form {

        CTSP_Distances TSProblem;

        public Form1 () {
            InitializeComponent();
        }

        private void btOpenFile_Click (object sender, EventArgs e) {
            Stream file = selectFile(txFile);

            TSProblem = new CTSP_Distances();

            string error = TSProblem.makeFromFile(ref file);

            if (error != string.Empty) {
                lbLoad.ForeColor = Color.Firebrick;
                lbLoad.Text = error;

            } else {
                lbLoad.ForeColor = Color.OliveDrab;
                lbLoad.Text = "TSP cargado correctamente";


            }
        }


        private Stream selectFile (Control putFileName) {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "XML Files (.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Multiselect = false;

            DialogResult userClicked = openFileDialog1.ShowDialog();

            if (userClicked == DialogResult.OK) {
                putFileName.Text = openFileDialog1.FileName;

                return openFileDialog1.OpenFile();
            }

            return null;
        }

    }
}
