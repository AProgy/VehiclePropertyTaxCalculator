using System;
namespace VehiclePropertyTaxCalculator.VehicleModel.Types
{
    internal class Motorcycle : Vehicle
    {
        internal Motorcycle()
            : base() { }

        internal Motorcycle(int dateOfManufacture, int enginePower)
            : base(dateOfManufacture, enginePower) { }

        public override int Tax => EnginePower * 40;

        public override string VehicleInformation => $"Tax for {DateOfManufacture} motorcycle with {EnginePower} HP";

        public override string ToString() => $"Motorcycle";
    }
}