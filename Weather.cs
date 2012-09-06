using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace weather
{
    public class Weather
    {
        public class Forecast : IComparer<Forecast>
        {
            public string       Day { get; private set; }
            public DateTime     Date { get; private set; }
            public int          Low { get; private set; }
            public int          High { get; private set; }
            public string       Text { get; private set; }
            public Conditions   Condition { get; private set; }
            public string       Scale   { get; private set; }

            public string GetHighTemp()
            {
                return renderTemp(this.High);
            }

            public string GetLowTemp()
            {
                return renderTemp(this.Low);
            }

            private string renderTemp(int temp)
            {
                return string.Format("{0}°{1}", temp, this.Scale);
            }

            public static Forecast Parse(XElement forecast, string scale)
            {
                return new Forecast
                {
                    Day         = forecast.Attribute("day").Value,
                    Date        = DateTime.Parse(forecast.Attribute("date").Value),
                    Condition   = (Conditions)int.Parse(forecast.Attribute("code").Value),
                    High        = int.Parse(forecast.Attribute("high").Value),
                    Low         = int.Parse(forecast.Attribute("low").Value),
                    Text        = forecast.Attribute("text").Value,
                    Scale       = scale
                };
            }

            public int Compare(Forecast x, Forecast y)
            {
                return x.Date.CompareTo(y.Date);
            }
        }

        #region Enums
        public enum PressureRising { Steady, Rising, Falling };

        public enum Conditions
        {
            Tornado,
            [EnumDescription("Tropical storm")]
            TropicalStorm,
            Hurricane,
            [EnumDescription("Severe thunderstorms")]
            SevereThunderstorms,
            Thunderstorms,
            [EnumDescription("Mixed rain and snow")]
            MixedRainAndSnow,
            [EnumDescription("Mixed rain and sleet")]
            MixedRainAndSleet,
            [EnumDescription("Mixed snow and sleet")]
            MixedSnowAndSleet,
            [EnumDescription("Freezing drizzle")]
            FreezingDrizzle,
            Drizzle,
            [EnumDescription("Freezing rain")]
            FreezingRain,
            [EnumDescription("Showers")]
            Showers1,
            [EnumDescription("Showers")]
            Showers2,
            [EnumDescription("Snow flurries")]
            SnowFlurries,
            [EnumDescription("Light snow showers")]
            LightSnowShowers,
            [EnumDescription("Blowing snow")]
            BlowingSnow,
            Snow,
            Hail,
            Sleet,
            Dust,
            Foggy,
            Haze,
            Smoky,
            Blustery,
            Windy,
            Cold,
            Cloudy,
            [EnumDescription("Mostly cloudy night")]
            MostlyCloudyNight,
            [EnumDescription("Mostly cloudy day")]
            MostlyCloudyDay,
            [EnumDescription("Partly cloudy night")]
            PartlyCloudyNight,
            [EnumDescription("Partly cloudy day")]
            PartlyCloudyDay,
            [EnumDescription("Clear night")]
            ClearNight,
            Sunny,
            [EnumDescription("Fair night")]
            FairNight,
            [EnumDescription("Fair day")]
            FairDay,
            [EnumDescription("Mixed rain and hail")]
            MixedRainAndHail,
            Hot,
            [EnumDescription("Isolated thunderstorms")]
            IsolatedThunderstorms,
            [EnumDescription("Scattered thunderstorms")]
            ScatteredThunderstorms1,
            [EnumDescription("Scattered thunderstorms")]
            ScatteredThunderstorms2,
            [EnumDescription("Scattered showers")]
            ScatteredShowers,
            [EnumDescription("Heavy snow")]
            HeavySnow1,
            [EnumDescription("Scattered snow showers")]
            ScatteredSnowShowers,
            [EnumDescription("Heavy snow")]
            HeavySnow2,
            [EnumDescription("Partly cloudy")]
            PartlyCloudy,
            Thundershowers,
            [EnumDescription("Snow showers")]
            SnowShowers,
            [EnumDescription("Isolated thundershowers")]
            IsolatedThundershowers,
            [EnumDescription("Not Available")]
            NotAvailable = 3200
        }
        #endregion

        #region Properties
        public string           ImgSource { get; private set; }
        public string           Title { get; private set; }
        public string           Humidity { get; private set; }
        public string           Pressure { get; private set; }
        public PressureRising   Rising { get; private set; }
        public string           Temperature { get; private set; }
        public string           Scale { get; private set; }
        public string           UnitsPressure { get; private set; }
        public Conditions       Condition { get; private set; }
        public List<Forecast>   Forecasts { get; private set; }
        #endregion
        
        #region Public methods
        /// <summary>
        /// Get Temperature string 
        /// </summary>
        /// <returns>[temperature]°[scale]</returns>
        public string GetTemperature()
        {
            return Temperature + "°" + Scale;
        }

        /// <summary>
        /// Get Humidity string
        /// </summary>
        /// <returns>Humidiy: [value]%</returns>
        public string GetHumidity()
        {
            return "Humidiy: " + Humidity + "%";
        }

        /// <summary>
        /// Get Barometric pressure string
        /// </summary>
        /// <returns>Pressure: [pressure][units] [rising?]</returns>
        public string GetPressure()
        {
            return "Pressure: " + Pressure + UnitsPressure + " " + Rising.ToString();
        } 
        #endregion

        #region YAHOO Weather Parser
        /// <summary>
        /// Parses YAHOO Weather API XML and returns an instance of Weather object
        /// </summary>
        /// <param name="weather"></param>
        /// <returns></returns>
        public static Weather Parse(XDocument weather)
        {

            if (weather == null) return null;

            XmlNamespaceManager ns = new XmlNamespaceManager(weather.FirstNode.CreateNavigator().NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            string html     = weather.XPathSelectElement("/rss/channel/item/description").Value;
            var units       = weather.XPathSelectElement("/rss/channel/yweather:units", ns);
            var atmosphere  = weather.XPathSelectElement("/rss/channel/yweather:atmosphere", ns);
            var condition   = weather.XPathSelectElement("/rss/channel/item/yweather:condition", ns);
            var forecast    = weather.XPathSelectElements("/rss/channel/item/yweather:forecast", ns);

            if (weather.XPathSelectElement("/rss/channel/item/title").Value.Contains("not found")) return null;

            return new Weather
            {
                ImgSource = XElement.Parse("<body>" + html + "</body>").XPathSelectElement("//img").Attribute("src").Value,
                Title = weather.XPathSelectElement("/rss/channel/item/title").Value,
                Temperature = condition.Attribute("temp").Value,
                Scale = units.Attribute("temperature").Value,
                Humidity = atmosphere.Attribute("humidity").Value,
                Pressure = atmosphere.Attribute("pressure").Value,
                Rising = (PressureRising)int.Parse(atmosphere.Attribute("rising").Value),
                UnitsPressure = units.Attribute("pressure").Value,
                Condition = (Conditions)int.Parse(condition.Attribute("code").Value),
                Forecasts = new List<Forecast>(forecast.Select(f => Forecast.Parse(f, units.Attribute("temperature").Value)))
            };
        }
        #endregion

        public override string ToString()
        {
            return this.Title + "\nTemperature: " + this.GetTemperature()
                              + "\n" + this.GetHumidity()
                              + "\n" + this.GetPressure();
        }
    }
}
