using System;
namespace VehiclePropertyTaxCalculator.VehicleModel.Types
{
    internal class HeavyPassengerCar : Vehicle
    {
        internal HeavyPassengerCar()
            : base() { }

        internal HeavyPassengerCar(int dateOfManufacture, int enginePower)
            : base(dateOfManufacture, enginePower) { }

        public override int Tax
        {
            get
            {
                if (EnginePower > 200)
                    return (int)(200 * TaxSale * EnginePower);
                else
                    return (int)(100 * TaxSale * EnginePower);
            }
        }

        public override string VehicleInformation => $"Tax for {DateOfManufacture} passenger car(>=10 seats) with {EnginePower} HP";

        public override string ToString() => $"Passenger Car(>=10 Seats)";
    }
}