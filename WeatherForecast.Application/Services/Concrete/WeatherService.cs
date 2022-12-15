namespace WeatherForecast.Application;
using WeatherForecast.Data;
using Newtonsoft.Json;

public class WeatherService : IWeatherService
{
    private readonly IUrlBuilder _urlBuilder;
    public WeatherService(IUrlBuilder urlBuilder)
    {
        _urlBuilder = urlBuilder;
    }

    private const string apiRequestDomain = "http://api.openweathermap.org";
    private const string apiKey = "e7f039d94cc5ced34305901239329810";

    public string GetApiEndpoint(GetTodayByCityRequestModel requestModel)
    {
        if (String.IsNullOrEmpty(requestModel.CityId))
            return string.Empty;

        string endPoint = _urlBuilder.SetBaseUrl(apiRequestDomain)
                                     .SetApiKey(apiKey)
                                     .Append("data")
                                     .Append("2.5")
                                     .Append("weather")
                                     .AppendParam("id", requestModel.CityId)
                                     .AppendParam("appid", apiKey)
                                     .AppendParam("units", UnitType.Metric.ToString())
                                     .Build();

        return endPoint;
    }


    public async Task<Result> GetTodayByCity(GetTodayByCityRequestModel requestModel)
    {
        var url = GetApiEndpoint(requestModel);

        if (string.IsNullOrEmpty(url))
            return new Result { Status = false, Message = "City id is null , please enter a valid city id." };

        var client = new HttpClient();
        try
        {
            client.BaseAddress = new Uri(apiRequestDomain);
            var response = await client.GetAsync(url);
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            var weather = JsonConvert.DeserializeObject<ResponseWeather>(responseString);

            return new Result { Status = true, Data = weather, Message = "Weather data maintained successfully." };
        }
        catch (Exception ex)
        {
            return new Result { Status = false, Message = ex.ToString() };
        }

    }
}
