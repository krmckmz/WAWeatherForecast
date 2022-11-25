using FluentValidation;

namespace WeatherForecast.Data;

public class GetTodayByCityValidator : AbstractValidator<GetTodayByCityRequestModel>
{
    public GetTodayByCityValidator()
    {
        RuleFor(x => x.City).NotEmpty().WithMessage("City must be filled.");
    }
}