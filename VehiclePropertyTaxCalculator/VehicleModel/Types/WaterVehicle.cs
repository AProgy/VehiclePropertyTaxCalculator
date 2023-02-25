using System;
namespace VehiclePropertyTaxCalculator.VehicleModel.Types
{
    internal class WaterVehicle : Vehicle
    {
        internal WaterVehicle()
            : base() { }

        internal WaterVehicle(int dateOfManufacture, int enginePower)
            : base(dateOfManufacture, enginePower) { }

        public override int Tax => EnginePower * 150;

        public override string VehicleInformation => $"Tax for {DateOfManufacture} water vehicle with {EnginePower} HP";

        public override string ToString() => $"Water Vehicle";
    }
}