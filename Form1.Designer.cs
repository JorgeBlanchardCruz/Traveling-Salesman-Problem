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
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(49, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "File";
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(543, 71);
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
            this.txFile.Location = new System.Drawing.Point(52, 72);
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
            this.lbLoad.Location = new System.Drawing.Point(55, 98);
            this.lbLoad.Name = "lbLoad";
            this.lbLoad.Size = new System.Drawing.Size(0, 20);
            this.lbLoad.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 465);
            this.Controls.Add(this.lbLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.txFile);
            this.Name = "Form1";
            this.Text = "The Traveling Salesman Problem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox txFile;
        private System.Windows.Forms.Label lbLoad;
    }
}

