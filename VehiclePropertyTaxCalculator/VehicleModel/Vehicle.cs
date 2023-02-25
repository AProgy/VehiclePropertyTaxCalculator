using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using VehiclePropertyTaxCalculator.VehicleModel;
namespace VehiclePropertyTaxCalculator.VehicleModel
{
    internal abstract class Vehicle : ITaxable
    {
        internal Vehicle()
        {
            this.DateOfManufacture = DateTime.Now.Year;
            this.EnginePower = 200;
            ID++;
        }

        internal Vehicle(int dateOfManufacture, int enginePower)
        {
            this.DateOfManufacture = dateOfManufacture;
            this.EnginePower = enginePower;
            ID++;
        }

        public static int ID { get; set; } = 1;

        public int DateOfManufacture { get; set; }
        public int EnginePower { get; set; }

        public abstract int Tax { get; }
        public abstract string VehicleInformation { get; }

        protected double TaxSale
        {
            get
            {
                if (DateTime.Now.Year - DateOfManufacture <= 3) return 1;
                else if (DateTime.Now.Year - DateOfManufacture == 4) return 0.9;
                else if (DateTime.Now.Year - DateOfManufacture == 5) return 0.8;
                else if (DateTime.Now.Year - DateOfManufacture == 6) return 0.7;
                else if (DateTime.Now.Year - DateOfManufacture == 7) return 0.6;
                else return 0.5;
            }
        }
    }
}