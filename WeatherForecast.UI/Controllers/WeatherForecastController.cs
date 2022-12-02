using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Data;

namespace WeatherForecast.UI.Controllers;

[ApiController]
[Route("api/Weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetTodayByCity")]
    public ObjectResult GetTodaysWeatherByCity([FromBody] GetTodayByCityRequestModel requestModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _weatherService.GetTodayByCity(requestModel);

        if (result.Result.Status)
            return Ok(result);
        else
            return BadRequest(result);
    }
}
