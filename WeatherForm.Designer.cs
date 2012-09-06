namespace weather
{
    partial class WeatherForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherForm));
            this.notifyIconWeather = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblCurrentLocation = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkSetup = new System.Windows.Forms.LinkLabel();
            this.forecastCtrl2 = new weather.ForecastCtrl();
            this.forecastCtrl1 = new weather.ForecastCtrl();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.picWeather = new System.Windows.Forms.PictureBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconWeather
            // 
            this.notifyIconWeather.BalloonTipText = "Loading...";
            this.notifyIconWeather.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconWeather.Icon")));
            this.notifyIconWeather.Visible = true;
            this.notifyIconWeather.DoubleClick += new System.EventHandler(this.notifyIconWeather_DoubleClick);
            this.notifyIconWeather.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconWeather_MouseClick);
            // 
            // lblCurrentLocation
            // 
            this.lblCurrentLocation.AutoSize = true;
            this.lblCurrentLocation.Location = new System.Drawing.Point(7, 16);
            this.lblCurrentLocation.Name = "lblCurrentLocation";
            this.lblCurrentLocation.Size = new System.Drawing.Size(128, 13);
            this.lblCurrentLocation.TabIndex = 5;
            this.lblCurrentLocation.Text = "Please select a location...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkSetup);
            this.groupBox3.Controls.Add(this.lblCurrentLocation);
            this.groupBox3.Controls.Add(this.forecastCtrl2);
            this.groupBox3.Controls.Add(this.forecastCtrl1);
            this.groupBox3.Controls.Add(this.lblPressure);
            this.groupBox3.Controls.Add(this.lblHumidity);
            this.groupBox3.Controls.Add(this.picWeather);
            this.groupBox3.Controls.Add(this.lblTemperature);
            this.groupBox3.Controls.Add(this.lblDescription);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 149);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Weather";
            // 
            // linkSetup
            // 
            this.linkSetup.AutoSize = true;
            this.linkSetup.Location = new System.Drawing.Point(470, 132);
            this.linkSetup.Name = "linkSetup";
            this.linkSetup.Size = new System.Drawing.Size(35, 13);
            this.linkSetup.TabIndex = 10;
            this.linkSetup.TabStop = true;
            this.linkSetup.Text = "Setup";
            this.linkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetup_LinkClicked);
            // 
            // forecastCtrl2
            // 
            this.forecastCtrl2.Location = new System.Drawing.Point(387, 21);
            this.forecastCtrl2.Name = "forecastCtrl2";
            this.forecastCtrl2.Size = new System.Drawing.Size(119, 110);
            this.forecastCtrl2.TabIndex = 6;
            // 
            // forecastCtrl1
            // 
            this.forecastCtrl1.Location = new System.Drawing.Point(262, 21);
            this.forecastCtrl1.Name = "forecastCtrl1";
            this.forecastCtrl1.Size = new System.Drawing.Size(116, 110);
            this.forecastCtrl1.TabIndex = 5;
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Location = new System.Drawing.Point(7, 111);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(24, 13);
            this.lblPressure.TabIndex = 4;
            this.lblPressure.Text = "n/a";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(7, 94);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(24, 13);
            this.lblHumidity.TabIndex = 3;
            this.lblHumidity.Text = "n/a";
            // 
            // picWeather
            // 
            this.picWeather.Location = new System.Drawing.Point(130, 51);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(52, 52);
            this.picWeather.TabIndex = 2;
            this.picWeather.TabStop = false;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(10, 51);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(83, 39);
            this.lblTemperature.TabIndex = 1;
            this.lblTemperature.Text = "n/a°";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 34);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(24, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "n/a";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 172);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WeatherForm";
            this.Text = "Weather";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconWeather;
        private System.Windows.Forms.Label lblCurrentLocation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picWeather;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label lblHumidity;
        private ForecastCtrl forecastCtrl1;
        private ForecastCtrl forecastCtrl2;
        private System.Windows.Forms.LinkLabel linkSetup;
    }
}

