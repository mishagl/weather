namespace weather
{
    partial class ForecastCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTempLow = new System.Windows.Forms.Label();
            this.lblTempHigh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(7, 7);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "Day";
            // 
            // lblTempLow
            // 
            this.lblTempLow.AutoSize = true;
            this.lblTempLow.Location = new System.Drawing.Point(43, 22);
            this.lblTempLow.Name = "lblTempLow";
            this.lblTempLow.Size = new System.Drawing.Size(31, 13);
            this.lblTempLow.TabIndex = 1;
            this.lblTempLow.Text = "N/A°";
            // 
            // lblTempHigh
            // 
            this.lblTempHigh.AutoSize = true;
            this.lblTempHigh.Location = new System.Drawing.Point(43, 37);
            this.lblTempHigh.Name = "lblTempHigh";
            this.lblTempHigh.Size = new System.Drawing.Size(31, 13);
            this.lblTempHigh.TabIndex = 2;
            this.lblTempHigh.Text = "N/A°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Low:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "High:";
            // 
            // lblCondition
            // 
            this.lblCondition.Location = new System.Drawing.Point(7, 52);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(100, 80);
            this.lblCondition.TabIndex = 5;
            this.lblCondition.Text = "N/A";
            // 
            // ForecastCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTempHigh);
            this.Controls.Add(this.lblTempLow);
            this.Controls.Add(this.lblDay);
            this.Name = "ForecastCtrl";
            this.Size = new System.Drawing.Size(119, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTempLow;
        private System.Windows.Forms.Label lblTempHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCondition;
    }
}
