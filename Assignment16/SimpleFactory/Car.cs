using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class Car
    {
        internal Car() { }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Wheel[] Wheels { get; internal set; }

        public Carcass Carcass { get; set; }

        public void ChangeWheels(Wheel wheel)
        {
            Wheels = new Wheel[] { wheel, (Wheel)wheel.Clone(), (Wheel)wheel.Clone(), (Wheel)wheel.Clone() };
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} with {Engine.FuelType} Engine and {Engine.HorsePowers} horsepowers and {Engine.Volume} dm^3 volume.\n" +
                $"Has {Carcass.CarcassType} carcass type and following size: {Carcass.Width} X {Carcass.Length} X {Carcass.Height}.\n";
        }

        public void SetDimensions(float width, float length, float height) => Carcass.SetDimensions(width, length, height);
    }
}
