using System;
using System.ComponentModel;
namespace VehiclePropertyTaxCalculator.VehicleModel.Types
{
    internal class LightPassengerCar : Vehicle
    {
        internal LightPassengerCar()
            : base() { }

        internal LightPassengerCar(int dateOfManufacture, int enginePower)
            : base(dateOfManufacture, enginePower) { }

        public override int Tax
        {
            get
            {
                if (EnginePower <= 120)
                    return (int)(200 * TaxSale * EnginePower);
                else if (EnginePower > 120
                    && EnginePower <= 250)
                {
                    if (EnginePower > 150)
                        return (int)(TaxSale * (300 * EnginePower + 1000 * (EnginePower - 150)));
                    else
                        return (int)(300 * TaxSale * EnginePower);
                }
                else
                    return (int)(TaxSale * (500 * EnginePower + 1000 * (EnginePower - 150)));
            }
        }

        public override string VehicleInformation => $"Tax for {DateOfManufacture} passenger car(<10 seats) with {EnginePower} HP";

        public override string ToString() => $"Passenger Car(<10 Seats)";
    }
}