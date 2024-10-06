using Xamarin.Essentials;
namespace SmartFarming
{
    public class GeolocationService
    {
        public async Task<Xamarin.Essentials.Location> GetLocationAsync()
        {
            try
            {
                // var location = await GeolocationService.GetLocationAsync();
                var location = new Xamarin.Essentials.Location
                {
                    Latitude = 40.712776, // Example: Latitude for New York City
                    Longitude = -74.005974 // Example: Longitude for New York City
                };

               /* location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Xamarin.Essentials.Geolocation.GetLocationAsync(new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.High));
                }*/

                return location;
            }
            catch (Exception ex)
            {
                // Handle location access errors
                return null;
            }
        }
    }
}