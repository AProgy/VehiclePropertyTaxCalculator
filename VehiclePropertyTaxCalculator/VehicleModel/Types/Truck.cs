using System;
namespace VehiclePropertyTaxCalculator.VehicleModel.Types
{
    internal class Truck : Vehicle
    {
        internal Truck()
            : base() { }

        internal Truck(int dateOfManufacture, int enginePower)
            : base(dateOfManufacture, enginePower) { }

        public override int Tax
        {
            get
            {
                if (DateTime.Now.Year - DateOfManufacture >= 20) return 0;

                if (EnginePower > 200)
                    return (int)(200 * TaxSale * EnginePower);
                else
                    return (int)(100 * TaxSale * EnginePower);
            }
        }

        public override string VehicleInformation => $"Tax for {DateOfManufacture} truck with {EnginePower} HP";

        public override string ToString() => $"Truck";
    }
}