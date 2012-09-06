using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace weather
{

    public partial class WeatherForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        #region Variables
        private GeoLocation currentLocation = null;
        private List<ForecastCtrl> forecast = null; 
        #endregion

        #region CTOR
        public WeatherForm()
        {
            InitializeComponent();

            forecast = new List<ForecastCtrl>
            {
                forecastCtrl1, forecastCtrl2
            };

            loadConfig();
            renderWeather(Weather.Parse(getWeather(currentLocation)));
        } 
        #endregion

        #region Render
        private void renderWeather(Weather weather)
        {
            timer1.Stop();

            if (weather == null)
            {
                picWeather.ImageLocation = "";
                notifyIconWeather.BalloonTipText = notifyIconWeather.Text = lblPressure.Text = lblHumidity.Text = lblDescription.Text = lblTemperature.Text = "n/a";
            }
            else
            {
                picWeather.ImageLocation = weather.ImgSource;
                lblDescription.Text = weather.Title;
                lblTemperature.Text = weather.GetTemperature();
                lblHumidity.Text = weather.GetHumidity();
                lblPressure.Text = weather.GetPressure();

                foreach (var x in forecast.Zip(weather.Forecasts.OrderBy(f => f.Date), (a, b) => new { Control = a, Forecast = b }))
                {
                    var c = x.Control;
                    var f = x.Forecast;

                    c.Day = f.Date;
                    c.TemperatureHigh = f.GetHighTemp();
                    c.TemperatureLow = f.GetLowTemp();
                    c.Condition = f.Condition.GetDescription();
                }

                renderTrayWeather(weather, currentLocation);
            }

            timer1.Interval = (int)TimeSpan.FromMinutes(10).TotalMilliseconds;
            timer1.Start();
        }

        private void renderTrayWeather(Weather weather, GeoLocation currentLocation)
        {
            notifyIconWeather.Text = weather.GetTemperature() + " - " + currentLocation.Name;
            notifyIconWeather.BalloonTipText = weather.ToString();
            notifyIconWeather.BalloonTipTitle = "Weather";

            notifyIconWeather.Icon = renderIcon(weather.Temperature);
        }

        private System.Drawing.Icon renderIcon(string p)
        {
            Font drawFont = null;
            SolidBrush drawBrush = null;
            StringFormat drawFormat = null;
            IntPtr hIcon;
            Icon temp = null;
            Icon ico = null;

            try
            {

                int width = 16;
                //switch (p.Length)
                //{
                //    case 2:
                //        width = 25;
                //        break;
                //    case 3:
                //        width = 35;
                //        break;
                //}

                using (Bitmap bmp = new Bitmap(width, 16))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        drawFont = new Font("Onyx", 16, FontStyle.Regular);
                        drawBrush = new SolidBrush(Color.Black);
                        drawFormat = new StringFormat();
                        
                        g.DrawString(p, drawFont, drawBrush, 0,-5, drawFormat);
                        //g.DrawString(p, drawFont, drawBrush, 0, 0, drawFormat);
                        g.Flush();

                        hIcon = bmp.GetHicon();
                        temp = Icon.FromHandle(hIcon);
                        ico = (Icon)temp.Clone();

                        temp.Dispose();
                        DestroyIcon(hIcon);
                    }
                }
            }
            finally
            {
                drawFont.Dispose();
                drawBrush.Dispose();
                drawFormat.Dispose();

                drawFormat = null;
                drawFont = null;
                drawBrush = null;
            }

            return ico;
        } 
        #endregion

        #region Weather API
        protected static readonly string WEATHERAPI = "http://weather.yahooapis.com/forecastrss?w={0}&u={1}";

        private XDocument getWeather(GeoLocation currentLocation)
        {
            if (currentLocation == null) return null;

            try
            {
                XDocument xdoc = XDocument.Load(string.Format(WEATHERAPI,
                                                              currentLocation.WOEID,
                                                              currentLocation.Scale.ToString().ToLower()
                                                             )
                                                );

                return xdoc;
            }
            catch (Exception ex)
            {
                return null;
            }

        } 
        #endregion

        #region Config Loader
        private void loadConfig()
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(GeoLocation));
            try
            {
                using (var xml = new XmlTextReader("config"))
                {
                    currentLocation = (GeoLocation)s.Deserialize(xml);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (currentLocation != null)
            {
                lblCurrentLocation.Text = currentLocation.ToString();
            }
        } 
        #endregion

        #region Event Handler
        private void timer1_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Timer event...");

            if (currentLocation == null)
            {
                timer1.Stop();
            }
            else
            {
                renderWeather(Weather.Parse(getWeather(currentLocation)));
            }
        }

        private void notifyIconWeather_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                notifyIconWeather.ShowBalloonTip((int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIconWeather_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void linkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SetupForm f = new SetupForm())
            {
                f.CurrentLocation = currentLocation;
                f.ShowDialog();
                currentLocation = f.CurrentLocation;
            }

            renderWeather(Weather.Parse(getWeather(currentLocation)));
        }

        #endregion

    }
}
