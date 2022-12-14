using WeatherForecast.Data;
public interface IWeatherService
{
   string GetApiEndpoint(GetTodayByCityRequestModel requestModel);
    Task<Result> GetTodayByCity(GetTodayByCityRequestModel requestModel);
}