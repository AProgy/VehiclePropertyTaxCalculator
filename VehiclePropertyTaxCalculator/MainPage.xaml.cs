namespace VehiclePropertyTaxCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        if (Utilities.IsConnectedToInternet())
            Utilities.RateAPI.GetRates();

        InitializeComponent();
        BindingContext = new VehicleViewModel();
    }

    void EntryValueChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if ((sender as Entry).Text == "")
            (sender as Entry).Text = "0";

        if (e.NewTextValue.Contains('.'))
            (sender as Entry).Text = e.OldTextValue;
    }
}