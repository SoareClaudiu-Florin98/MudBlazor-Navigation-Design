using Blazored.LocalStorage;
using System.Net.Http.Json;
using Video.Streaming.Platform.Ui.Shared;

namespace Video.Streaming.Platform.Ui.Client.Services
{
    public class FetchDataService
    {
        private readonly HttpClient _httpClient;

        public FetchDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<WeatherForecast[]?> GetWeatherForecasts()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
