using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarming.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class MeteomaticsApiService
    {
        private readonly string _username = "ahtiluoma_jarkko";
        private readonly string _password = "AY1V0fc84b";
        private readonly HttpClient _httpClient;

        public MeteomaticsApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetWeatherDataAsync()
        {
            // Encode the username and password into Base64
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_password}"));
            string endpoint = $"https://{_username}:{_password}@api.meteomatics.com/2024-10-05T00:00:00ZP5D:PT1H/volumetric_soil_water_-5cm:m3m3,volumetric_soil_water_-15cm:m3m3,volumetric_soil_water_-50cm:m3m3,volumetric_soil_water_-150cm:m3m3/47.412164,9.340652/html?source=mix";
             
            // Add the Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            // Make the API request
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }

}
