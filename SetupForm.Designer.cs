namespace weather
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.cbTempScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchLoaction = new System.Windows.Forms.Button();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbLocations);
            this.groupBox1.Controls.Add(this.cbTempScale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearchLoaction);
            this.groupBox1.Controls.Add(this.tbLocation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 156);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location Setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Temp Scale";
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(63, 45);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(361, 95);
            this.lbLocations.TabIndex = 4;
            this.lbLocations.SelectedIndexChanged += new System.EventHandler(this.lbLocations_SelectedIndexChanged);
            // 
            // cbTempScale
            // 
            this.cbTempScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTempScale.FormattingEnabled = true;
            this.cbTempScale.Location = new System.Drawing.Point(430, 70);
            this.cbTempScale.Name = "cbTempScale";
            this.cbTempScale.Size = new System.Drawing.Size(40, 21);
            this.cbTempScale.TabIndex = 6;
            this.cbTempScale.Visible = false;
            this.cbTempScale.SelectedIndexChanged += new System.EventHandler(this.cbTempScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lookup";
            // 
            // btnSearchLoaction
            // 
            this.btnSearchLoaction.Location = new System.Drawing.Point(430, 17);
            this.btnSearchLoaction.Name = "btnSearchLoaction";
            this.btnSearchLoaction.Size = new System.Drawing.Size(75, 23);
            this.btnSearchLoaction.TabIndex = 2;
            this.btnSearchLoaction.Text = "Search";
            this.btnSearchLoaction.UseVisualStyleBackColor = true;
            this.btnSearchLoaction.Click += new System.EventHandler(this.btnSearchLoaction_Click);
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(63, 19);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(361, 20);
            this.tbLocation.TabIndex = 3;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 172);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Shown += new System.EventHandler(this.SetupForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.ComboBox cbTempScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchLoaction;
        private System.Windows.Forms.TextBox tbLocation;
    }
}