using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace weather
{
    public class GeoLocation
    {
        public enum TempScale { F, C };

        public string Name { get; set; }
        public uint WOEID { get; set; }
        public TempScale Scale { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
