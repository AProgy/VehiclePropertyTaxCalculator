using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace VehiclePropertyTaxCalculator.Other
{
    class RatesModel
    {
        public RatesModel() { }

        [JsonPropertyName("disclaimer")]
        public string Disclaimer { get; set; }
        [JsonPropertyName("license")]
        public string License { get; set; }
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("rates")]
        public Currencies Rates { get; set; }

        public class Currencies
        {
            private double _amd;
            [JsonPropertyName("AMD")]
            public double AMD
            {
                get => _amd;
                set
                {
                    _amd = value;
                }
            }

            private double _usd;
            [JsonIgnore]
            public double USD
            {
                get => _usd;
                set
                {
                    _usd = value;
                }
            }

            private double _rub;
            [JsonPropertyName("RUB")]
            public double RUB
            {
                get => _rub;
                set
                {
                    _rub = value;
                }
            }
        }
    }
}