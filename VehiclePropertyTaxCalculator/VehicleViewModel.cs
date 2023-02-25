using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using VehiclePropertyTaxCalculator.Other;
using VehiclePropertyTaxCalculator.VehicleModel;
using VehiclePropertyTaxCalculator.VehicleModel.Types;
namespace VehiclePropertyTaxCalculator
{
    internal class VehicleViewModel : INotifyPropertyChanged
    {
        #region Tax Info

        private RatesModel _ratesModel;
        public RatesModel RatesModel
        {
            get => _ratesModel;
            set
            {
                _ratesModel = value;

                _ratesModel.Rates.USD = 1 / _ratesModel.Rates.AMD;
                _ratesModel.Rates.RUB *= _ratesModel.Rates.USD;
                _ratesModel.Rates.AMD = 1;
            }
        }

        private double _calculatedTaxAMD;
        public double CalculatedTaxAMD
        {
            get => _calculatedTaxAMD;
            private set
            {
                _calculatedTaxAMD = value;
                OnPropertyChanged();
            }
        }

        private double _calculatedTaxUSD;
        public double CalculatedTaxUSD
        {
            get => Math.Round(_calculatedTaxUSD, 2);
            private set
            {
                _calculatedTaxUSD = value;
                OnPropertyChanged();
            }
        }

        private double _calculatedTaxRUB;
        public double CalculatedTaxRUB
        {
            get => Math.Round(_calculatedTaxRUB, 2);
            private set
            {
                _calculatedTaxRUB = value;
                OnPropertyChanged();
            }
        }

        private string _taxInformation;
        public string TaxInformation
        {
            get => _taxInformation;
            private set
            {
                _taxInformation = value;
                OnPropertyChanged();
            }
        }

        private bool _isCalculateButtonClicked;
        public bool IsCalculateButtonClicked
        {
            get => _isCalculateButtonClicked;
            set
            {
                if (_isCalculateButtonClicked != value)
                {
                    _isCalculateButtonClicked = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Vehicle Components

        public ObservableCollection<ITaxable> Types { get; }

        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                _selectedVehicle = value;
                IsCalculateButtonClicked = false;
                OnPropertyChanged();
            }
        }

        private int _dateOfManufacture;
        public int DateOfManufacture
        {
            get => _dateOfManufacture;
            set
            {
                _dateOfManufacture = value;
                IsCalculateButtonClicked = false;
                OnPropertyChanged();
            }
        }

        private int _enginePower;
        public int EnginePower
        {
            get => _enginePower;
            set
            {
                _enginePower = value;
                IsCalculateButtonClicked = false;
                OnPropertyChanged();
            }
        }

        #endregion

        public VehicleViewModel()
        {
            DeserializeRatesAsync();

            DateOfManufacture = DateTime.Now.Year;
            EnginePower = 200;

            Types = new ObservableCollection<ITaxable>()
            {
                new LightPassengerCar(),
                new HeavyPassengerCar(),
                new Truck(),
                new Motorcycle(),
                new WaterVehicle()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            ((Command)CalculateTax).ChangeCanExecute();
        }

        private ICommand _calculateTax;
        public ICommand CalculateTax
        {
            get
            {
                if (_calculateTax == null)
                {
                    _calculateTax = new Command(
                    () =>
                    {
                        IsCalculateButtonClicked = true;

                        SelectedVehicle.DateOfManufacture = DateOfManufacture;
                        SelectedVehicle.EnginePower = EnginePower;

                        OtherValueTaxes();

                        TaxInformation = SelectedVehicle.VehicleInformation;
                    },
                    () =>
                        DateOfManufacture >= 1900
                        && DateOfManufacture <= DateTime.Now.Year
                        && EnginePower > 0);
                }
                return _calculateTax;
            }
        }

        private async void DeserializeRatesAsync() => RatesModel = await Utilities.RateAPI.DeserializeRatesAsync();

        private void OtherValueTaxes()
        {
            CalculatedTaxAMD = SelectedVehicle.Tax;
            CalculatedTaxUSD = SelectedVehicle.Tax * RatesModel.Rates.USD;
            CalculatedTaxRUB = SelectedVehicle.Tax * RatesModel.Rates.RUB;
        }
    }
}