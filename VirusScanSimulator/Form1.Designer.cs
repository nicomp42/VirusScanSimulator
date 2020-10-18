namespace VirusScanSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartScan = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lblVirusName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartScan
            // 
            this.btnStartScan.Location = new System.Drawing.Point(649, 397);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 0;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(190, 82);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(467, 265);
            this.txtResults.TabIndex = 1;
            // 
            // lblVirusName
            // 
            this.lblVirusName.AutoSize = true;
            this.lblVirusName.Location = new System.Drawing.Point(190, 362);
            this.lblVirusName.Name = "lblVirusName";
            this.lblVirusName.Size = new System.Drawing.Size(0, 13);
            this.lblVirusName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(190, 397);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblVirusName);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnStartScan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label lblVirusName;
        private System.Windows.Forms.Label lblDescription;
    }
}

