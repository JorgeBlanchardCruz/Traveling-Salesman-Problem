using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Traveling_Salesman_Problem {
    public partial class Form1 : Form {

        CTSP_instance TSProblem;

        public Form1 () {
            InitializeComponent();
        }

        private void btOpenFile_Click (object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            pnActions.Enabled = false;
            pnBranchAndBound.Enabled = false;

            Stream file = selectFile(txFile);

            TSProblem = new CTSP_instance();

            string error = TSProblem.makeFromFile(ref file);

            if (error != string.Empty) {
                lbLoad.ForeColor = Color.Firebrick;
                lbLoad.Text = error;
                pnActions.Enabled = false;

            } else {
                lbLoad.ForeColor = Color.OliveDrab;
                lbLoad.Text = "TSP cargado correctamente";
                pnActions.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }

        private void btExec_upperBound_Click (object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            TSProblem.exec_UpperBound();

            txUpperBound.Text = TSProblem.upperBound.upperBound.ToString();
            txRoute.Text = string.Empty;
            foreach (var vertex in TSProblem.upperBound.Route) {
                txRoute.Text += vertex.ToString() + ",";
            }

            pnBranchAndBound.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void btExec_BranchAndBound_Click (object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            TSProblem.exec_BranchAndBound();

            txBestCost.Text = TSProblem.branchAndBound.bestCost.ToString();
            txOptimalRoute.Text = string.Empty;
            foreach (var vertex in TSProblem.branchAndBound.optimalRoute) {
                txOptimalRoute.Text += vertex.ToString() + ",";
            }

            Cursor.Current = Cursors.Default;
        }

        private Stream selectFile (Control putFileName) {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "XML Files (.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.InitialDirectory = "E:\\Ingeniería Informática\\2015-2016\\COMPLEJIDAD COMPUTACIONAL\\Practica 4 Traveling Salesman Problem\\Traveling Salesman Problem\\Test\burma14.xml";
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
