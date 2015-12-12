namespace Traveling_Salesman_Problem {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.label2 = new System.Windows.Forms.Label();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.txFile = new System.Windows.Forms.TextBox();
            this.lbLoad = new System.Windows.Forms.Label();
            this.btExec_upperBound = new System.Windows.Forms.Button();
            this.txUpperBound = new System.Windows.Forms.TextBox();
            this.pnActions = new System.Windows.Forms.Panel();
            this.btExec_BranchAndBound = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txRoute = new System.Windows.Forms.TextBox();
            this.pnBranchAndBound = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txOptimalRoute = new System.Windows.Forms.TextBox();
            this.txBestCost = new System.Windows.Forms.TextBox();
            this.pnActions.SuspendLayout();
            this.pnBranchAndBound.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(49, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "XML File";
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(543, 48);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(33, 25);
            this.btOpenFile.TabIndex = 8;
            this.btOpenFile.Text = "...";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // txFile
            // 
            this.txFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFile.Location = new System.Drawing.Point(52, 49);
            this.txFile.Name = "txFile";
            this.txFile.ReadOnly = true;
            this.txFile.Size = new System.Drawing.Size(485, 23);
            this.txFile.TabIndex = 7;
            // 
            // lbLoad
            // 
            this.lbLoad.AutoSize = true;
            this.lbLoad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoad.ForeColor = System.Drawing.Color.Firebrick;
            this.lbLoad.Location = new System.Drawing.Point(55, 75);
            this.lbLoad.Name = "lbLoad";
            this.lbLoad.Size = new System.Drawing.Size(0, 20);
            this.lbLoad.TabIndex = 10;
            // 
            // btExec_upperBound
            // 
            this.btExec_upperBound.Location = new System.Drawing.Point(40, 14);
            this.btExec_upperBound.Name = "btExec_upperBound";
            this.btExec_upperBound.Size = new System.Drawing.Size(134, 25);
            this.btExec_upperBound.TabIndex = 11;
            this.btExec_upperBound.Text = "1 - Exec UpperBound";
            this.btExec_upperBound.UseVisualStyleBackColor = true;
            this.btExec_upperBound.Click += new System.EventHandler(this.btExec_upperBound_Click);
            // 
            // txUpperBound
            // 
            this.txUpperBound.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txUpperBound.Location = new System.Drawing.Point(172, 45);
            this.txUpperBound.Name = "txUpperBound";
            this.txUpperBound.ReadOnly = true;
            this.txUpperBound.Size = new System.Drawing.Size(353, 23);
            this.txUpperBound.TabIndex = 12;
            // 
            // pnActions
            // 
            this.pnActions.Controls.Add(this.pnBranchAndBound);
            this.pnActions.Controls.Add(this.label3);
            this.pnActions.Controls.Add(this.label1);
            this.pnActions.Controls.Add(this.txRoute);
            this.pnActions.Controls.Add(this.btExec_upperBound);
            this.pnActions.Controls.Add(this.txUpperBound);
            this.pnActions.Enabled = false;
            this.pnActions.Location = new System.Drawing.Point(12, 98);
            this.pnActions.Name = "pnActions";
            this.pnActions.Size = new System.Drawing.Size(600, 355);
            this.pnActions.TabIndex = 13;
            // 
            // btExec_BranchAndBound
            // 
            this.btExec_BranchAndBound.Location = new System.Drawing.Point(37, 3);
            this.btExec_BranchAndBound.Name = "btExec_BranchAndBound";
            this.btExec_BranchAndBound.Size = new System.Drawing.Size(134, 35);
            this.btExec_BranchAndBound.TabIndex = 16;
            this.btExec_BranchAndBound.Text = "2 - Exec BranchAndBound";
            this.btExec_BranchAndBound.UseVisualStyleBackColor = true;
            this.btExec_BranchAndBound.Click += new System.EventHandler(this.btExec_BranchAndBound_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(110, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Route";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(71, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Upper Bound";
            // 
            // txRoute
            // 
            this.txRoute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txRoute.Location = new System.Drawing.Point(172, 74);
            this.txRoute.Multiline = true;
            this.txRoute.Name = "txRoute";
            this.txRoute.ReadOnly = true;
            this.txRoute.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txRoute.Size = new System.Drawing.Size(353, 76);
            this.txRoute.TabIndex = 13;
            // 
            // pnBranchAndBound
            // 
            this.pnBranchAndBound.Controls.Add(this.label4);
            this.pnBranchAndBound.Controls.Add(this.label5);
            this.pnBranchAndBound.Controls.Add(this.txOptimalRoute);
            this.pnBranchAndBound.Controls.Add(this.txBestCost);
            this.pnBranchAndBound.Controls.Add(this.btExec_BranchAndBound);
            this.pnBranchAndBound.Enabled = false;
            this.pnBranchAndBound.Location = new System.Drawing.Point(3, 156);
            this.pnBranchAndBound.Name = "pnBranchAndBound";
            this.pnBranchAndBound.Size = new System.Drawing.Size(594, 196);
            this.pnBranchAndBound.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(61, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Optimal Route";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(89, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Best Cost";
            // 
            // txOptimalRoute
            // 
            this.txOptimalRoute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txOptimalRoute.Location = new System.Drawing.Point(169, 85);
            this.txOptimalRoute.Multiline = true;
            this.txOptimalRoute.Name = "txOptimalRoute";
            this.txOptimalRoute.ReadOnly = true;
            this.txOptimalRoute.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txOptimalRoute.Size = new System.Drawing.Size(353, 76);
            this.txOptimalRoute.TabIndex = 18;
            // 
            // txBestCost
            // 
            this.txBestCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBestCost.Location = new System.Drawing.Point(169, 56);
            this.txBestCost.Name = "txBestCost";
            this.txBestCost.ReadOnly = true;
            this.txBestCost.Size = new System.Drawing.Size(353, 23);
            this.txBestCost.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 465);
            this.Controls.Add(this.pnActions);
            this.Controls.Add(this.lbLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.txFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Traveling Salesman Problem";
            this.pnActions.ResumeLayout(false);
            this.pnActions.PerformLayout();
            this.pnBranchAndBound.ResumeLayout(false);
            this.pnBranchAndBound.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox txFile;
        private System.Windows.Forms.Label lbLoad;
        private System.Windows.Forms.Button btExec_upperBound;
        private System.Windows.Forms.TextBox txUpperBound;
        private System.Windows.Forms.Panel pnActions;
        private System.Windows.Forms.TextBox txRoute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btExec_BranchAndBound;
        private System.Windows.Forms.Panel pnBranchAndBound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txOptimalRoute;
        private System.Windows.Forms.TextBox txBestCost;
    }
}

