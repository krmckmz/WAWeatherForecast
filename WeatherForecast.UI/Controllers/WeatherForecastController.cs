using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using System.Linq;
using System.Collections;
using System.Net.Http;
using System;
using System.ComponentModel.Annotations;
using WeatherForecast.Data;
using System.Web.Http;

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
    public IEnumerable<WeatherForecast> GetTodaysWeatherByCity([FromBody] GetTodayByCityRequestModel requestModel)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        return _weatherService.GetTodayByCity(requestModel.City);
    }
}
