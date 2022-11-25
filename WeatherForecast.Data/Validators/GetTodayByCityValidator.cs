using FluentValidation;
using FluentValidation.AspNetCore;

namespace WeatherForecast.Data;

public class GetTodayByCityValidator : AbstractValidator<GetTodayByCityRequestModel>
{
    RuleFor(x=>x.City).NotEmpty().WithMessage("City cannot be empty.");
}