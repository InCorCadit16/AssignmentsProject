using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class Wheel: ICloneable
    {
        public float Diameter { get; set; }

        public string Manufacturer { get; set; }

        public float PatternDepth { get; set; }

        public object Clone()
        {
            return new Wheel { Diameter = this.Diameter, Manufacturer = this.Manufacturer, PatternDepth = this.PatternDepth };
        }
    }
}
