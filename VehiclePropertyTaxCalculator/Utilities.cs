using System.Text.Json;
using VehiclePropertyTaxCalculator.Other;
namespace VehiclePropertyTaxCalculator
{
    internal static class Utilities
	{
		public static bool IsConnectedToInternet()
		{
			if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet) return true;
			return false;
        }

		public static class RateAPI
		{
			private static readonly string APP_ID = $"434f7232fdf240b28ab1b1275a7a48ed";

			public static async void GetRates()
			{
				string path = "/Users/arthurarshakyan/Projects/VehiclePropTaxCalc/VehiclePropTaxCalc/Rates.json";
				using (HttpRequestMessage request = new HttpRequestMessage()
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://openexchangerates.org/api/latest.json?app_id={APP_ID}&symbols=AMD,RUB"),
					Headers = { { "accept", "application/json" } }
				})

				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage response = await client.SendAsync(request))
					{
						if (response.IsSuccessStatusCode == false) return;
						var result = await response.Content.ReadAsByteArrayAsync();
						using (FileStream fs = new FileStream(path, FileMode.Create))
						{
							await fs.WriteAsync(result, 0, result.Length);
						}
					}
				}
			}

            public static async Task<RatesModel> DeserializeRatesAsync()
            {
                string path = "/Users/arthurarshakyan/Projects/VehiclePropTaxCalc/VehiclePropTaxCalc/Rates.json";
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var model = await JsonSerializer.DeserializeAsync<RatesModel>(fs);
                    return model;
                }
            }
        }
    }
}