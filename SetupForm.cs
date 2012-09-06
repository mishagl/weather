using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace weather
{
    public partial class SetupForm : Form
    {
        public GeoLocation CurrentLocation { get; set; }

        public SetupForm()
        {
            InitializeComponent();

            cbTempScale.DataSource = System.Enum.GetValues(typeof(GeoLocation.TempScale));
        }

        private void cbTempScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentLocation == null) return;

            CurrentLocation.Scale = (GeoLocation.TempScale)cbTempScale.SelectedValue;
            saveConfig(CurrentLocation);

            //renderWeather(Weather.Parse(getWeather(currentLocation)));
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var o = lbLocations.SelectedItem;
            if (o is GeoLocation)
            {
                var location = (GeoLocation)o;
                Debug.WriteLine("Location: " + location.Name + " > WOEID: " + location.WOEID);

                //lblCurrentLocation.Text = location.ToString();
                saveConfig(location);
                CurrentLocation = location;
                cbTempScale.SelectedItem = CurrentLocation.Scale;
                cbTempScale.Visible = true;
                //renderWeather(Weather.Parse(getWeather(currentLocation)));
            }
        }

        private void btnSearchLoaction_Click(object sender, EventArgs e)
        {
            string searchName = tbLocation.Text;
            if (string.IsNullOrEmpty(searchName)) return;

            var places = getPlacesFromAPI(searchName);
            try
            {
                lbLocations.SuspendLayout();
                lbLocations.Items.Clear();

                lbLocations.Items.AddRange(
                    places.XPathSelectElements("/ResultSet/Result")
                          .OrderBy(p => uint.Parse(p.Element("quality").Value))
                          .Select(p => new GeoLocation
                          {
                              Name = string.Join(",", new string[] { p.Element("city").Value, 
                                                                                   p.Element("state").Value,
                                                                                   p.Element("country").Value }),
                              WOEID = uint.Parse(p.Element("woeid").Value)
                          })
                          .ToArray()
                 );


            }
            finally
            {
                lbLocations.ResumeLayout(true);
            }
        }

        static readonly string PLACES_API = "http://where.yahooapis.com/geocode?q={0}&start=0&count=100";
        //static readonly string PLACES_API = "http://where.yahooapis.com/v1/places.q('{0}')?appid={1}";
        //static readonly string APPID = "fFxSpezV34FRNzLACEhVz2X8spz_RDFB7qconklWJ17cSAdP1ge6QNxJFWNMOjOz";

        private XDocument getPlacesFromAPI(string hint)
        {
            //var resource = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //var o = resource.GetObject("appid");

            //if(o == null && !(o is string)) throw new ArgumentException("App ID is null or invalid");
            //XDocument xdoc = XDocument.Load(string.Format(PLACES_API, System.Web.HttpUtility.HtmlEncode(hint), o.ToString()));

            if (!Regex.IsMatch(hint, @"\b\d+\b")) hint += "*";

            XDocument xdoc = XDocument.Load(string.Format(PLACES_API, System.Web.HttpUtility.UrlEncode(hint)));

            return xdoc;
        }

        private static void saveConfig(GeoLocation location)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(location.GetType());
            using (var xml = new XmlTextWriter("config", Encoding.UTF8))
            {
                s.Serialize(xml, location);
            }
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            if (CurrentLocation != null)
            {
                tbLocation.Text = CurrentLocation.Name;
                cbTempScale.SelectedItem = CurrentLocation.Scale;
                cbTempScale.Visible = true;
            }
        }
    }
}
