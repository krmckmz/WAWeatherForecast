namespace WeatherForecast.Application;
using WeatherForecast.Data;
using System.Text;
using Newtonsoft.Json;

public class WeatherService : IWeatherService
{
    private const string apiRequestDomain = "http://api.openweathermap.org";
    private const string apiKey = "e7f039d94cc5ced34305901239329810";

    public string GetApiUrl(GetTodayByCityRequestModel requestModel)
    {
        if (String.IsNullOrEmpty(requestModel.CityId))
            return string.Empty;

        StringBuilder queryStringBuilder = new StringBuilder();

        queryStringBuilder.Append("/data/2.5/weather?");
        queryStringBuilder.Append($"id={requestModel.CityId}&");
        queryStringBuilder.Append($"appid={apiKey}&");
        queryStringBuilder.Append($"units={UnitType.Metric.ToString()}");

        return queryStringBuilder.ToString();
    }


    public async Task<Result> GetTodayByCity(GetTodayByCityRequestModel requestModel)
    {
        var url = GetApiUrl(requestModel);
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
