using System;
using System.Windows.Forms;

namespace weather
{
    public partial class ForecastCtrl : UserControl
    {
        #region CTOR
        public ForecastCtrl()
        {
            InitializeComponent();
        } 
        #endregion

        #region Public Property
        /// <summary>
        /// Day of the forecast
        /// </summary>
        public DateTime Day { set { lblDay.Text = value.ToString("MMMM dd, yyyy"); } }
        /// <summary>
        /// High temp of the day
        /// </summary>
        public string TemperatureHigh { set { lblTempHigh.Text = value; } }
        /// <summary>
        /// Low temp of the day
        /// </summary>
        public string TemperatureLow { set { lblTempLow.Text = value; } }
        /// <summary>
        /// Day's condition
        /// </summary>
        public string Condition { set { lblCondition.Text = value; } } 
        #endregion
    }
}
