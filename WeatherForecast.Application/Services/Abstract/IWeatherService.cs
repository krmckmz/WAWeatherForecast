using WeatherForecast.Data;
public interface IWeatherService
{
   string GetApiUrl(GetTodayByCityRequestModel requestModel);
    Task<Result> GetTodayByCity(GetTodayByCityRequestModel requestModel);
}