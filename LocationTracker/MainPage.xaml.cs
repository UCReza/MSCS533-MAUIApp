using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace LocationTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        StatusLabel.Text = "Requesting location...";
        StatusLabel.TextColor = Colors.Black;

        try
        {
            var request = new GeolocationRequest(
                GeolocationAccuracy.Medium,
                TimeSpan.FromSeconds(10));

            var location = await Geolocation.Default.GetLocationAsync(request);

            if (location is null)
            {
                StatusLabel.Text = "Unable to retrieve location.";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            LatitudeLabel.Text  = location.Latitude.ToString("F6", CultureInfo.InvariantCulture);
            LongitudeLabel.Text = location.Longitude.ToString("F6", CultureInfo.InvariantCulture);
            AccuracyLabel.Text  = (location.Accuracy ?? 0d).ToString("F1", CultureInfo.InvariantCulture);
            TimestampLabel.Text = location.Timestamp.ToLocalTime().ToString("G");

            StatusLabel.Text = "Location updated successfully.";
            StatusLabel.TextColor = Colors.Green;
        }
        catch (FeatureNotSupportedException)
        {
            StatusLabel.Text = "Location is not supported on this device.";
            StatusLabel.TextColor = Colors.Red;
        }
        catch (FeatureNotEnabledException)
        {
            StatusLabel.Text = "Location services are not enabled.";
            StatusLabel.TextColor = Colors.Red;
        }
        catch (PermissionException)
        {
            StatusLabel.Text = "Location permission was denied.";
            StatusLabel.TextColor = Colors.Red;
        }
        catch (Exception ex)
        {
            StatusLabel.Text = $"Unexpected error: {ex.Message}";
            StatusLabel.TextColor = Colors.Red;
        }
    }
}
