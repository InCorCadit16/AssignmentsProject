using SimpleFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class CarFactory
    {
        public static Car CreateCar(string manufacturer, string model, CarcassType carcassType, int horsePowers = 90, float wheelDiameter = 27, float engineVolume = 1.5f ,FuelType fuelType = FuelType.Diesel)
        {
            Car car = new Car() { Model = model, Manufacturer = manufacturer, Engine = new Engine() };

            car.Model = model;
            if (string.IsNullOrEmpty(model))
                car.Model = "Unknown model";

            car.Manufacturer = manufacturer;
            if (string.IsNullOrEmpty(manufacturer))
                car.Model = "Unknown manufacturer";

            car.Engine = new Engine() { FuelType = fuelType, HorsePowers = (horsePowers > 0 ? horsePowers : 90), Volume = (engineVolume > 0 ? engineVolume: 1.5f) };

            Wheel wheel = new Wheel { Diameter = (wheelDiameter > 0 ? wheelDiameter : 27), Manufacturer = "NOKIAN", PatternDepth = 1.5f };
            car.Wheels = new Wheel[] { wheel, (Wheel)wheel.Clone(), (Wheel)wheel.Clone(), (Wheel)wheel.Clone() };

            car.Carcass = new Carcass { CarcassType = carcassType, Width = 1.45f, Height = 1.33f, Length = 2.03f };

            return car;
        }
    }
}
